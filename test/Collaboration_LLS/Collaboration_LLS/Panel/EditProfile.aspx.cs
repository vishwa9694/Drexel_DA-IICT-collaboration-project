using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace Collaboration_LLS.Panel
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["EmailId"].ToString() == Session["LLS_EmailId"].ToString())
                {
                    txtMessage.Visible = false;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [User].* FROM [User] WHERE ([User].EmailId = @EmailId)", con);
                    cmd.Parameters.AddWithValue("@EmailId", Session["LLS_EmailId"].ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtFirstName.Value = row["FirstName"].ToString();
                        txtLastName.Value = row["LastName"].ToString();
                        if (String.IsNullOrEmpty(row["DOB"].ToString()) == false)
                        {
                            DateTime dob = Convert.ToDateTime(row["DOB"].ToString());
                            txtBirthDate.Value = dob.ToString("dd, MMMM");
                        }
                        txtCity.Value = row["City"].ToString();
                        txtMobileNumber.Value = row["MobileNumber"].ToString();
                        txtPosition.Value = row["Position"].ToString();
                        if (String.IsNullOrEmpty(row["DueToRotate"].ToString()) == false)
                        {
                            DateTime dueRotate = Convert.ToDateTime(row["DueToRotate"].ToString());
                            txtDueToRotate.Value = dueRotate.ToString("MM/dd/yyyy");
                        }
                        txtSpouse.Value = row["SpouseName"].ToString();
                        txtHomeAddress.Value = row["HomeAddress"].ToString();
                        txtState.Value = row["State"].ToString();
                        txtZip.Value = row["ZipCode"].ToString();
                        txtHomePhone.Value = row["HomePhone"].ToString();
                        txtCompany.Value = row["Company"].ToString();
                        txtTitle.Value = row["Title"].ToString();
                        txtCompanyAddress.Value = row["CompanyAddress"].ToString();
                        txtCompanyCity.Value = row["CompanyCity"].ToString();
                        txtComapnyState.Value = row["ComapnyState"].ToString();
                        txtComapnyZip.Value = row["ComapanyZipCode"].ToString();
                        txtCompanyPhone.Value = row["CompanyPhoneNumber"].ToString();
                        txtFaxNumber.Value = row["CompanyFax"].ToString();
                        txtMailPref.Value = row["MailPreference"].ToString();
                        txtAssistant.Value = row["Assistant"].ToString();
                        txtPhoneAssistant.Value = row["AssistantPhoneNumber"].ToString();
                        txtAssistantEmail.Value = row["AssistantEmailId"].ToString();


                    }
                }
                else
                {
                    form1.Visible = false;
                    txtMessage.Visible = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET [User].[FirstName]=@fname, [User].[LastName]=@lname, [User].[DOB]=@dob, [User].[City]=@city, [User].[MobileNumber]=@mobNum, [User].[Position]=@position, [User].[DueToRotate]=@dueRotate, [User].[SpouseName]=@spouse, [User].[HomeAddress]=@homeAdd, [User].[State]=@state, [User].[ZipCode]=@zip, [User].[HomePhone]=@homePhone, [User].[Company]=@company, [User].[Title]=@title, [User].[CompanyAddress]=@companyAdd, [User].[CompanyCity]=@companyCity, [User].[ComapnyState]=@companyState, [User].[ComapanyZipCode]=@companyZip, [User].[CompanyPhoneNumber]=@companyPhone, [User].[CompanyFax]=@fax, [User].[MailPreference]=@MailPref, [User].[Assistant]=@assistant, [User].[AssistantPhoneNumber]=@assiPhoneNum, [User].[AssistantEmailId]=@assiEmail where [User].[EmailId]=@emailId", con);
            cmd.Parameters.AddWithValue("@fname", txtFirstName.Value);
            cmd.Parameters.AddWithValue("@lname", txtLastName.Value);
            if (String.IsNullOrEmpty(txtBirthDate.Value) == false)
            {
                DateTime dob = Convert.ToDateTime(txtBirthDate.Value);
                //            string dob = Convert.ToDateTime(txtBirthDate.Value, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");
                cmd.Parameters.AddWithValue("@dob", dob);
            }
            else
                cmd.Parameters.AddWithValue("@dob", "");
            cmd.Parameters.AddWithValue("@city", txtCity.Value);
            cmd.Parameters.AddWithValue("@mobNum", txtMobileNumber.Value);
            cmd.Parameters.AddWithValue("@position", txtPosition.Value);
            if (String.IsNullOrEmpty(txtDueToRotate.Value) == false)
            {
                DateTime duedate = Convert.ToDateTime(txtDueToRotate.Value);
                //string duedate = Convert.ToDateTime(txtDueToRotate.Value, CultureInfo.CurrentCulture).ToString("MM/dd/yyyy");
                cmd.Parameters.AddWithValue("@dueRotate", duedate);

            }
            else
                cmd.Parameters.AddWithValue("@dueRotate", "");
            cmd.Parameters.AddWithValue("@spouse", txtSpouse.Value);
            cmd.Parameters.AddWithValue("@homeAdd", txtHomeAddress.Value);
            cmd.Parameters.AddWithValue("@state", txtState.Value);
            cmd.Parameters.AddWithValue("@zip", txtZip.Value);
            cmd.Parameters.AddWithValue("@homePhone", txtHomePhone.Value);
            cmd.Parameters.AddWithValue("@company", txtCompany.Value);
            cmd.Parameters.AddWithValue("@title", txtTitle.Value);
            cmd.Parameters.AddWithValue("@companyAdd", txtCompanyAddress.Value);
            cmd.Parameters.AddWithValue("@companyCity", txtCompanyCity.Value);
            cmd.Parameters.AddWithValue("@companyState", txtComapnyState.Value);
            cmd.Parameters.AddWithValue("@companyZip", txtComapnyZip.Value);
            cmd.Parameters.AddWithValue("@companyPhone", txtCompanyPhone.Value);
            cmd.Parameters.AddWithValue("@fax", txtFaxNumber.Value);
            cmd.Parameters.AddWithValue("@MailPref", txtMailPref.Value);
            cmd.Parameters.AddWithValue("@assistant", txtAssistant.Value);
            cmd.Parameters.AddWithValue("@assiPhoneNum", txtPhoneAssistant.Value);
            cmd.Parameters.AddWithValue("@assiEmail", txtAssistantEmail.Value);

            cmd.Parameters.AddWithValue("@emailId", Session["LLS_EmailId"].ToString());
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Redirect(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}