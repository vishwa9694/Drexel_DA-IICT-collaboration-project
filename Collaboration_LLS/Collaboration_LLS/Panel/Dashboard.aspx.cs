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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserName.Text = (string)Session["LLS_FirstName"] + " " + (string)Session["LLS_LastName"];
            imgUser.Src = "../App_Themes/Home/images/" + (string)Session["LLS_ProPic"];
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [User].* FROM [User] WHERE ([User].EmailId = @EmailId)", con);
            cmd.Parameters.AddWithValue("@EmailId", Session["LLS_EmailId"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblPosition.Text = row["Position"].ToString();

            }
        }
    }
}