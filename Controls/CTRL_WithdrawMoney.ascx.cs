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

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            using (mini_bankEntities db = new mini_bankEntities()) {

                int custID = db.CUSTOMERS
                             .Where(c => c.nationalID == txt_nationalID.Text)
                             .Select(c => c.custID)
                             .Single();

                ACCOUNT account = db.ACCOUNTS
                                  .Where(acc => acc.customerID == custID && acc.AccountNumber == txt_AccountNumber.Text)
                                  .Select(acc => acc)
                                  .Single();
                if (account != null) {
                    ACCOUNT update = new ACCOUNT();
                    update.AccID = account.AccID;
                    db.ACCOUNTS.Attach(update);
                    update.amount = account.amount - Convert.ToInt32(txt_amount.Text);
                    db.SaveChanges();
                }
                else
                {
                    lit_status.Text = "the account does not belong to the user or doesn't exist";
                }
                txt_AccountNumber.Text = "";
                txt_amount.Text = "";
                txt_nationalID.Text = "";
            }
        }
    }
}