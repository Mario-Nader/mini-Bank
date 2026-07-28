using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
namespace NBE.Controls
{


    public partial class CTRL_addAccount : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using(var db = new mini_bankEntities())
                {
                    #region filling the drop down lists

                    //var query = from account_look_up in db.accounts_look_up select account_look_up.ClassDescription;
                    var query1 = (from ob in db.accounts_look_up select ob.ClassDescription).ToList();
                    List<String> ClassDespcriptions = query1.ToList();
                    for (int i = 0; i < ClassDespcriptions.Count; i++) {
                        DDL_Class.Items.Add(ClassDespcriptions[i]);
                    }

                    //query = from br in db.branches_look_up select br.branch;
                    var query2 = (from ob in db.branches_look_up select ob.branch).ToList(); ;
                    List<String> Branches = query2.ToList();
                    for (int i = 0; i < Branches.Count; i++) { 
                        DDL_Branch.Items.Add(Branches[i]);
                    }

                    //query = from crr in db.currency_look_up select crr.currencyCode;
                    var query3 = (from crr in db.currency_look_up select crr.currencyCode).ToList();
                    List<String> Currencies = query3.ToList();
                    for (int i = 0; i < Currencies.Count; i++) { 
                        DDL_currency.Items.Add(Currencies[i]);
                    }
                    #endregion
                }
            }
        }

        String uniqueIdentifierGenerator()
        {
            var random = new Random();
            int randomStem = random.Next(0, 99999);;
            String randomStemString = randomStem.ToString();
            while (randomStemString.Length != 5)
            {
                if (randomStemString.Length != 5)
                {
                    randomStemString = random.Next(0, 10).ToString() + randomStemString;
                }
            }
            return randomStemString;
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new mini_bankEntities())
                {
                    var query = from cust in db.CUSTOMERS
                                where cust.CIF == txt_CIF.Text
                                select cust;
                    CUSTOMER customer = query.Single();
                    if (customer == null)
                    {
                        lit_test.Text = "the CIF is not correct";
                    }
                    else
                    {
                        #region getting the User of the customer
                        int custID = customer.custID;
                        var user = db.USERS
                                    .Where(u => u.CustomerID == custID)
                                    .Select(u => new { u.ID, u.active })
                                    .Single();
                        #endregion

                        if (!Convert.ToBoolean(user.active))// checking if the user is active
                        {
                            lit_test.Text = "the user is not active - the user must change his password first -";
                        }
                        else
                        {
                            #region preparing the data that will be put in the record
                            String CIF = txt_CIF.Text;
                            int amount = Convert.ToInt32(txt_Amount.Text);
                            String Branch = DDL_Branch.Text;
                            String Class = DDL_Class.Text;
                            String currency = DDL_currency.Text;

                            String classCode = db.accounts_look_up
                                            .Where(a => a.ClassDescription == Class)
                                            .Select(a => a.code)
                                            .Single();
                            String BranchCode = db.branches_look_up
                                .Where(br => br.branch == Branch)
                                .Select(br => br.flexCode)
                                .Single();
                            int CurrencyID = db.currency_look_up
                                .Where(curr => curr.currencyCode == currency)
                                .Select(curr => curr.currencyID)
                                .Single();
                            String CustomerName = db.CUSTOMERS
                                .Where(c => c.custID == custID)
                                .Select(c => c.Name)
                                .Single();

                            #endregion

                            #region handling the account number
                            bool repeatedUniqueIdentifier = false;
                            String uniqueIdentifier;
                            do
                            {
                                uniqueIdentifier = uniqueIdentifierGenerator();

                                bool sameAccountNumberExist = db.ACCOUNTS.Where(a => a.uniqueIdentifier == uniqueIdentifier).Select(a => a.AccountNumber).Any();
                                if (sameAccountNumberExist == false)
                                {
                                    repeatedUniqueIdentifier = false;
                                }
                                else
                                {
                                    string sameAccountNumber = db.ACCOUNTS.Where(a => a.uniqueIdentifier == uniqueIdentifier).Select(a => a.AccountNumber).Single();
                                    if (sameAccountNumber.Substring(6, 8) == CIF)
                                    {
                                        repeatedUniqueIdentifier = true;
                                    }
                                    else
                                    {
                                        repeatedUniqueIdentifier = false;
                                    }
                                }

                            } while (repeatedUniqueIdentifier);
                            String AccountNumber = BranchCode + classCode + CIF + uniqueIdentifier;
                            #endregion

                            #region creating and adding an account
                            ACCOUNT newAccount = new ACCOUNT();
                            newAccount.AccountNumber = AccountNumber;
                            newAccount.uniqueIdentifier = uniqueIdentifier;
                            newAccount.amount = amount;
                            newAccount.MakerID = Convert.ToInt32(Session["ID"]);
                            newAccount.branch = BranchCode;
                            newAccount.status = 1;
                            newAccount.dateCreated = DateTime.Now;
                            newAccount.currency = CurrencyID;
                            newAccount.classcode = classCode;
                            newAccount.customerID = custID;
                            newAccount.MakerName = Session["uname"].ToString();
                            newAccount.CustomerName = CustomerName;
                            db.ACCOUNTS.Add(newAccount);
                            db.SaveChanges();
                            #endregion

                            lit_test.Text = "the account was added successfully";
                        }
                        txt_Amount.Text = "";
                        txt_CIF.Text = "";
                    }
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
                lit_test.Text = exp.Message;
            }
            }
    }
}