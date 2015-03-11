using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Web.UI.HtmlControls;


namespace Collaboration_LLS.Panel
{
    public partial class Poll : System.Web.UI.Page
    {
        String pid = "";
        String res = "";
        RadioButtonList rbl;
        protected void Page_Load(object sender, EventArgs e)
        {
            pid = Request.QueryString["pollId"];
            res = Request.QueryString["nid"];
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            
            SqlCommand cmd1 = new SqlCommand("Select * from [PollQues] where [PollQues].[PollId]=@creat", con);
            cmd1.Parameters.AddWithValue("@creat", pid);
            //  SqlDataReader reader = cmd1.ExecuteReader();
            SqlDataAdapter dan = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            dan.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                DataRow row = dt1.Rows[0];
                //string PollQues = row["PollQues"].ToString();
                string q = row["PollQues"].ToString();
                String cr = row["Creator"].ToString();
                String r = row["Datetime"].ToString();
                   DateTime dat = Convert.ToDateTime(r);
                    String dateDisp = dat.ToString("dd MMMM, yyyy hh:mm:ss");
                 
                HtmlGenericControl a = new HtmlGenericControl("ul");
                //  HtmlGenericControl b = new HtmlGenericControl("li");
                a.InnerHtml = "<h2>" + q + "</h2><br /> Created by :" + cr + "  </br>   " + "On" + ": " + r;
                ph.Controls.Add(a);
                ph.Controls.Add(new LiteralControl("<br />"));
                

            }
            else
            {

                //     ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }

            
            
            
            SqlCommand cmd = new SqlCommand("Select * from [PollAns] where [PollAns].[PollId]=@crea", con);
            cmd.Parameters.AddWithValue("@crea", pid);
            //  SqlDataReader reader = cmd1.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            
            if (dtt.Rows.Count > 0)
            {
               rbl = new RadioButtonList();
               rbl.Visible = true;
                for(int u=0; u<dtt.Rows.Count; u++)
            {
                DataRow row = dtt.Rows[u];
                //string PollQues = row["PollQues"].ToString();
                string q = row["Answer"].ToString();
                RadioButton button = new RadioButton();
                button.Text = " "+q;
                button.Checked = false;
                button.GroupName = "myButtons";
               // HtmlGenericControl a = new HtmlGenericControl("ul");
                //HtmlGenericControl b = new HtmlGenericControl("li");
                //a.InnerHtml = "<h2>" + q + "</h2><br /> Created by :" + cr + "      " + "On" + ": " + r;
                cntrl.Items.Add(new ListItem(q, u.ToString()));

            }
              
            }

            SqlCommand cmd3 = new SqlCommand("UPDATE [Notifications] SET [Notifications].[read] = 1 where [Notifications].Id=@id ", con);
            cmd3.Parameters.AddWithValue("@id", res);
            cmd3.ExecuteNonQuery();
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String res = cntrl.SelectedItem.Text;
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            c.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [PollAns] SET [PollAns].votes = [PollAns].votes + 1 where [PollAns].Answer=@ans and [PollAns].PollId=@id", c);
            cmd.Parameters.AddWithValue("@ans", res);
            cmd.Parameters.AddWithValue("@id",pid);
            cmd.ExecuteNonQuery();
            //  SqlDataReader reader = cmd1.ExecuteReader();
            Response.Redirect("Dashboard.aspx");            
        }
    }
}