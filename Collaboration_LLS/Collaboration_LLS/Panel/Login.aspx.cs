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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((string)Session["LLS_EmailId"]) == false)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET [online] = @online where [User].[EmailId]=@emailid", con);
                cmd.Parameters.AddWithValue("@online", "False");
                cmd.Parameters.AddWithValue("@emailid", (string)Session["LLS_EmailId"]);
                cmd.ExecuteNonQuery();

                Session.Remove("LLS_FirstName");
                Session.Remove("LLS_LastName");
                Session.Remove("LLS_EmailId");
                Session.Remove("LLS_ProPic");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [User] where [User].[EmailId]=@username and [User].[Password]=@password", con);
            cmd.Parameters.AddWithValue("@username", email.Value);
            cmd.Parameters.AddWithValue("@password", password.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string fname = row["FirstName"].ToString();
                string lname = row["LastName"].ToString();
                string emailid = row["EmailId"].ToString();
                string propic = row["ProfilePic"].ToString();
                Session["LLS_FirstName"] = fname;
                Session["LLS_LastName"] = lname;
                Session["LLS_EmailId"] = emailid;
                Session["LLS_ProPic"] = propic;
                Session["LLS_Locked"] = "False";
                Session.Timeout = 99999;
                SqlCommand upd = new SqlCommand("Update [User] SET online=1  where [User].[EmailId]=@username");
                upd.Parameters.AddWithValue("@username", email.Value);
                upd.Connection = con;
                upd.ExecuteNonQuery();
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
        }


    }

}