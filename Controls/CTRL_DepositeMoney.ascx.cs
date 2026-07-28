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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txt_AccountNumber.Text == "" || txt_amount.Text == "")
            {
                lit_status.Text = "write your data";
            }
            else
            {
                using (mini_bankEntities db = new mini_bankEntities())
                {
                    ACCOUNT account = db.ACCOUNTS
                                      .Where(a => a.AccountNumber == txt_AccountNumber.Text)
                                      .Select(a => a)
                                      .Single();
                    if (account == null)
                    {
                        lit_status.Text = "there is no account with that number";
                    }
                    else
                    {
                        ACCOUNT update = new ACCOUNT();
                        update.amount += Convert.ToInt32(txt_amount.Text);
                        update.AccID = account.AccID;
                        db.ACCOUNTS.Attach(update);
                        db.SaveChanges();
                        txt_amount.Text = "";
                        txt_AccountNumber.Text = "";
                    }
                }
            }
        }
    }
}