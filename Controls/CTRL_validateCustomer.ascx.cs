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
                        if (reader.Read())
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
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
            {
                try
                {

                    bool StillEditable = true;
                    DBconnection.Open();
                    GridViewRow row = (GridViewRow)gv_CustomerRequests.Rows[Convert.ToInt32(e.CommandArgument)];
                    TextBox custID = (TextBox)row.Cells[0].Controls[0];
                    String checkQuery = String.Format("select status from CUSTOMERS where custID = {0}", Convert.ToInt32(custID.Text));
                    SqlCommand Checkcmd = new SqlCommand(checkQuery, DBconnection);
                    SqlDataReader reader = Checkcmd.ExecuteReader();
                    if (reader.Read()) {
                        if (Convert.ToInt32(reader["status"]) == 0 || Convert.ToInt32(reader["status"]) == 4)
                        {
                            StillEditable = true;
                        }
                        else
                        {
                            StillEditable = false; 
                        }
                    }
                    if (StillEditable)
                    {
                        if (e.CommandName == "approveRow")
                        {
                            String query = String.Format("update CUSTOMERS set status = 1 where custID = {0}", Convert.ToInt32(custID.Text));
                            SqlCommand cmd = new SqlCommand(query, DBconnection);
                            cmd.ExecuteNonQuery();
                        }
                        else if (e.CommandName == "rejectRow")
                        {
                            String query = String.Format("update CUSTOMERS set status = 2 where CustID = {0}", Convert.ToInt32(custID.Text));
                            SqlCommand cmd = new SqlCommand(query, DBconnection);
                            cmd.ExecuteNonQuery();
                        }
                        else if (e.CommandName == "requestEditRow")
                        {
                            String query = String.Format("update CUSTOMERS set status = 3 where custID = {0}", Convert.ToInt32(custID.Text));
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
        protected void cancelEdit(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            gv_CustomerRequests.EditIndex = -1;
            BindDataToGridView();
        }

        protected void CustomerRequests_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        public void BindDataToGridView()
        {
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
            {
                try
                {
                    DBconnection.Open();
                    SqlCommand gridcmd = new SqlCommand("select custID, name,address,age,nationalID,status,comments from CUSTOMERS where status in (0 , 4) order by datecreated", DBconnection);
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

        protected void gv_CustomerRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}