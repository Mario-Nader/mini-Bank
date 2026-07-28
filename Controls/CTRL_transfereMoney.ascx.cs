using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public partial class CTRL_transfereMoney : System.Web.UI.UserControl
    {
        private static Dictionary<int, currency_look_up> CurrencyLookup;//using the currencylookup table as a field to avoid quering it every time the account changes
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

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCurrencies();//load currencies if not loaded
            if (!Page.IsPostBack)
            {
                int userID = Convert.ToInt32(Session["ID"]);
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    #region adding the accounts Numbers of the user to the drop down list
                    var custQuery = from u in db.USERS
                                    where u.ID == userID
                                    select u.CustomerID;
                    int customerID = Convert.ToInt32(custQuery.Single());
                    var accountQuery = from acc in db.ACCOUNTS
                                       where acc.customerID == customerID
                                       select acc.AccountNumber;
                    List<string> accountNumbers = accountQuery.ToList();
                    ddl_srcAccount.Items.Add(new ListItem("please select an account", ""));
                    for (int i = 0; i < accountNumbers.Count(); i++)
                    {
                        ddl_srcAccount.Items.Add(accountNumbers[i]);
                    }
                    #endregion
                }
            }
        }

        protected void ddl_srcAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region filling the data of the new selected index
            using (mini_bankEntities db = new mini_bankEntities()) {
                    string accountNumber = ddl_srcAccount.Text;
                if (accountNumber.Length > 0)
                {
                    ACCOUNT account = db.ACCOUNTS
                                .Where(a => a.AccountNumber == accountNumber)
                                .Select(a => a)
                                .Single();
                txt_balance.Text = account.amount.ToString();
                txt_srcCurr.Text = CurrencyLookup[Convert.ToInt32(account.currency)].currencyCode.ToString();
                }
                else
                {
                    txt_balance.Text = "";
                    txt_srcCurr.Text = "";
                    lit_state.Text = "please enter the accounts";
                }

            }
            #endregion
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            using (mini_bankEntities db = new mini_bankEntities()) {
                #region getting the source account
                ACCOUNT srcAcc = db.ACCOUNTS
                                 .Where(acc => acc.AccountNumber == ddl_srcAccount.Text)
                                 .Select(acc => acc)
                                 .Single();
                #endregion

                #region getting Distenation account
                ACCOUNT distAccount = db.ACCOUNTS
                 .Where(acc => acc.AccountNumber == txt_DistAccount.Text)
                 .Select(acc => acc)
                 .Single();
                if (distAccount == null)
                {
                    lit_state.Text = "there is no account with that number";
                }
                #endregion

                else
                {
                    lit_state.Text = "";
                    #region making the transaction, handling exchange rates and attaching accounts to database
                    if (srcAcc.amount <= Convert.ToInt32(txt_amount.Text))
                    {
                        lit_state.Text = "insufficient balance please enter a valid amount to transfere ";
                    }
                    else
                    //{
                    //    ACCOUNT distUpdate = new ACCOUNT();
                    //    ACCOUNT srcUpdate = new ACCOUNT();
                        if (txt_srcCurr.Text == txt_distCurr.Text)
                        {
                            #region same currency logic
                            srcAcc.amount = srcAcc.amount - Convert.ToInt32(txt_amount.Text);
                            distAccount.amount = distAccount.amount + Convert.ToInt32(txt_amount.Text);
                            #endregion
                        }
                        else
                        {
                            #region currency exchange Rate handling
                            double srcToEGP = 1.0;
                            double EGPToDist = 1.0;
                            if (txt_srcCurr.Text != "EGP")
                            {
                                srcToEGP = db.currency_rate_look_up
                                    .Where(rate => rate.FromCur == Convert.ToString(txt_srcCurr.Text) && rate.ToCur == "EGP")
                                    .Select(rate => rate.Rate)
                                    .Single();
                            }
                            if (txt_distCurr.Text != "EGP")
                            {
                                EGPToDist = db.currency_rate_look_up
                                    .Where(rate => rate.FromCur == "EGP" && rate.ToCur == Convert.ToString(txt_distCurr.Text))
                                    .Select(rate => rate.Rate)
                                    .Single();
                            }
                            srcAcc.amount = srcAcc.amount - Convert.ToInt32(txt_amount.Text);
                            double intermediateAmount = Convert.ToInt32(txt_amount.Text) * srcToEGP;
                            intermediateAmount = intermediateAmount * EGPToDist;
                            distAccount.amount = distAccount.amount + (long)intermediateAmount;// this may cause lose of less than 1 of the recipient currency
                            #endregion
                        }

                        #region saving to the database
                        //srcUpdate.AccID = srcAcc.AccID;
                        txt_balance.Text = Convert.ToString(srcAcc.amount);
                        //distAccount.AccID = distAccount.AccID;
                        //db.ACCOUNTS.Attach(srcUpdate);
                        //db.ACCOUNTS.Attach(distUpdate);
                        db.SaveChanges();
                        #endregion
                    }

                    #endregion

                }

                #region resetting distenation fields
                txt_amount.Text = "";
                txt_DistAccount.Text = "";
                txt_distCurr.Text = "";
                txt_ownerName.Text = "";
                #endregion
            }
        

        protected void check_distAcc_Click(object sender, EventArgs e)
        {
            using (mini_bankEntities db = new mini_bankEntities()) {

                #region getting the distnation account
                string distAccountNumber = txt_DistAccount.Text;
                ACCOUNT distAccount = (from acc in db.ACCOUNTS
                                      where acc.AccountNumber == distAccountNumber
                                      select acc).Single() ;
                #endregion

                if (distAccount == null) {
                    lit_state.Text = "there is no account of that number";
                }
                else
                {
                    lit_state.Text = "";
                    #region getting the data and filling the textboxes
                    int custid =Convert.ToInt32(distAccount.customerID);
                    string ownerName = db.CUSTOMERS
                                        .Where(c => c.custID == custid)
                                        .Select(c => c.Name)
                                        .Single();
                    txt_distCurr.Text = CurrencyLookup[Convert.ToInt32(distAccount.currency)].currencyCode;
                    txt_ownerName.Text = ownerName;
                    #endregion
                }
            }
        }
    }
}