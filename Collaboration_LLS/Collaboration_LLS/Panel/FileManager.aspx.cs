using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Collaboration_LLS.Panel
{
    public partial class FileManager : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int indexVal = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [FileManager]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                TableRow headerRow = new TableRow();
                TableCell index = new TableCell();
                TableCell fileName = new TableCell();
                TableCell author = new TableCell();
                TableCell dateTime = new TableCell();
                TableCell delete = new TableCell();
                TableCell download = new TableCell();
                index.Text = "Index";
                fileName.Text = "File Name";
                author.Text = "Uploaded By";
                dateTime.Text = "Date Time";
                delete.Text = "Delete";
                headerRow.Cells.Add(index);
                headerRow.Cells.Add(fileName);
                headerRow.Cells.Add(download);
                headerRow.Cells.Add(author);
                headerRow.Cells.Add(dateTime);
                headerRow.Cells.Add(delete);
                headerRow.Font.Bold = true;
                headerRow.HorizontalAlign = HorizontalAlign.Center;
                FilesDisp.Rows.Add(headerRow);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    TableRow tRow = new TableRow();
                    FilesDisp.Rows.Add(tRow);
                    TableCell tIndex = new TableCell();
                    indexVal++;
                    tIndex.Text = indexVal.ToString();
                    TableCell tFileName = new TableCell();
                    tFileName.Text = dr["FileName"].ToString();
                    TableCell tDownload = new TableCell();
                    tDownload.Text = "<a href='Files\\" + dr["FileName"].ToString() + "' target='_blank'><i class='fa fa-download'></i></a>";
                    TableCell tAuthor = new TableCell();
                    SqlCommand cmdUserName = new SqlCommand("Select * from [User] Where [User].EmailId=(@EmailId)", con);
                    cmdUserName.Parameters.AddWithValue("@EmailId", dr["Author"].ToString());
                    SqlDataAdapter daUser = new SqlDataAdapter(cmdUserName);
                    DataTable dtUser = new DataTable();
                    daUser.Fill(dtUser);
                    if (dtUser.Rows.Count > 0)
                    {
                        DataRow drUser = dtUser.Rows[0];
                        tAuthor.Text = drUser["FirstName"].ToString() + " " + drUser["LastName"].ToString();
                    }
                    else
                    {
                        tAuthor.Text = dr["Author"].ToString();
                    }
                    TableCell tDateTime = new TableCell();
                    tDateTime.Text = dr["DateTime"].ToString();
                    TableCell tDelete = new TableCell();
                    if (Session["LLS_EmailId"].ToString() == dr["Author"].ToString())
                    {
                        tDelete.Text = "<a href='DeleteFile.aspx?id=" + dr["FileId"] + "'><i class='fa fa-trash-o'></i></a>";
                        tRow.Font.Bold = true;
                    }
                    else
                    {
                        tDelete.Text = " ";
                    }
                    tRow.Cells.Add(tIndex);
                    tRow.Cells.Add(tFileName);
                    tRow.Cells.Add(tDownload);
                    tRow.Cells.Add(tAuthor);
                    tRow.Cells.Add(tDateTime);
                    tRow.Cells.Add(tDelete);
                    tRow.HorizontalAlign = HorizontalAlign.Center;
                    FilesDisp.Rows.Add(tRow);


                }

            }
        }
    }
}