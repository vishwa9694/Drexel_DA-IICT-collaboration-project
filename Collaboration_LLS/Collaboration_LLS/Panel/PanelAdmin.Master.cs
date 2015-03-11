using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Collaboration_LLS.Panel
{
    public partial class PanelAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["LLS_EmailId"]) == true)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                HtmlGenericControl a = new HtmlGenericControl("ul");
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                Response.AddHeader("Pragma", "no-cache");

                if ((string)Session["LLS_Locked"] == "True")
                {
                    Response.Redirect("LockScreen.aspx");
                }
            }
                lblUserName.Text = (string)Session["LLS_FirstName"] + " " + (string)Session["LLS_LastName"];
                imgUser.Src = "../App_Themes/Home/images/" + (string)Session["LLS_ProPic"];
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);


                using (con)
                {
                    SqlCommand command = new SqlCommand(
                      "Select FirstName, LastName, online, ProfilePic from [User] where [User].[EmailId] <> @username order by([online]) desc", con);
                    command.Parameters.AddWithValue("@username", HttpContext.Current.Session["LLS_EmailId"]);

                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            i++;


                            String id = "li" + i;
                            String c;
                            if (reader.IsDBNull(2) != true)
                            {
                                if (reader.GetBoolean(2))
                                {
                                    c = "Online";
                                }
                                else
                                    c = "Offline";
                            }
                            else
                                c = "Offline";
                            // b.InnerHtml = "<ul><li><a href='javascript:;' class='"+ c +"' id= '"+id+"'> " + reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + "</a></li></ul> ";

                            HtmlGenericControl row = new HtmlGenericControl("div");
                            row.Attributes["class"] = "prog-row";

                            HtmlGenericControl newControl = new HtmlGenericControl("div");
                            newControl.Attributes["class"] = "user-thumb";
                            newControl.InnerHtml = "<a href='#'><img src='../App_Themes/Home/images/" + reader[3].ToString() + "' alt=''></a>";

                            HtmlGenericControl status = new HtmlGenericControl("div");
                            status.Attributes["class"] = "user-details";
                            if(String.Compare(c,"Online")==0)
                                status.InnerHtml = " <strong><h4><a href='#'  style='color:#4bbad6'>" + reader[0].ToString() + " " + reader[1].ToString() + " </a></h4></strong><p style='color:#4bbad6'>" + c + " </p>";
                            else
                                status.InnerHtml = " <h4><a href='#'>" + reader[0].ToString() + " " + reader[1].ToString() + " </a></h4><p>" + c + " </p>";
                            row.Controls.Add(newControl);
                            row.Controls.Add(status);
                            members.Controls.Add(row);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
        }
    }
}