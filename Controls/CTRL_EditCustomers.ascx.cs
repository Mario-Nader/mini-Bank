using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public partial class CTRL_EditCustomers : System.Web.UI.UserControl
    {
        protected void verifyUser()
        {
            if (Session["role"] == null || (Convert.ToInt32(Session["role"]) != 2))
            {
                Session.Clear();
                Response.Redirect("WebForm1.aspx");
            }
        }
        private static Dictionary<int, currency_look_up> CurrencyLookup;//using the currencylookup table as a field to avoid quering it every time the account changes
        private static Dictionary<string, branches_look_up> BranchLookup;
        private void LoadCurrencies() //check if it is loaded and if not it loads it
        {
            if (CurrencyLookup == null)
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    CurrencyLookup = db.currency_look_up
                        .ToDictionary(c => c.currencyID);
                }
            }
        }

        private void loadBranches()
        {
            if (BranchLookup == null) { 
            using (mini_bankEntities db = new mini_bankEntities())
                {
                    BranchLookup = db.branches_look_up.ToDictionary(c => c.flexCode);
                }
            }
        }

        private void loadLookups()
        {
            loadBranches();
            LoadCurrencies();
        }

        public void BindGrid()
        {
            gv_CustomerRequests.DataSource = null;
            gv_CustomerRequests.DataBind();
            try
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    var customers = db.CUSTOMERS
                                    .Where(c => c.status == 4)
                                    .Select(c => c)
                                    .ToList();
                    gv_CustomerRequests.DataSource = customers;
                    gv_CustomerRequests.DataBind();
                }
            }
            catch(Exception ex) 
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            verifyUser();
            loadLookups();
            if (!Page.IsPostBack) {
                BindGrid();
            }
        }

        protected void gvCustomerRequests_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the active row to edit mode using the row index
            gv_CustomerRequests.EditIndex = e.NewEditIndex;
            BindGrid(); // Rebind data to refresh the UI into edit mode
        }

        protected void gvCustomerRequests_RowCancelineEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Reset the edit index back to default (-1 means no row is being edited)
            gv_CustomerRequests.EditIndex = -1;
            BindGrid();
        }

        protected void gvCustomerRequests_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            verifyUser();
            GridViewRow row = gv_CustomerRequests.Rows[e.RowIndex];

            int custID = Convert.ToInt32(gv_CustomerRequests.DataKeys[e.RowIndex].Value);
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
                    log_customers log = new log_customers();
                    log.custID = update.custID;
                    log.MakerID = Convert.ToInt32(Session["ID"]);
                    log.MakerName = Session["uname"].ToString();
                    log.status = 5;
                    db.log_customers.Add(log);
                    //update.comments = txt
                    db.SaveChanges();
                }
                gv_CustomerRequests.EditIndex = -1;
                BindGrid();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex) { 
                foreach(var validationResult in ex.EntityValidationErrors)
                {
                    foreach(var err in validationResult.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine($"Property :{err.PropertyName}, Error :{err.ErrorMessage}");
                    }
                }
            }catch(Exception exp)
            {
                lit_status.Text = exp.Message;
            }
        }




    }
}