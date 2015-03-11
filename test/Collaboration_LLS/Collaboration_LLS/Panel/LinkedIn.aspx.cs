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
    public partial class LinkedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET [LinkedIn] = @linkedin where [User].[EmailId]=@emailId", con);
            cmd.Parameters.AddWithValue("@linkedin", txtUrl.Value);
            cmd.Parameters.AddWithValue("@emailId", Session["LLS_EmailId"].ToString());
            cmd.ExecuteNonQuery();
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }

}
