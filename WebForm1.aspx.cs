using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.ComponentModel.Design;

namespace NBE
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                int role = Convert.ToInt32(Session["role"]);
                if (role == 3)
                {
                    Response.Redirect("Home.aspx");
                }
                else if (role == 2)
                {
                    Response.Redirect("makeCustomer.aspx");
                }
                else if (role == 1)
                {
                    //we will redirect the checker 
                    Response.Redirect("ValidateCustomer.aspx");
                }
            }
        }

        protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            //using query

            //Response.Redirect("Home.aspx?uname=" + txt_username.Text);
            var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
            {
                    DBconnection.Open();
                    String loginQuery = "select Name, Role,ID ,active from USERS where name = @username and password = @password";
                    SqlCommand loginCommand = new SqlCommand(loginQuery, DBconnection);
                    loginCommand.Parameters.AddWithValue("@username", txt_username.Text);//use CIF instead of the username
                    loginCommand.Parameters.AddWithValue("@password",txt_pwd.Text);
                    //DBliteral.Text = connectionFromConfiguration.ToString();
                    SqlDataReader reader = loginCommand.ExecuteReader();
                int role = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    role = Convert.ToInt32(reader["role"]);
                }
                try
                {
                    if (reader.HasRows)
                    {
                        DBliteral.Text = "logged in successfully";
                        Session.Add("uname", txt_username.Text);
                        Session.Add("ID", Convert.ToInt32(reader["ID"]));
                        Session.Add("Role", role);
                        bool active = Convert.ToBoolean(reader["active"]);
                        Session.Add("active",Convert.ToBoolean(reader["active"]));
                        int id = Convert.ToInt32(reader["ID"]);
                        reader.Close();
                        if (role == 3)
                        {
                            if (!Convert.ToBoolean(Session["active"]))
                            {
                                Response.Redirect("CustomerChangePassword.aspx");
                            }
                            else
                            {
                                Response.Redirect("TransfereMoney.aspx");
                            }
                        }
                        else if(role == 2)
                        {
                            Response.Redirect("makeCustomer.aspx");
                        }else if(role == 1)
                        {
                            //we will redirect the checker 
                            Response.Redirect("ValidateCustomer.aspx");
                        }
                    }
                    else
                    {
                        DBliteral.Text = "invalid username or password";
                    }

                }
                catch (Exception ex)
                {
                    DBliteral.Text = ex.Message;
                }
            }

        }
    

        //using session


        protected void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

    }
}