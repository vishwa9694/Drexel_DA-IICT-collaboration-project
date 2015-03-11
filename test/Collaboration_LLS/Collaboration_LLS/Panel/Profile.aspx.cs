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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [User].* FROM [User] WHERE ([User].EmailId = @EmailId)", con);
            cmd.Parameters.AddWithValue("@EmailId", Request.QueryString["EmailId"].ToString());
            if (!(Request.QueryString["EmailId"].ToString() == Session["LLS_EmailId"].ToString()))
            {
                changePic.Visible = false;
                editProfile.Visible = false;
            } SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                imgUser.Src = "../App_Themes/Home/images/" + row["ProfilePic"].ToString();
                lblName.Text = row["FirstName"].ToString() + " " + row["LastName"].ToString();
                string dob = row["DOB"].ToString();
                DateTime date = new DateTime();
                if (String.IsNullOrEmpty(dob) == false)
                    date = Convert.ToDateTime(dob);
                string city = row["City"].ToString();
                string state = row["State"].ToString();
                string zip = row["ZipCode"].ToString();
                string homephone = row["HomePhone"].ToString();
                string position = row["Position"].ToString();

                string linkedin = row["LinkedIn"].ToString();
                string mobnum = row["MobileNumber"].ToString();
                string duetorotate = row["DueToRotate"].ToString();
                DateTime dueDate = Convert.ToDateTime(duetorotate);
                string spouse = row["SpouseName"].ToString();
                string homeadd = row["HomeAddress"].ToString();
                lblEmailId.Text = row["EmailId"].ToString();
                btnLinkedIn.HRef = linkedin;
                if (String.IsNullOrEmpty(mobnum))
                {
                    msgMobileNumber.Visible = false;
                    lblMobileNumber.Visible = false;
                }
                else
                    lblMobileNumber.Text = mobnum;

                if (String.IsNullOrEmpty(duetorotate))
                {
                    msgDueToRotate.Visible = false;
                    lblDueToRotate.Visible = false;
                }
                else
                    lblDueToRotate.Text = dueDate.ToString("dd MMMM, yyyy");

                if (String.IsNullOrEmpty(dob))
                {
                    msgDOB.Visible = false;
                    lblDOB.Visible = false;
                }
                else
                    lblDOB.Text = date.ToString("dd MMMM");

                if (String.IsNullOrEmpty(position))
                {
                    lblPosition.Visible = false;
                }
                else
                    lblPosition.Text = position;

                if (String.IsNullOrEmpty(spouse))
                {
                    msgSpouseName.Visible = false;
                    lblSpouseName.Visible = false;
                }
                else
                    lblSpouseName.Text = spouse;
                if (String.IsNullOrEmpty(homeadd))
                {
                    msgHomeAddress.Visible = false;
                    lblHomeAddress.Visible = false;
                }
                else
                {
                    //lblHomeAddress.Text = homeadd + " </br> " + city + ", " + state + ", " + zip + " </br> " + " Phone : " + homephone;
                    lblHomeAddress.Text = homeadd;
                    if (String.IsNullOrEmpty(city) == false)
                        lblHomeAddress.Text += " </br> " + city;
                    if (String.IsNullOrEmpty(state) == false)
                        lblHomeAddress.Text += " , " + state;
                    if (String.IsNullOrEmpty(zip) == false)
                        lblHomeAddress.Text += " , " + zip;
                    if (String.IsNullOrEmpty(homephone) == false)
                        lblHomeAddress.Text += " </br> Phone : " + homephone;
                }
                string title = row["Title"].ToString();
                string company = row["Company"].ToString();
                if (String.IsNullOrEmpty(title) && String.IsNullOrEmpty(company))
                {
                    msgCompany.Visible = false;
                    lblCompany.Visible = false;
                }
                else
                {
                    if (String.IsNullOrEmpty(title))
                        lblCompany.Text = company;
                    else if (String.IsNullOrEmpty(company))
                        lblCompany.Text = title;
                    else
                        lblCompany.Text = title + " <br /> " + company;
                }
                string caddress = row["CompanyAddress"].ToString();
                string ccity = row["CompanyCity"].ToString();
                string cstate = row["ComapnyState"].ToString();
                string czip = row["ComapanyZipCode"].ToString();
                string cphone = row["CompanyPhoneNumber"].ToString();
                string cfax = row["CompanyFax"].ToString();

                if (String.IsNullOrEmpty(caddress))
                {
                    lblCAddress.Visible = false;
                    msgCAddress.Visible = false;
                }
                else
                {
                    //lblCAddress.Text = caddress + "</br> " + ccity + ", " + cstate + ", " + czip + " <br /> Phone : " + cphone + " <br /> Fax : " + cfax;
                    lblCAddress.Text = caddress;
                    if (String.IsNullOrEmpty(ccity) == false)
                        lblCAddress.Text += " </br> " + ccity;
                    if (String.IsNullOrEmpty(cstate) == false)
                        lblCAddress.Text += " , " + cstate;
                    if (String.IsNullOrEmpty(czip) == false)
                        lblCAddress.Text += " , " + czip;
                    if (String.IsNullOrEmpty(cphone) == false)
                        lblCAddress.Text += " </br> Phone : " + cphone;
                    if (String.IsNullOrEmpty(cfax) == false)
                        lblCAddress.Text += " </br> Fax : " + cfax;

                }

                string assistant = row["Assistant"].ToString();
                string mailpref = row["MailPreference"].ToString();
                string assimob = row["AssistantPhoneNumber"].ToString();
                string assiemail = row["AssistantEmailId"].ToString();

                if (String.IsNullOrEmpty(assistant))
                {
                    msgAssistant.Visible = false;
                    lblAssistant.Visible = false;
                }
                else
                    lblAssistant.Text = assistant;

                if (String.IsNullOrEmpty(mailpref))
                {
                    msgMailPref.Visible = false;
                    lblMailPref.Visible = false;
                }
                else
                    lblMailPref.Text = mailpref;

                if (String.IsNullOrEmpty(assimob))
                {
                    msgAssiPhone.Visible = false;
                    lblAssiPhone.Visible = false;
                }
                else
                    lblAssiPhone.Text = assimob;

                if (String.IsNullOrEmpty(assiemail))
                {
                    msgAssiEmail.Visible = false;
                    lblAssiEmail.Visible = false;
                }
                else
                    lblAssiEmail.Text = assiemail;
            }
        }
        protected void BtnChange_Click(object sender, EventArgs e)
        {
            if (fuImageUpload.HasFile)
            {
                fuImageUpload.SaveAs(System.IO.Path.Combine(Server.MapPath("~/App_Themes/Home/images/"), fuImageUpload.FileName));
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET [ProfilePic] = @newPic where [User].[EmailId]=@emailId ", con);
                cmd.Parameters.AddWithValue("@newPic", fuImageUpload.FileName);
                cmd.Parameters.AddWithValue("@emailId", Session["LLS_EmailId"].ToString());
                cmd.ExecuteNonQuery();
                Session["LLS_ProPic"] = fuImageUpload.FileName;
                Response.Redirect("Dashboard.aspx");
            }

        }
    }
}