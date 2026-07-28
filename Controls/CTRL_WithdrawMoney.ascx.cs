using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public partial class CTRL_WithdrawMoney : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                ddl_AccountNumbers.Items.Add(new ListItem("-- Submit a National ID --", ""));
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            using (mini_bankEntities db = new mini_bankEntities()) {

                string accountNumber = ddl_AccountNumbers.SelectedValue.ToString();
                ACCOUNT account = db.ACCOUNTS
                                  .Where(acc => acc.AccountNumber == accountNumber)
                                  .Select(acc => acc)
                                  .Single();
                if (account != null) {
                    if (txt_amount.Text.Length == 0)
                    {
                        lit_status.Text = "enter an amount";
                    }
                    else
                    {
                        if (account.amount >= Convert.ToInt32(txt_amount.Text))
                        {
                            account.amount = account.amount - Convert.ToInt32(txt_amount.Text);
                            db.SaveChanges();
                        }
                        else
                        {
                            lit_status.Text = "insufficient balance";
                        }
                    }
                }
                else
                {
                    lit_status.Text = "the account does not belong to the user or doesn't exist";
                }
                txt_amount.Text = "";
                txt_nationalID.Text = "";
                ddl_AccountNumbers.Items.Clear();
                ddl_AccountNumbers.Items.Add(new ListItem("-- Submit a National ID --", ""));
            }
        }


        protected void get_Accounts_Click(object sender, EventArgs e)
        {
            try
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    int custID = db.CUSTOMERS
                                 .Where(c => c.nationalID == txt_nationalID.Text)
                                 .Select(c => c.custID)
                                 .Single();
                    var accounts = db.ACCOUNTS
                                   .Where(acc => acc.customerID == custID)
                                   .Select(acc => acc.AccountNumber)
                                   .ToList();
                    ddl_AccountNumbers.Items.Clear();
                    foreach (var acc in accounts)
                    {
                        ddl_AccountNumbers.Items.Add(acc);
                    }

                }
            }
            catch(Exception exp)
            {
                lit_status.Text = exp.Message;
            }
        }
    }
}