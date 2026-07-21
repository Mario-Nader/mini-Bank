using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE
{
    public partial class mainSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                
            }
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                Session.Clear();
            }
            Response.Redirect("WebForm1.aspx");
        }
    }
}