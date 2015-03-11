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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [User] where [User].[Password]=@password", con);
            cmd.Parameters.AddWithValue("@password", oldPassword.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (newPass.Value == ConfirmPass.Value)
                {
                    cmd = new SqlCommand("UPDATE [User] SET [Password] = @newPassword where [User].[EmailId]=@emailId", con);
                    cmd.Parameters.AddWithValue("@newpassword", newPass.Value);
                    cmd.Parameters.AddWithValue("@emailId", Session["LLS_EmailId"].ToString());
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Password doesnot match.')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Wrong verification code entered.')</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}