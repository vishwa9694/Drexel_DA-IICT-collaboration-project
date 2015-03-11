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
    public partial class PollAns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idf = Request.QueryString["id"];
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from [PollQues] where [PollQues].[PollId]=@creat", con);
            cmd1.Parameters.AddWithValue("@creat", idf);
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
                a.InnerHtml = "<h2>" + q + "</h2><br /><h5> Created by : " + cr + " <br/> On" + ": " + dateDisp + "</h5> <br> <br>";
                Form1.Controls.Add(a);

            }
            else
            {

                //     ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }




            SqlCommand cmd = new SqlCommand("Select * from [PollAns] where [PollAns].[PollId]=@creato", con);
            SqlCommand cmdSum = new SqlCommand("Select sum([votes]) as Sum from [PollAns] where PollId=@PollId", con);
            cmd.Parameters.AddWithValue("@creato", idf);
            cmdSum.Parameters.AddWithValue("@PollId", idf);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataAdapter daSum = new SqlDataAdapter(cmdSum);
            DataTable dtSum = new DataTable();
            daSum.Fill(dtSum);
            int sumVote = 0;
            if (dtSum.Rows.Count > 0)
            {
                DataRow row = dtSum.Rows[0];
                sumVote = int.Parse(row["Sum"].ToString());
            }

            if (dt.Rows.Count > 0)
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    DataRow row = dt.Rows[k];
                    //string PollQues = row["PollQues"].ToString();
                    string ans = row["Answer"].ToString();
                    string vote = row["votes"].ToString();
                    btnAddinRow_Click(ans, vote, sumVote, k);
                }
            }
            else
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('No options provided!')</script>");
            }

        }

        protected void btnAddinRow_Click(String ans, String vote, int Sum, int cnt)
        {
            int modVal = cnt % 5;
            HtmlGenericControl a = new HtmlGenericControl("ul");
            HtmlGenericControl b = new HtmlGenericControl("li");
            //b.InnerHtml = "<h4> " + ans + " : " + vote + " </h4>";
            int val=0;
            if(Sum==0)
               val=0;
            else
               val = 100 * int.Parse(vote) / Sum;
            if (modVal == 0)
                b.InnerHtml = "<strong> " + ans + " : " + vote + "</strong> <div class='progress progress-xs'><div class='progress-bar' role='progressbar' aria-valuenow='0' aria-valuemin='0' aria-valuemax='100' style=width:" + val + "%;'>  </div>  </div> ";
            else if (modVal == 1)
                b.InnerHtml = "<strong> " + ans + " : " + vote + "</strong> <div class='progress progress-xs'><div class='progress-bar progress-bar-success' role='progressbar' aria-valuenow='0' aria-valuemin='0' aria-valuemax='100' style=width:" + val + "%;'>  </div>  </div> ";
            else if (modVal == 2)
                b.InnerHtml = "<strong> " + ans + " : " + vote + "</strong> <div class='progress progress-xs'><div class='progress-bar progress-bar-info' role='progressbar' aria-valuenow='0' aria-valuemin='0' aria-valuemax='100' style=width:" + val + "%;'>  </div>  </div> ";
            else if (modVal == 3)
                b.InnerHtml = "<strong> " + ans + " : " + vote + "</strong> <div class='progress progress-xs'><div class='progress-bar progress-bar-warning' role='progressbar' aria-valuenow='0' aria-valuemin='0' aria-valuemax='100' style=width:" + val + "%;'>  </div>  </div> ";
            else if (modVal == 4)
                b.InnerHtml = "<strong> " + ans + " : " + vote + "</strong> <div class='progress progress-xs'><div class='progress-bar progress-bar-danger' role='progressbar' aria-valuenow='0' aria-valuemin='0' aria-valuemax='100' style=width:" + val + "%;'>  </div>  </div> ";

            a.Controls.Add(b);
            Form1.Controls.Add(a);
        }
    }
}