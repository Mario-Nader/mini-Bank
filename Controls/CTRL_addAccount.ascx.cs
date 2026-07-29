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
            if (!Page.IsPostBack)
            {
                using(var db = new mini_bankEntities())
                {
                    #region filling the drop down lists

                    //var query = from account_look_up in db.accounts_look_up select account_look_up.ClassDescription;
                    var query1 = (from ob in db.accounts_look_up select ob.ClassDescription).ToList();
                    List<String> ClassDespcriptions = query1.ToList();
                    DDL_Class.Items.Add(new ListItem("--- select ---", ""));
                    for (int i = 0; i < ClassDespcriptions.Count; i++) {
                        DDL_Class.Items.Add(ClassDespcriptions[i]);
                    }

                    //query = from br in db.branches_look_up select br.branch;
                    var query2 = (from ob in db.branches_look_up select ob.branch).ToList(); ;
                    List<String> Branches = query2.ToList();
                    DDL_Branch.Items.Add(new ListItem("--- select ---", ""));
                    for (int i = 0; i < Branches.Count; i++) { 
                        DDL_Branch.Items.Add(Branches[i]);
                    }
                    //query = from crr in db.currency_look_up select crr.currencyCode;
                    var query3 = (from crr in db.currency_look_up select crr.currencyCode).ToList();
                    List<String> Currencies = query3.ToList();
                    DDL_currency.Items.Add(new ListItem("--- select ---", ""));
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
            verifyUser();
            try
            {
                using (var db = new mini_bankEntities())
                {
                    
                    string nationalID = txt_NationalID.Text;
                    var query = from cust in db.CUSTOMERS
                                where cust.nationalID == nationalID
                                select cust;
                    CUSTOMER customer = query.Single();
                    
                    if (customer == null)
                    {
                        lit_test.Text = "the nationalID is not correct or is not of an NBE customer ";
                    }
                    else
                    {
                        
                        #region getting the User of the customer
                        USER user = db.USERS.Where(usr => usr.CustomerID == customer.custID).Select(usr => usr).Single();
                        int custID = customer.custID;
                        if (!Convert.ToBoolean(user.active))
                        {
                            lit_test.Text = "the user is not active please ask the customer to change his/her password if they didn't already";
                            return;
                        }
                        #endregion

                        if (!Convert.ToBoolean(user.active))// checking if the user is active
                        {
                            lit_test.Text = "the user is not active - the user must change his password first -";
                        }
                        else
                        {
                           

                            #region preparing the data that will be put in the record
                            String CIF = customer.CIF;
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
                            int AccID = db.ACCOUNTS.Where(acc => acc.AccountNumber == AccountNumber).Select(acc => acc.AccID).Single();
                            log_accounts log = new log_accounts();
                            log.branchCode = BranchCode;
                            log.status = 1;
                            log.MakerName = Session["uname"].ToString();
                            log.MakerID = Convert.ToInt32(Session["ID"]);
                            log.custID = custID;
                            log.AccID = AccID;
                            log.Date = DateTime.Now;
                            db.log_accounts.Add(log);
                            db.SaveChanges();
                            #endregion

                            lit_test.Text = "the account was added successfully";
                        }
                        txt_Amount.Text = "";
                        txt_NationalID.Text = "";
                        DDL_Branch.SelectedIndex = 0;
                        DDL_Class.SelectedIndex = 0;
                        DDL_currency.SelectedIndex = 0;
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