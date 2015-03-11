<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="Collaboration_LLS.Panel.Members" MasterPageFile="~/Panel/PanelAdmin.Master" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Members </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <section class="panel">
                <header class="panel-heading">
                    Members
                        <span class="tools pull-right">
                            <a href="javascript:;" class="fa fa-chevron-down"></a>
                            <a href="javascript:;" class="fa fa-cog"></a>
                            <a href="javascript:;" class="fa fa-times"></a>
                        </span>
                </header>

                <form id="form1" runat="server">
                    <div class="panel-body">

                        <div class="adv-table">

                            <table class="display table table-bordered table-striped" id="dynamic-table">

                                <tbody>
                                    <%
                                    
                                    
                                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand("Select [User].* from [User] Where [User].EmailId NOT IN (@EmailId)", con);
                                        cmd.Parameters.AddWithValue("@EmailId", Session["LLS_EmailId"].ToString());
                                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                                        DataTable dt = new DataTable();
                                        da.Fill(dt);
                                        if (dt.Rows.Count > 0)
                                        {
                                            int n = dt.Rows.Count;
                                            Boolean isEven = false;
                                            if (n % 2 == 0)
                                                isEven = true;
                                            else
                                                isEven = false;

                                            int cnt = 0;
                                            if (isEven == true)
                                                cnt = n / 2;
                                            else
                                                cnt = (n / 2) + 1;
                                            int tmp = 0;
                                            for (int i = 0; i < cnt; i++)
                                            {
                                                DataRow row1 = dt.Rows[tmp];
                                                DataRow row2;
                                                string name2 = "", dob2 = "", propic2 = "";
                                                DateTime dtime2 = new DateTime();
                                                if (!(isEven == false && i == cnt - 1))
                                                {
                                                    row2 = dt.Rows[tmp + 1];
                                                    name2 = row2["FirstName"].ToString() + " " + row2["LastName"].ToString();
                                                    Session["Mem_Email2"] = row2["EmailId"].ToString();    
                                                    dob2 = row2["DOB"].ToString();
                                                    if (String.IsNullOrEmpty(dob2) == false)
                                                        dtime2 = Convert.ToDateTime(dob2);
                                                    propic2 = row2["ProfilePic"].ToString();
                                                    LinkedIn2.HRef = row2["LinkedIn"].ToString();
                                               
                                                }
                                                string name1 = row1["FirstName"].ToString() + " " + row1["LastName"].ToString();
                                                string dob1 = row1["DOB"].ToString();
                                                DateTime dtime1 = new DateTime();
                                                Session["Mem_Email1"] = row1["EmailId"].ToString();
                                                if (String.IsNullOrEmpty(dob1) == false)
                                                    dtime1 = Convert.ToDateTime(dob1);
                                                string propic1 = row1["ProfilePic"].ToString();%>
                                    <tr class="gradeX">
                                        <%
                                                lnkMember1.Text = name1;
                                                lblDob1.Text = dtime1.ToString("dd MMMM");
                                                imgPropic1.Src = "../App_Themes/Home/images/" + propic1;
                                                lnkMember2.Text = name2;
                                                LinkedIn1.HRef = row1["LinkedIn"].ToString();
                                                lblDob2.Text = dtime2.ToString("dd MMMM");
                                                imgPropic2.Src = "../App_Themes/Home/images/" + propic2;
                                                lnkMember1.PostBackUrl = "~/Panel/Profile.aspx?EmailId=" + Session["Mem_Email1"].ToString();
                                                lnkMember2.PostBackUrl = "~/Panel/Profile.aspx?EmailId=" + Session["Mem_Email2"].ToString();

                                        %>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <img runat="server" id="imgPropic1" alt="" src="../App_Themes/Home/images/lock_thumb.jpg" style="height: 140px; width: 160px;" />
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton runat="server" ID="lnkMember1" Style="font-size: 20px; padding-left: 20px;"></asp:LinkButton>
                                                        <br />
                                                        <asp:Label runat="server" ID="lblDob1" Style="font-size: 12px; padding-left: 20px;"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <a href="#"  runat="server" target="_blank" id="LinkedIn1" data-toggle="modal" style="margin-left: 20px;" class="btn btn-danger">
                                                        LinkedIn</a>

                                                    </td>
                                                </tr>

                                            </table>
                                        </td>

                                        <% 
                                                if (isEven == false && i == cnt - 1)
                                                    break; 
                                        %>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <img id="imgPropic2" runat="server" alt="" src="../App_Themes/Home/images/lock_thumb.jpg" style="height: 140px; width: 160px;" />
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton runat="server" ID="lnkMember2" PostBackUrl="~/Panel/Profile.aspx?EmailId=" Style="font-size: 20px; padding-left: 20px;"></asp:LinkButton>
                                                        <br />
                                                        <asp:Label runat="server" ID="lblDob2" Style="font-size: 12px; padding-left: 20px;"></asp:Label>
                                                        <br />
                                                        <br />
                                                         <a href="#" target="_blank" runat="server" id="LinkedIn2" data-toggle="modal" style="margin-left: 20px;" class="btn btn-danger">
                                                        LinkedIn</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <%
                                                tmp += 2;
                                            }
                                        }

                                        else
                                        {
                                        %>
                                        <td>
                                            <h4>No Members Found..!! </h4>
                                        </td>
                                        <%
                                        }
                                        %>
                                    </tr>

                                </tbody>
                            </table>

                        </div>
                    </div>
                </form>
            </section>
        </div>
    </div>
</asp:Content>
