using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Collaboration_LLS.Panel
{
    public partial class LockScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Pragma", "no-cache");
            Session["LLS_Locked"] = "True";
            lblUserName.Text = (string)Session["LLS_FirstName"] + " " + (string)Session["LLS_LastName"];
            imgUser.Src = "../App_Themes/Home/images/" + (string)Session["LLS_ProPic"];
        }

       
    }
}