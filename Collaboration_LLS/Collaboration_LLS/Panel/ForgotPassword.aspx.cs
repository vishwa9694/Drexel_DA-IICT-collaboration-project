
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;


namespace Collaboration_LLS.Panel
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPwd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [User] where [User].[EmailId]=@username", con);
            cmd.Parameters.AddWithValue("@username", email.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Generating Verification Code
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var result = new string(
                    Enumerable.Repeat(chars, 8)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());

                //Saving the code in password field

                SqlCommand upd = new SqlCommand("UPDATE [User] SET [Password] = @pwd where [User].[EmailId]=@username");
                upd.Connection = con;
                upd.Parameters.AddWithValue("@pwd", result);

                upd.Parameters.AddWithValue("@username", email.Value);
                upd.ExecuteNonQuery();

                //Sending email
                string to = "aditi24.bhatnagar@gmail.com";
                string sub = "Password reset verification code | LLS ";
                string body = "Hi ! Here is the password verification code:" + result + "\n Reset your password and get back access to your account! \n Hap";
                string res = SendEmail(to, sub, body);


                //Reset Password
                Response.Redirect("ResetPassword.aspx");



            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Entered email id is not registered!')</script>");
            }
        }


        protected string SendEmail(string toAddress, string subject, string body)
        {

            string result = "Failed!";
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("noreply.llsorganization@gmail.com", "daxiladitivishwa");
                client.UseDefaultCredentials = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;


                client.Send("noreply.llsorganization@gmail.com", "aditi24.bhatnagar@gmail.com", subject, body);
                Console.WriteLine("Sent");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
            }
            return result;
        }

    }

}