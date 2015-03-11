<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Collaboration_LLS.Panel.Dashboard" MasterPageFile="~/Panel/PanelAdmin.Master" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard </title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cpAdmin" runat="server">
    <%
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select top 5 * from [Notifications] where [Notifications].Receiver = @receiver and [Notifications].[read] = 0 order by [Notifications].SendTime desc", con);
        cmd.Parameters.AddWithValue("@receiver", (string)Session["LLS_EmailId"]);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt); %>
    <div class="row">

        <div class="col-md-4">
            <aside class="profile-nav alt">
                <section class="panel">
                    <div class="user-heading alt gray-bg">
                        <a href="#">
                            <img alt="" src="../App_Themes/Home/images/lock_thumb.jpg" id="imgUser" runat="server">
                        </a>
                        <h1>
                            <asp:Label ID="lblUserName" runat="server">User</asp:Label></h1>
                        <asp:label ID="lblPosition" runat="server">>Project Manager</asp:label>
                    </div>

                    <ul class="nav nav-pills nav-stacked">
                        
                    </ul>
                </section>
            </aside>
            <%
                dispDate.Text = DateTime.Now.ToString("dd MMMM, yyyy");
                dispDay.Text = DateTime.Now.DayOfWeek.ToString();
                dispTime.Text = DateTime.Now.ToShortTimeString();
                
                
            %>
            <div class="profile-nav alt">
                <section class="panel">
                    <div class="user-heading alt clock-row terques-bg">
                        <h1>
                            <asp:Label ID="dispDate" runat="server"></asp:Label></h1>
                        <p class="text-left">
                            <asp:Label ID="dispDay" runat="server"></asp:Label>
                        </p>
                        <p class="text-left">
                            <asp:Label ID="dispTime" runat="server"></asp:Label>
                        </p>
                    </div>
                    <ul id="clock">
                        <li id="sec"></li>
                        <li id="hour"></li>
                        <li id="min"></li>
                    </ul>

                    <div class="clock-category">
                        <br />
                        <a class="active">
                            <p style="text-align: center;">
                                <span style="color: #e77755; font-size: 21px;">Today </span>
                            </p>
                        </a>

                    </div>

                </section>
            </div>
        </div>



        <div class="col-md-8">
            <div class="profile-nav alt">
                <section class="panel">
                    <header class="panel-heading">
                        Notification <span class="tools pull-right">
                            <a href="javascript:;" class="fa fa-chevron-down"></a>
                            <a href="javascript:;" class="fa fa-cog"></a>
                            <a href="javascript:;" class="fa fa-times"></a>
                        </span>
                    </header>

                    <div class="panel-body">

                        <%int count = 0;

                          while (count < dt.Rows.Count)
                          {

                              DataRow row = dt.Rows[count];
                              string id1 = row["pollId"].ToString();
                              string id2 = row["Id"].ToString();
                              String type = row["Type"].ToString();
                              String se = "sharedevent";
                              String p = "poll";
                              string m = "message";
                              String display = "";
                              if (String.Compare(type, m) == 0)
                              {
                                  display = row["Creator"].ToString() + " send you a message.";%>
                        <a href="#">
                            <div class="alert alert-info clearfix">
                                <span class="alert-icon"><i class="fa fa-envelope-o"></i></span>
                                <div class="notification-info">
                                    <ul class="clearfix notification-meta">
                                        <li class="pull-left notification-sender"><span><%=display %></span></li>
                                        <li class="pull-right notification-time"><%=row["SendTime"].ToString() %></li>
                                    </ul>
                                    <%--<p>
                                    Urgent meeting for next proposal
                                </p>--%>
                                </div>
                            </div>
                        </a>
                        <%}
                                else if (String.Compare(type, p) == 0)
                                {
                                    display = row["Creator"].ToString() + " created a poll";%>
                        <a href="#">
                            <div class="alert alert-danger">
                                <span class="alert-icon"><i class="fa fa-bitbucket"></i></span>
                                <div class="notification-info">
                                    <ul class="clearfix notification-meta">
                                        <li class="pull-left notification-sender"><span><a href="Poll.aspx?pollId=<%=id1%>&nid=<%=id2%>"><%=display%></a></span></li>
                                        <li class="pull-right notification-time"><%=row["SendTime"].ToString()%></li>
                                    </ul>
                                    <%--<p>
                                    Very cool photo jack
                                </p>--%>
                                </div>
                            </div>
                        </a>
                        <%}
                                else if (String.Compare(type, se) == 0)
                                {
                                    display = row["Creator"].ToString() + " created an event";%>
                        <a href="EventDisplay.aspx?Id=<%=id2%>">
                            <div class="alert alert-warning ">
                                <span class="alert-icon"><i class="fa fa-bell-o"></i></span>
                                <div class="notification-info">
                                    <ul class="clearfix notification-meta">
                                        <li class="pull-left notification-sender"><%=display%></li>
                                        <li class="pull-right notification-time"><%=row["SendTime"].ToString() %></li>
                                    </ul>
                                    <%--<p>
                                    Next 5 July Thursday is the last day
                                </p>--%>
                                </div>
                            </div>
                        </a>
                        <%}
                                count++;
                            } %>
                    </div>
                </section>
            </div>
        </div>




    </div>

</asp:Content>


