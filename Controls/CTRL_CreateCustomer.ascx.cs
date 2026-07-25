using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace NBE.Controls
{
    public partial class CreateCustomer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }
        }

        String CIFgenerator()
        {
            var random = new Random();
            int randomStem = random.Next(0, 99999999);
            //String finalCIF = "";
            String randomStemString = randomStem.ToString();
            while (randomStemString.Length != 8)
            {
                if (randomStemString.Length != 8)
                {
                    randomStemString = random.Next(0, 10).ToString() + randomStemString;
                }
            }
            return randomStemString;
        }

        protected void submit_button_clicked(object sender, EventArgs e)
        {
            if (!(Convert.ToInt32(Session["role"]) == 2))
            {
                Session.Clear();
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                if (txt_nationalD.Text.Length != 14)
                {
                    lit_status.Text = "please enter a valid national ID";
                }
                else
                {
                    try
                    {
                        var connectionFromConfiguration = WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
                        using (SqlConnection DBconnection = new SqlConnection(connectionFromConfiguration))
                        {
                            DBconnection.Open();
                            bool repeatedCIF = false;
                            String CIF;
                            do
                            {
                                CIF = CIFgenerator();
                                String CheckCIFQuery = "Select name from CUSTOMERS where CIF = @CIF";
                                //SqlCommand loginCommand = new SqlCommand(loginQuery, DBconnection);
                                SqlCommand CIFCommand = new SqlCommand(CheckCIFQuery, DBconnection);
                                CIFCommand.Parameters.AddWithValue("@CIF", CIF);
                                SqlDataReader reader = CIFCommand.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    repeatedCIF = true;
                                }
                                reader.Close();
                            } while (repeatedCIF);
                            String InsertCustomerStatment = "insert into Customers (Name, CIF, address, email, age, gender,MakerID,status,nationalID,MakerName,phone) values (@username, @CIF, @address,@email,@age,@gender,@makerID,1,@nationalID,@makerName,@phone)";

                            SqlCommand InserCustomerCmd = new SqlCommand(InsertCustomerStatment, DBconnection);
                            InserCustomerCmd.Parameters.AddWithValue("@username", txt_name.Text);
                            InserCustomerCmd.Parameters.AddWithValue("@phone", txt_phone.Text);
                            InserCustomerCmd.Parameters.AddWithValue("@CIF", CIF);
                            InserCustomerCmd.Parameters.AddWithValue("@address", txt_address.Text);
                            InserCustomerCmd.Parameters.AddWithValue("@email", txt_email.Text);
                            InserCustomerCmd.Parameters.AddWithValue("@age", Convert.ToInt32(txt_age.Text));
                            InserCustomerCmd.Parameters.AddWithValue("@gender", Convert.ToChar(RadioButtonList1.SelectedValue));
                            InserCustomerCmd.Parameters.AddWithValue("@makerID", Session["ID"]);
                            InserCustomerCmd.Parameters.AddWithValue("@nationalID", txt_nationalD.Text);
                            InserCustomerCmd.Parameters.AddWithValue("@makerName", Session["uname"]);
                            int rowsAffected = InserCustomerCmd.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                lit_status.Text = "an error happened please try again later";
                                txt_address.Text = "";
                                txt_age.Text = "";
                                txt_email.Text = "";
                                txt_name.Text = "";
                                txt_nationalD.Text = "";
                                txt_phone.Text = "";
                                RadioButtonList1.ClearSelection();


                            }
                            else
                            {
                                lit_status.Text = "customer creation request was submitted successfully \n the customer will enter with CIF :" + CIF + " and password : NBE@[customer's nationalID]";
                                txt_address.Text = "";
                                txt_age.Text = "";
                                txt_email.Text = "";
                                txt_name.Text = "";
                                txt_nationalD.Text = "";
                                txt_phone.Text = "";
                                RadioButtonList1.ClearSelection();

                            }

                        }
                    }
                    catch (Exception exp)
                    {
                        lit_status.Text = exp.Message;
                    }
                }
            }
        }

        protected void clear_button_clicked(object sender, EventArgs e)
        {
            txt_address.Text = "";
            txt_age.Text = "";
            txt_email.Text = "";
            txt_name.Text = "";
            txt_nationalD.Text = "";
            txt_phone.Text = "";
            RadioButtonList1.ClearSelection();
            lit_status.Text = "";

        }
    }
}