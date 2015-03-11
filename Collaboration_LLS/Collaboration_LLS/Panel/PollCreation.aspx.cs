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
    public partial class PollCreation : System.Web.UI.Page
    {
        static String q = "";
        int controlCounter = 0;
        List<string> myControlList;

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            myControlList = (List<string>)ViewState["myControlList"];
            foreach (string ctlID in myControlList)
            {
                controlCounter++;
                TextBox box = new TextBox();
                box.ID = ctlID;
                box.CssClass = "form-control";
                LiteralControl lineBreak = new LiteralControl("<br />");
                controlHolder.Controls.Add(lineBreak);

                controlHolder.Controls.Add(box);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                myControlList = new List<string>();
                ViewState["myControlList"] = myControlList;
            }
        }

        protected void addControlButton_Click(object sender, EventArgs e)
        {
            controlCounter++;
            TextBox box = new TextBox();
            box.ID = "textBox" + controlCounter.ToString();
            box.CssClass = "form-control";
            box.Style.Value = "color:#000;";
            LiteralControl lineBreak = new LiteralControl("<br />");
            controlHolder.Controls.Add(lineBreak);

            controlHolder.Controls.Add(box);
            myControlList.Add(box.ID);
            ViewState["myControlList"] = myControlList;
        }


        protected void BtnGetAllValues_Click(object sender, EventArgs e)
        {
            int id = 1;
            string txt = "";
            string qs = pollQues.Value;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into [PollQues] (PollQues, Creator, Datetime) OUTPUT INSERTED.PollId values (@ques, @creator, @date) ", con);
            cmd.Parameters.AddWithValue("@ques", qs);
            cmd.Parameters.AddWithValue("@creator", HttpContext.Current.Session["LLS_FirstName"].ToString());
            cmd.Parameters.AddWithValue("@date", System.DateTime.Now);


            cmd.ExecuteNonQuery();
            Int32 newId = (Int32)cmd.ExecuteScalar();
        
            List<String> columnData = new List<String>();
            SqlCommand command = new SqlCommand(
                "Select EmailId from [User] where [User].[EmailId] <> @username", con);
            command.Parameters.AddWithValue("@username", HttpContext.Current.Session["LLS_EmailId"]);
            SqlDataReader reader = command.ExecuteReader();
            //int i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    columnData.Add(reader.GetString(0));

                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            for (int i = 0; i < columnData.Count; i++)
            {
                SqlCommand cmd2 = new SqlCommand("Insert into [Notifications] (Type, Creator, SendTime, Receiver, pollId) values (@type, @creat, @d, @m, @id) ", con);
                cmd2.Parameters.AddWithValue("@type", "poll");
                cmd2.Parameters.AddWithValue("@creat", HttpContext.Current.Session["LLS_FirstName"].ToString() +" " + HttpContext.Current.Session["LLS_LastName"].ToString());
                cmd2.Parameters.AddWithValue("@d", System.DateTime.Now);
                cmd2.Parameters.AddWithValue("@m", columnData.ElementAt(i));
                cmd2.Parameters.AddWithValue("@id",newId);
                cmd2.ExecuteNonQuery();



            }



            //SqlCommand cmd1 = new SqlCommand("Select PollId from [PollQues] where [PollQues].[PollQues]=@question  ", con);
            //cmd1.Parameters.AddWithValue("@question", qs);

            //SqlDataAdapter da = new SqlDataAdapter(cmd1);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
              //  DataRow row = dt.Rows[0];
                //id = (int)row["PollId"];
            //}
            //else
            //{
              //  Response.Redirect("Error.aspx");
            //}

            foreach (Control c in controlHolder.Controls)
            {
                if (c.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    txt = ((TextBox)c).Text;
                    SqlCommand cmd2 = new SqlCommand("Insert into [PollAns] (Answer, PollId) values (@ans, @id) ", con);
                    cmd2.Parameters.AddWithValue("@ans", txt);
                    cmd2.Parameters.AddWithValue("@id", newId);


                    cmd2.ExecuteNonQuery();

                }
            }

            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Poll has been successfully generated!')</script>");
            //above line not working
            Response.Redirect("Dashboard.aspx");

        }




    }

}