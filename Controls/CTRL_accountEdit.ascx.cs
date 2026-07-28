using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public partial class CTRL_accountEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindGrid()
        {
            
            gv_AccountRequests.DataSource = null;
            gv_AccountRequests.DataBind();
            try
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    var accounts = db.ACCOUNTS
                                    .Where(c => c.status == 4)
                                    .Select(c => c)
                                    .ToList();

                    gv_AccountRequests.DataSource = accounts;
                    gv_AccountRequests.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        protected void gvAccountRequests_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the active row to edit mode using the row index
            gv_AccountRequests.EditIndex = e.NewEditIndex;
            BindGrid(); // Rebind data to refresh the UI into edit mode
        }

        protected void gvAccountRequests_RowCancelineEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Reset the edit index back to default (-1 means no row is being edited)
            gv_AccountRequests.EditIndex = -1;
            BindGrid();
        }

        protected void gvAccountRequests_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gv_AccountRequests.Rows[e.RowIndex];

            int custID = Convert.ToInt32(gv_AccountRequests.DataKeys[e.RowIndex].Value);
            try
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    CUSTOMER update = new CUSTOMER();
                    update.custID = custID;
                    db.CUSTOMERS.Attach(update);
                    TextBox txt_name = (TextBox)row.FindControl("txt_name");
                    TextBox txt_nationalID = (TextBox)row.FindControl("txt_nationalID");
                    TextBox txt_address = (TextBox)row.FindControl("txt_address");
                    TextBox txt_age = (TextBox)row.FindControl("txt_age");
                    TextBox txt_comment = (TextBox)row.FindControl("txt_comment");
                    string name = txt_name.Text;
                    string nationalID = txt_nationalID.Text;
                    string address = txt_address.Text;
                    int age = Convert.ToInt32(txt_age.Text);
                    update.Name = name;
                    update.nationalID = nationalID;
                    update.address = address;
                    update.age = age;
                    update.MakerName = Session["uname"].ToString();
                    update.MakerID = Convert.ToInt32(Session["ID"]);
                    update.status = 5;
                    update.comments = txt_comment.Text;
                    //update.comments = txt
                    db.SaveChanges();
                }
                gv_AccountRequests.EditIndex = -1;
                BindGrid();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationResult in ex.EntityValidationErrors)
                {
                    foreach (var err in validationResult.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine($"Property :{err.PropertyName}, Error :{err.ErrorMessage}");
                    }
                }
            }
            catch (Exception exp)
            {
            }
        }

    }
}