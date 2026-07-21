using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBE
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //using query
                //String username = Request.QueryString["username"].ToString();
                //if (Request.QueryString["username"] != null)
                //{
                //    lbl_welcome.Text = "welcome " + Request.QueryString["uname"].ToString();
                //}

                //using session
                if (Session["uname"].ToString() != null){
                    lbl_welcome.Text = "welcome " + Session["uname"].ToString();
                }
                 
            }

        }
    }
}