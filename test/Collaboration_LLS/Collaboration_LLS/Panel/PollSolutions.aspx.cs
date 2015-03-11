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
    public partial class PollSolutions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TableId.ID = "MyTable";
            }
            else
            {
                TableId = (Table)Session["table"];
                this.Form1.Controls.Add(TableId);
            }
        }
       
        protected void Page_Init(Object sender, EventArgs e)
       {SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [PollQues] order by Datetime desc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int k = 1; k < dt.Rows.Count; k+=2)
                {
                    DataRow row = dt.Rows[k];
                    string PollQues = row["PollQues"].ToString();
                    string Datetime = row["Datetime"].ToString();
                    string PollId = row["PollId"].ToString();
                    string creator = row["Creator"].ToString();
                    btnAddinRow_Click(PollQues, Datetime, PollId, creator);
                }
            }
            else
            {
                TableRow r = new TableRow();
                TableCell c1 = new TableCell();
                c1.Text = "Oops! You have not generated any polls yet!";
                c1.ColumnSpan = 5;
                r.Cells.Add(c1);
                
  
                TableId.Rows.Add(r);
 
               // ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Session["table"] = TableId;
        }

        int indexid = 0;
        protected void btnAddinRow_Click(String q, String date, String id, String creator)
        {

            int num_row = (TableId.Rows).Count;

            TableRow r = new TableRow();
            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TableCell c3 = new TableCell();
            TableCell c4 = new TableCell();
            TableCell c5 = new TableCell();
            TextBox t = new TextBox();
            Button b = new Button();
            b.CssClass = "btn btn-primary";
            b.Text = "View response";
            b.ID = id + num_row;
            b.CommandArgument = id; //passing this to event handler
           
            b.Click += new EventHandler((sender, e) => b_Click(sender, e, id));

            t.ID = "textID" + num_row;
            t.EnableViewState = true;


            r.ID = "newRow" + num_row;
            c1.ID = "newC1" + num_row;
            c2.ID = "newC2" + num_row;

            //c1.Text = "" + (num_row + 1);
            indexid++;
            c1.Text = indexid.ToString() ;
            c2.Text = q;
            c3.Text = creator;
            c4.Text = date;
            c5.Controls.Add(b);

            r.Cells.Add(c1);
            r.Cells.Add(c2);
            r.Cells.Add(c3);
            r.Cells.Add(c4);
            r.Cells.Add(c5);
            TableId.Rows.Add(r);
            Session["table"] = TableId;
        }

        private void b_Click(object sender, EventArgs e, String id)
        {
            //Response.Redirect("Dashboard.aspx");

            Response.Redirect("PollAns.aspx?id=" + id);
            
        }

        }
}