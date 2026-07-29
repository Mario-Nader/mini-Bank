using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public class AccountGridRow
    {
        public int accountID { get; set; }
        public string customerName { get; set; }
        public string makerName { get; set; }
        public System.DateTime dataCreated { get; set; }
        public string currency { get; set; }
        public long initialAmount { get; set; }
        public string branch { get; set; }
        public string AccountClass {  get; set; }
        public string Comment { get; set; }
    }
    public partial class CTRL_ValidateAccounts : System.Web.UI.UserControl
    {

        private Boolean ConcurrencyCheck(int AccID)
        {
            try
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    ACCOUNT updateCheck = db.ACCOUNTS.Where(acc => acc.AccID == AccID).Single();
                    if (updateCheck.workingID == null)
                    {
                        updateCheck.workingID = Convert.ToInt32(Session["ID"]);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        if (updateCheck.workingID != Convert.ToInt32(Session["ID"]))
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        protected void verifyUser()
        {
            if (Session["role"] == null || (Convert.ToInt32(Session["role"]) != 1))
            {
                Session.Clear();
                Response.Redirect("WebForm1.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            verifyUser();
            
            if (!Page.IsPostBack)
            {
                bindData();
            }
        }


        public void bindData()
        {
            gv_accounts.DataSource = null;
            gv_accounts.DataBind();
            using (mini_bankEntities db = new mini_bankEntities()) {

                #region join query
                var query = from acc in db.ACCOUNTS
                            join curr in db.currency_look_up on acc.currency equals curr.currencyID into AccCurr
                            from a in AccCurr
                            join br in db.branches_look_up on acc.branch equals br.flexCode into acb
                            from b in acb
                            join cl in db.accounts_look_up on acc.classcode equals cl.code into acbcl
                            from r in acbcl
                            where acc.status == 1 || acc.status == 5
                            select new AccountGridRow
                            {
                                accountID = acc.AccID,
                                customerName = acc.CustomerName,
                                makerName = acc.MakerName,
                                dataCreated = (System.DateTime)acc.dateCreated,
                                currency = a.currencyCode,
                                initialAmount = acc.amount,
                                branch = b.branch,
                                AccountClass = r.ClassDescription,
                                Comment = acc.Comment
                            };
                #endregion


                var accounts = query.ToList();


                #region binding data to grid view
                if (accounts.Count > 0)
                {
                    gv_accounts.DataSource = accounts;
                    gv_accounts.DataBind();
                }
                else
                {
                    lit_status.Text = "no accounts to be validated";
                }
                #endregion

            }
        }

        public void gvRowCommand(object sender, GridViewCommandEventArgs e)
        {
            verifyUser();
            try
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    #region getting the account id from the selected row
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    int AccID = Convert.ToInt32(gv_accounts.DataKeys[rowIndex].Value);
                    #endregion

                    #region check status if editable
                    bool editable = db.ACCOUNTS
                        .Where(a => a.AccID == AccID && (a.status == 1 || a.status == 5))
                        .Any();
                    #endregion
                    bool available = ConcurrencyCheck(AccID);
                    #region making updates according to the button pressed
                    if (!editable)
                    {
                        lit_status.Text = "another checker already handled this request";
                    }else if (!available)
                    {
                        lit_status.Text= "another checker is handling this request";
                    }
                    else
                    {
                        ACCOUNT update = db.ACCOUNTS.Where(a => a.AccID == AccID).Select(a => a).Single();
                        log_accounts log = new log_accounts();
                        log.AccID = update.AccID;
                        log.custID = Convert.ToInt32(update.customerID);
                        log.CheckerID = Convert.ToInt32(Session["ID"]);
                        log.branchCode = update.branch;
                        log.CheckerName = Session["uname"].ToString();
                        log.Date = DateTime.Now;
                        if (e.CommandName == "approveRow")
                        {
                            //var query = db.ACCOUNTS;
                            //db.Entry(update).Property(a=>a.status).IsModified = true;
                            log.status = 2;
                            update.status = 2;

                        }
                        else if (e.CommandName == "rejectRow")
                        {
                            update.status = 3;
                            log.status = 3;
                            //db.Entry(update).Property(a => a.status).IsModified = true;

                        }
                        else if (e.CommandName == "requestEditRow")
                        {
                            log.status = 4;
                            update.status = 4;
                            GridViewRow row = (GridViewRow)gv_accounts.Rows[rowIndex];
                            TextBox TXTcomment = (TextBox)row.FindControl("txt_comment");
                            String comment = "";
                            if (TXTcomment != null)
                            {
                                comment = TXTcomment.Text;
                            }
                            update.Comment = comment;
                            //db.Entry(update).Property(a => a.status).IsModified = true;
                            //db.Entry(update).Property(a => a.Comment).IsModified = true;
                        }
                        update.CheckerName = Session["uname"].ToString();
                        update.CheckerID = Convert.ToInt32(Session["ID"]);
                        db.log_accounts.Add(log);
                        db.SaveChanges();
                    }
                        bindData();
                    #endregion
                }
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
                lit_status.Text = exp.Message;
            }
        }


    }
}