using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace NBE.Controls
{
    public partial class CTRL_EditAccounts : System.Web.UI.UserControl
    {
        public class AccountGridRow
        {
            public int AccID { get; set; }
            public int currencyID { get; set; }
            public string customerName { get; set; }
            public string currency { get; set; }
            public long initialAmount { get; set; }
            public string branch { get; set; }
            public string branchCode { get; set; }
            public string AccountClass { get; set; }
            public string classCode { get; set; }
            public string Comment { get; set; }
        }


        private static Dictionary<int, currency_look_up> CurrencyLookup;
        private static Dictionary<string, branches_look_up> BranchLookup;
        private static Dictionary<string, accounts_look_up> ClassLookup;
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
            if (BranchLookup == null)
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    BranchLookup = db.branches_look_up.ToDictionary(c => c.flexCode);
                }
            }
        }

        private void loadClasses()
        {
            if(ClassLookup == null)
            {
                using(mini_bankEntities db = new mini_bankEntities())
                {
                    ClassLookup = db.accounts_look_up.ToDictionary(cl => cl.code);
                }
            }
        }
        private void loadLookups()
        {
            loadBranches();
            LoadCurrencies();
            loadClasses();
        }


        public void bindData()
        {
            gvAccountRequests.DataSource = null;
            gvAccountRequests.DataBind();
            using (mini_bankEntities db = new mini_bankEntities())
            {
                var accList = (from tab in db.ACCOUNTS where tab.status == 4 select tab).ToList();

                List<AccountGridRow> AccountGridList = new List<AccountGridRow>();
                if (accList.Count >  0 )
                {
                    foreach (var item in accList)
                    {
                        AccountGridRow accGrdRow = new AccountGridRow();
                        accGrdRow.currency = CurrencyLookup[Convert.ToInt32(item.currency)].currencyCode;
                        accGrdRow.AccID = item.AccID;
                        accGrdRow.currencyID =Convert.ToInt32(item.currency);
                        accGrdRow.Comment = item.Comment;
                        accGrdRow.branch = BranchLookup[item.branch].branch;
                        accGrdRow.customerName = item.CustomerName;
                        accGrdRow.AccountClass = ClassLookup[item.classcode].ClassDescription;
                        accGrdRow.initialAmount = item.amount;
                        accGrdRow.branchCode = item.branch;
                        accGrdRow.classCode= item.classcode;
                        AccountGridList.Add(accGrdRow);
                    }
                }

                gvAccountRequests.DataSource = AccountGridList;
                gvAccountRequests.DataBind();
            }
        }
        protected void gvAccountRequests_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the active row to edit mode using the row index
            gvAccountRequests.EditIndex = e.NewEditIndex;
            bindData(); // Rebind data to refresh the UI into edit mode
        }

        protected void gvAccountRequests_RowCancelineEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Reset the edit index back to default (-1 means no row is being edited)
            gvAccountRequests.EditIndex = -1;
            bindData();
        }
        public void gvRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0) 
            {
                DropDownList ddl_currency = (DropDownList)e.Row.FindControl("ddl_currency");
                DropDownList ddl_branch = (DropDownList)e.Row.FindControl("ddl_branch");
                DropDownList ddl_class = (DropDownList)e.Row.FindControl("ddl_class");
                
                //HiddenField hf = (HiddenField)e.Row.FindControl("hf_currency");

                AccountGridRow row = (AccountGridRow)e.Row.DataItem;
                if(ddl_currency != null)
                {
                    ddl_currency.DataSource = CurrencyLookup.Values;
                    ddl_currency.DataTextField = "currencyCode";
                    ddl_currency.DataValueField = "currencyID";
                    ddl_currency.DataBind();
                    ddl_currency.SelectedValue = row.currencyID.ToString();
                }
                if (ddl_branch != null) 
                { 
                    ddl_branch.DataSource = BranchLookup.Values;
                    ddl_branch.DataTextField = "branch";
                    ddl_branch.DataValueField = "flexCode";
                    ddl_branch.DataBind();
                    ddl_currency.SelectedValue = row.branchCode.ToString();
                }
                if(ddl_class != null)
                {
                    ddl_class.DataSource = ClassLookup.Values;
                    ddl_class.DataTextField = "ClassDescription";
                    ddl_class.DataValueField = "code";
                    ddl_class.DataBind();
                    ddl_class.SelectedValue = row.classCode.ToString();
                }
            }
        }


        protected void gvAccountRequests_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvAccountRequests.Rows[e.RowIndex];

            int AccID = Convert.ToInt32(gvAccountRequests.DataKeys[e.RowIndex].Value);
            try
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    #region taking input form the row to the data object
                    ACCOUNT update = db.ACCOUNTS.Where(acc => acc.AccID == AccID).Single();
                    TextBox txt_custName = (TextBox)row.FindControl("txt_name");
                    DropDownList ddl_curr = (DropDownList)row.FindControl("ddl_currency");
                    TextBox txt_amount = (TextBox)row.FindControl("txt_amount");
                    //TextBox txt_branch = (TextBox)row.FindControl("txt_branch");
                    //TextBox txt_class = (TextBox)row.FindControl("txt_class");
                    TextBox txt_comment = (TextBox)row.FindControl("txt_commentEdited");
                    DropDownList ddl_branch = (DropDownList)row.FindControl("ddl_branch");
                    DropDownList ddl_class = (DropDownList)row.FindControl("ddl_class");
                    update.CustomerName = txt_custName.Text;
                    update.currency = Convert.ToInt32(ddl_curr.SelectedValue);
                    update.amount = Convert.ToInt32(txt_amount.Text);
                    update.branch = ddl_branch.SelectedValue.ToString();
                    update.classcode = ddl_class.SelectedValue.ToString();
                    update.Comment = txt_comment.Text;
                    string oldAccountNumber = update.AccountNumber.ToString();
                    string CIF = oldAccountNumber.Substring(6, 8);
                    update.AccountNumber = update.branch.ToString() + update.classcode.ToString() + CIF + update.uniqueIdentifier.ToString();
                    update.status = 5;
                    update.MakerName = Session["uname"].ToString();
                    update.MakerID = Convert.ToInt32(Session["ID"]);
                    log_accounts log = new log_accounts();
                    log.AccID = update.AccID;
                    log.custID = Convert.ToInt32(update.customerID);
                    log.MakerID = Convert.ToInt32(Session["ID"]);
                    log.MakerName = Session["uname"].ToString();
                    log.branchCode = update.branch;
                    log.status = 5;
                    log.Date = DateTime.Now;
                    db.log_accounts.Add(log);
                    #endregion

                    db.SaveChanges();
                }
                gvAccountRequests.EditIndex = -1;
                bindData();
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
                lit_err.Text = exp.Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            loadLookups();
            if (!Page.IsPostBack)
            {
            bindData();
            }
        }

        protected void gvAccountRequestsRowCommand()
        {

        }
    }
}