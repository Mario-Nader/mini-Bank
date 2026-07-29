using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE.Controls
{
    public partial class depositeMoney : System.Web.UI.UserControl
    {
        protected void verifyUser()
        {
            if (Session["role"] == null || (Convert.ToInt32(Session["role"]) != 2))
            {
                Session.Clear();
                Response.Redirect("WebForm1.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            verifyUser();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            verifyUser();
            SingleSideTransactions_log log = new SingleSideTransactions_log();
            if (txt_AccountNumber.Text == "" || txt_amount.Text == "")
            {
                lit_status.Text = "write your data";
            }
            else
            {
                lit_status.Text = "";
                try
                {
                    using (mini_bankEntities db = new mini_bankEntities())
                    {
                        string accountNumber = txt_AccountNumber.Text;
                        ACCOUNT account = db.ACCOUNTS
                                          .Where(a => a.AccountNumber == accountNumber)
                                          .Select(a => a)
                                          .Single();
                        if (account == null)
                        {
                            lit_status.Text = "there is no account with that number";
                        }
                        else
                        {
                            //ACCOUNT update = new ACCOUNT();
                            //update.amount += Convert.ToInt32(txt_amount.Text);
                            //update.AccID = account.AccID;
                            //db.ACCOUNTS.Attach(update);
                            log.dateCreated = DateTime.Now;
                            log.amount = Convert.ToInt32(txt_amount.Text);
                            log.AccountNumber = account.AccountNumber;
                            int custID = Convert.ToInt32(account.customerID);
                            string name = db.CUSTOMERS.Where(cust => cust.custID == custID).Select(c => c.Name).Single();
                            log.customerName = name;
                            log.Deposite = true;
                            account.amount += Convert.ToInt32(txt_amount.Text);
                            db.SingleSideTransactions_log.Add(log);
                            db.SaveChanges();
                            txt_amount.Text = "";
                            txt_AccountNumber.Text = "";
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
}