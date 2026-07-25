using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public partial class CTRL_validateCustomer : System.Web.UI.UserControl
    {
        protected void verifyUser()
        {
            if (Session["role"] == null || (Convert.ToInt32(Session["role"]) != 1)){
                Session.Clear();
                Response.Redirect("WebForm1.aspx");
            } 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataToGridView();
            }
        }
        protected void onGridEdit(object sender ,System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            lit_err.Text = "";
            gv_CustomerRequests.EditIndex = e.NewEditIndex;
            BindDataToGridView();
        }

        protected void RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            lit_err.Text = "";
            verifyUser();
            GridViewRow row = (GridViewRow)gv_CustomerRequests.Rows[e.RowIndex];
            TextBox custID = (TextBox)row.Cells[0].Controls[0];
            TextBox comment = (TextBox)row.Cells[9].Controls[0];


            if (comment.Text.Length != 0)
            {
                var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
                using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
                {
                    try
                    {
                        DBconnection.Open();
                        bool StillEditable = true;
                        String checkQuery = String.Format("select status from CUSTOMERS where custID = {0}", Convert.ToInt32(custID.Text));
                        SqlCommand Checkcmd = new SqlCommand(checkQuery, DBconnection);
                        SqlDataReader reader = Checkcmd.ExecuteReader();
                        if (reader.Read())//check if another checker had already handled the customer creation request
                        {
                            if (Convert.ToInt32(reader["status"]) == 0 || Convert.ToInt32(reader["status"]) == 4)
                            {
                                StillEditable = true;
                            }
                            else
                            {
                                StillEditable = false;
                            }
                        }
                        reader.Close();
                        if (StillEditable)
                        {
                            String query = String.Format("Update CUSTOMERS set comments = '{0}' where custID = {1}", comment.Text, Convert.ToInt32(custID.Text));
                            SqlCommand cmd = new SqlCommand(query, DBconnection);
                            cmd.ExecuteNonQuery();
                            gv_CustomerRequests.EditIndex = -1;
                        }
                        else
                        {
                            lit_err.Text = "the request was edited by another checker";
                        }
                            BindDataToGridView();
                        lit_err.Text = "";
                    }
                    catch (Exception ex)
                    {
                        lit_err.Text = ex.Message;
                    }

                }
            }
            else
            {
                gv_CustomerRequests.EditIndex = -1;
                BindDataToGridView();
            }

        }

        protected void gvRowCommand(object sender, GridViewCommandEventArgs e)
        {
            verifyUser();
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
            {
                try
                {

                    bool StillEditable = true;
                    DBconnection.Open();
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    //GridViewRow row = (GridViewRow)gv_CustomerRequests.Rows[Convert.ToInt32(e.CommandArgument)];
                    int custID = Convert.ToInt32(gv_CustomerRequests.DataKeys[rowIndex].Value);
                    String checkQuery = String.Format("select status from CUSTOMERS where custID = {0}", custID);
                    SqlCommand Checkcmd = new SqlCommand(checkQuery, DBconnection);
                    SqlDataReader reader = Checkcmd.ExecuteReader();
                    if (reader.Read()) {
                        if (Convert.ToInt32(reader["status"]) == 1 || Convert.ToInt32(reader["status"]) == 5)
                        {
                            StillEditable = true;
                        }
                        else
                        {
                            StillEditable = false; 
                        }
                    }
                    reader.Close();
                    if (StillEditable)
                    {
                        if (e.CommandName == "approveRow")
                        {
                            String query = String.Format("update CUSTOMERS set status = 2 where custID = {0},checkerID = {1}, checkerName = '{2}'", custID,Convert.ToInt32(Session["ID"]), Session["uname"].ToString());
                            SqlCommand cmd = new SqlCommand(query, DBconnection);
                            cmd.ExecuteNonQuery();
                            String getCustQuery = String.Format("select * from CUSTOMERS where custID = {0}", custID);
                            SqlCommand getCust = new SqlCommand(getCustQuery, DBconnection);
                            SqlDataReader cust = getCust.ExecuteReader();
                            cust.Read();
                            String Name;
                            String Password; 
                            int role;
                            bool active;
                            Name = cust["Name"].ToString();
                            Password = "NBE@" + cust["nationalID"];//must add encryption
                            role = 3;
                            active = false;
                            cust.Close();
                                String insertQuery = "insert into USERS (Name,password,CustomerID,Role,active) values(@name,@password,@custID,@role,@active)";
                            SqlCommand insertcmd = new SqlCommand(insertQuery, DBconnection);
                            insertcmd.Parameters.AddWithValue("@name", Name);
                            insertcmd.Parameters.AddWithValue("@password", Password);
                            insertcmd.Parameters.AddWithValue("@custID", custID);
                            insertcmd.Parameters.AddWithValue("@role", role);
                            insertcmd.Parameters.AddWithValue("@active", active);
                            insertcmd.ExecuteNonQuery();
                        }
                        else if (e.CommandName == "rejectRow")
                        {
                            String query = String.Format("update CUSTOMERS set status = 3 , checkerID = {0}, checkerName = '{1}' where CustID = {2}", Convert.ToInt32(Session["ID"]), Session["uname"].ToString(), custID);
                            SqlCommand cmd = new SqlCommand(query, DBconnection);
                            cmd.ExecuteNonQuery();
                        }
                        else if (e.CommandName == "requestEditRow")
                        {
                            GridViewRow row = (GridViewRow)gv_CustomerRequests.Rows[rowIndex];
                            TextBox TXTcomment = (TextBox)row.FindControl("txt_comment");
                            String comment = "";
                            if (TXTcomment != null) { 
                             comment = TXTcomment.Text;
                            }
                            String query = String.Format("update CUSTOMERS set status = 4 ,checkerID = {0}, checkerName = '{1}' , comments = '{2}' where custID = {3}", Convert.ToInt32(Session["ID"]), Session["uname"].ToString(), comment,custID);
                            SqlCommand cmd = new SqlCommand(query, DBconnection);
                            cmd.ExecuteNonQuery();
                        }
                        
                    }
                    else
                    {
                        lit_err.Text = "it was handled by another checker";
                    }
                    
                        BindDataToGridView();
                    lit_err.Text = "";
                }
                catch(Exception exp)
                {
                    lit_err.Text = exp.Message;
                }
            }
            //if(e.CommandName == "")

        }//used to approve, reject or request edit on a certain customer creation request
        protected void cancelEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            gv_CustomerRequests.EditIndex = -1;
            BindDataToGridView();
        }


        public void BindDataToGridView()
        {
            gv_CustomerRequests.DataSource = null;
            gv_CustomerRequests.DataBind();
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
            {
                try
                {
                    DBconnection.Open();
                    SqlCommand gridcmd = new SqlCommand("select custID, name,address,age,nationalID,makerName,status,comments from CUSTOMERS where status in (1 , 5) order by datecreated", DBconnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(gridcmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv_CustomerRequests.DataSource = ds;
                        gv_CustomerRequests.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    lit_err.Text = "error " + ex.Message;
                }
                finally { DBconnection.Close(); DBconnection.Dispose(); }
            }
        }


    }
}