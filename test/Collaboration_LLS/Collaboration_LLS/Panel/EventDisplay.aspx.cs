using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collaboration_LLS.Panel
{
    public partial class EventDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String str = Request.QueryString["Id"].ToString();
            int id = int.Parse(str);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [SharedEvents] where [NotificationId] = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lbleventname.Text = row["Name"].ToString();
                lblcreator.Text = row["Creator"].ToString();
                lbleventdesc.Text = row["Description"].ToString();
                lblstartdate.Text = row["StartDate"].ToString();
                lblenddate.Text = row["EndDate"].ToString();
                lblcreatetime.Text = row["CreationTime"].ToString();
            }
            SqlCommand cmd2 = new SqlCommand("update [Notifications] set [read] = 1 where Id = @id", con);
            cmd2.Parameters.AddWithValue("@id", id);
            cmd2.ExecuteNonQuery();
        }
    }
}