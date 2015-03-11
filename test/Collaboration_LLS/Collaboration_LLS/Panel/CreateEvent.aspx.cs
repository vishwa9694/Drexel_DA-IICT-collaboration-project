using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
namespace Collaboration_LLS.Panel
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btCreateEvent_Click(object sender, EventArgs e)
        {
            //String start = Convert.ToDateTime(StartDate, System.Globalization.CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");
            //String end = Convert.ToDateTime(EndDate, System.Globalization.CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");
            ArrayList emails = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand fetch_emails = new SqlCommand("Select [EmailId] from [User] Where [User].EmailId NOT IN (@EmailId)", con);
            fetch_emails.Parameters.AddWithValue("@EmailId", (string)Session["LLS_EmailId"]);
            SqlDataAdapter da2 = new SqlDataAdapter(fetch_emails);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
               
                using (SqlDataReader oReader = fetch_emails.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        String email = oReader["EmailId"].ToString();
                        emails.Add(email);

                    }

                }
            }
            DateTime saveNow = DateTime.Now;
            foreach(String str in emails)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Notifications] ([Type], [Creator], [SendTime], [read], [Receiver]) VALUES (@type, @creator, @timedate, @read, @receiver)", con);
                cmd.Parameters.AddWithValue("@type", "sharedevent");
                cmd.Parameters.AddWithValue("@creator", Session["LLS_FirstName"].ToString() + " " + Session["LLS_LastName"].ToString());
                cmd.Parameters.AddWithValue("@timedate", saveNow);
                cmd.Parameters.AddWithValue("@read", 0);
                cmd.Parameters.AddWithValue("@receiver",str);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("select id from [Notifications] where [Creator] = @creator AND [SendTime] = @timedate AND [Receiver] = @receiver", con);
                cmd2.Parameters.AddWithValue("@creator", Session["LLS_FirstName"].ToString() + " " + Session["LLS_LastName"].ToString());
                cmd2.Parameters.AddWithValue("@timedate", saveNow);
                cmd2.Parameters.AddWithValue("@receiver", str);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    String i;
                    int id = 0;
                    using (SqlDataReader oReader = cmd2.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            i = oReader["Id"].ToString();
                            id = int.Parse(i);
                        }
                    }

                    SqlCommand cmd3 = new SqlCommand("insert into [SharedEvents] ([Name], [Description], [StartDate], [EndDate], [CreationTime], [NotificationId], [Creator], [Receiver]) values (@name, @desc, @start, @end, @creation, @notification, @creator, @receiver)", con);
                    cmd3.Parameters.AddWithValue("@name", txtEventName.Value);
                    cmd3.Parameters.AddWithValue("@desc", EventDesc.Value);
                    cmd3.Parameters.AddWithValue("@start", StartDate.Value);
                    cmd3.Parameters.AddWithValue("@end", EndDate.Value);
                    cmd3.Parameters.AddWithValue("@creation", saveNow);
                    cmd3.Parameters.AddWithValue("@notification", id);
                    cmd3.Parameters.AddWithValue("@creator", Session["LLS_FirstName"].ToString() + " " + Session["LLS_LastName"].ToString());
                    cmd3.Parameters.AddWithValue("@receiver", str);
                    cmd3.ExecuteNonQuery();
                }
            } 
            SqlCommand cmd4 = new SqlCommand("select [EmailId] from [User]", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd4);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                ArrayList list = new ArrayList();
                using (SqlDataReader oReader = cmd4.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        String email = oReader["EmailId"].ToString();
                        list.Add(email);
                            
                    }

                }
                foreach (string s in list)
                {
                    SqlCommand cmd5 = new SqlCommand("insert into [Events] ([name], [emailId], [eventstart], [eventend]) values (@name, @email, @start, @end)", con);
                    cmd5.Parameters.AddWithValue("@name", txtEventName.Value);
                    cmd5.Parameters.AddWithValue("@email", s);
                    cmd5.Parameters.AddWithValue("@start", StartDate.Value);
                    cmd5.Parameters.AddWithValue("@end", EndDate.Value);
                    cmd5.ExecuteNonQuery();
                }
            }
            Response.Redirect("Dashboard.aspx");
           
        }

    }
}