using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collaboration_LLS.Panel
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(Session["LLS_EmailId"].ToString())==true)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}