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
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fileDisp.Visible = false;
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

            fileDisp.Visible = false;
            if (fuFileUpload.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in fuFileUpload.PostedFiles)
                {
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Files/"),uploadedFile.FileName));
                    DatabaseInsert(uploadedFile.FileName);
                }
                lblMessage.Visible = true;
            }
          
        }
        protected void BtnViewFiles_Click(object sender, EventArgs e)
        {
            if (fuFileUpload.HasFiles)
            {
                fileDisp.Visible = true;
                foreach (HttpPostedFile uploadedFile in fuFileUpload.PostedFiles)
                {
                    TableRow tRow = new TableRow();
                    fileDisp.Rows.Add(tRow);
                    TableCell tCell = new TableCell();
                    tCell.Text = uploadedFile.FileName;
                    tRow.Cells.Add(tCell);
                    TableCell tCell2= new TableCell();
                    int size = uploadedFile.ContentLength;
                    int kbsize = size / 1024;
                    int mbsize = kbsize / 1024;
                    if (kbsize < 1)
                        tCell2.Text = size + " Bytes";
                    else if(mbsize<1)
                     tCell2.Text = kbsize + " KB";
                    else
                        tCell2.Text = mbsize + " MB";
                    tRow.Cells.Add(tCell2);
                    fileDisp.Rows.Add(tRow);
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("Files/"), uploadedFile.FileName));
                    DatabaseInsert(uploadedFile.FileName);
                }
                lblMessage.Visible = true;
            }

        }
        private void DatabaseInsert(String filename)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [FileManager] ([FileName], [Author], [DateTime]) values (@filename,@author,@datetime) ", con);
            cmd.Parameters.AddWithValue("@filename", filename);
            cmd.Parameters.AddWithValue("@author", Session["LLS_EmailId"].ToString());
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
    }
}