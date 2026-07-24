using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public partial class ChangePassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                
            }
        }

        protected void btn_submitPWD_Click(object sender, EventArgs e)
        {
            lit_err.Text = "";
            if (txt_NewPassword.Text != txt_passwordConfirmation.Text)
            {
                lit_err.Text = "please enter the same password in both fields";
            }
            try
            {
                var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
                using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
                { //change password in users
                    DBconnection.Open();
                    String UpdateQuery = "update USERS set password = @password , active = 1 where ID = @id";
                    int ID = Convert.ToInt32(Session["id"]);
                    String Password = txt_NewPassword.Text;
                    SqlCommand cmd = new SqlCommand(UpdateQuery, DBconnection);
                    cmd.Parameters.AddWithValue("@password",Password);
                    cmd.Parameters.AddWithValue("@id",ID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lit_err.Text = "the password was changed successfully";
                    }
                    DBconnection.Close();
                    DBconnection.Dispose();
                }
                Response.Redirect("~/Home.aspx");
            }
            catch (Exception exp)
            {
                lit_err.Text = exp.Message;
            }

        }
    }
}

