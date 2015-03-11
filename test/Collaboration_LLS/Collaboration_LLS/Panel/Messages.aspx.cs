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
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;


namespace Collaboration_LLS.Panel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             HtmlGenericControl a = new HtmlGenericControl("ul");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                    

            using (con)
            {
                SqlCommand command = new SqlCommand(
                  "Select FirstName,MiddleName, LastName, online from [User] where [User].[EmailId] <> @username", con);
                command.Parameters.AddWithValue("@username", HttpContext.Current.Session["LLS_EmailId"]); 
                  
                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                int i = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        i++;

                        HtmlGenericControl b = new HtmlGenericControl("li");
            
                        String id= "li"+ i;
                        String c;
                        if (reader.IsDBNull(3) != true)
                        {
                            if (reader.GetBoolean(3))
                            {
                                c = "ouser";
                            }
                            else
                                c = "user";
                        }
                        else
                            c = "user";
                        b.InnerHtml = "<ul><li><a href='javascript:;' class='"+ c +"' id= '"+id+"'> " + reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + "</a></li></ul> ";

                        a.Controls.Add(b); //similarly you can add more li controls to ul

                        //members.Controls.Add(a);

 


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
