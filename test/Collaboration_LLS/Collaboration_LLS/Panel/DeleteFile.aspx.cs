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
    public partial class DeleteFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmdFetch = new SqlCommand("Select * from [FileManager] where FileId=@FId", con);
            cmdFetch.Parameters.AddWithValue("@FId", Request.QueryString["Id"]);
            SqlDataAdapter da = new SqlDataAdapter(cmdFetch);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string fname = dr["FileName"].ToString();
                string path = System.IO.Path.Combine(Server.MapPath("Files/")) + fname;
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);


                SqlCommand cmdDel = new SqlCommand("Delete From [FileManager] where FileId=@FileId", con);
                cmdDel.Parameters.AddWithValue("@FileId", Request.QueryString["Id"]);
                cmdDel.ExecuteNonQuery();
            }
            Response.Redirect("FileManager.aspx");
        }
    }
}