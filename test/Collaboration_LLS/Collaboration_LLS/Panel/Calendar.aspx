<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Collaboration_LLS.Panel.Calendar" MasterPageFile="~/Panel/PanelAdmin.Master"%>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register Assembly="DayPilot.MonthPicker" Namespace="DayPilot.Web.UI" TagPrefix="DayPilot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ContentPlaceHolderID="head" runat ="server">
    <title>Calendar</title>
    <link href='../demo.css' type="text/css" rel="stylesheet" />    
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
   <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" >
    </asp:ScriptManager>
    
   
        
        
        
                <asp:UpdatePanel ID="UpdatePanelCalendar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>

                <DayPilot:MonthPicker ID="MonthPicker1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />

                <DayPilot:DayPilotMonth ID="DayPilotMonth1" runat="server" 
                    DataEndField="eventend"
                    DataStartField="eventstart" 
                    DataTextField="name" 
                    DataValueField="id" 
                    DataTagFields="name, id"
                    DataSourceID="SqlDataSourceEvents"
                    EventClickHandling="PostBack"
                    OnEventClick="DayPilotMonth1_EventClick"
                    ContextMenuID="DayPilotMenu1" 
                    OnEventMenuClick="DayPilotMonth1_EventMenuClick"
                    ClientObjectName="dpm" 
                    EventMoveHandling="CallBack" 
                    OnEventMove="DayPilotMonth1_EventMove"
                    Width="100%" 
                    EventResizeHandling="CallBack" 
                    OnEventResize="DayPilotMonth1_EventResize"
                    OnTimeRangeSelected="DayPilotMonth1_TimeRangeSelected"
                    TimeRangeSelectedHandling="PostBack" 
                    BubbleID="DayPilotBubble1" 
                    ShowToolTip="false" 
                    EventStartTime="false" 
                    EventEndTime="false" 
                    OnCommand="DayPilotMonth1_Command" 
                    
                    CssClassPrefix="month_silver_" 
                    
                    >
                    </DayPilot:DayPilotMonth>

                        <asp:SqlDataSource ID="SqlDataSourceEvents" runat="server" ConnectionString="<%$ ConnectionStrings:dbconnection %>"
                            SelectCommand="SELECT [id], [name], [eventstart], [eventend] FROM [events] WHERE (([eventend] > @start) AND ([eventstart] < @end + 1) AND [emailId] = @emailId)">
                            <SelectParameters>
                                <asp:ControlParameter Name="start" ControlID="DayPilotMonth1" PropertyName="VisibleStart" />
                                <asp:ControlParameter Name="end" ControlID="DayPilotMonth1" PropertyName="VisibleEnd"/>
                                <asp:Parameter Name ="emailId" DbType ="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>

    <DayPilot:DayPilotMenu ID="DayPilotMenu1" runat="server" CssClassPrefix="menu_">
        <DayPilot:MenuItem Text="Edit..." Action="PostBack" Command="Open"></DayPilot:MenuItem>
        <DayPilot:MenuItem Text="-" Action="NavigateUrl"></DayPilot:MenuItem>
        <DayPilot:MenuItem Text="Delete" Action="Callback" Command="Delete"></DayPilot:MenuItem>
    </DayPilot:DayPilotMenu>
    <DayPilot:DayPilotMenu ID="menuSelection" runat="server" CssClassPrefix="menu_">
        <DayPilot:MenuItem Action="JavaScript" JavaScript="dpc1.timeRangeSelectedCallBack(e.start, e.end, e.resource); dpc1.cleanSelection();"
            Text="Create new event" />
        <DayPilot:MenuItem Action="JavaScript" JavaScript="alert('Start: ' + e.start.toString() + '\nEnd: ' + e.end.toString() + '\nResource id: ' + e.resource);"
            Text="Show selection details" />
        <DayPilot:MenuItem Action="JavaScript" JavaScript="dpc1.cleanSelection();" Text="Clean selection" />
    </DayPilot:DayPilotMenu>
    <asp:Button ID="ButtonDummy" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="ButtonDummy"
        PopupControlID="pnlPopup" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlPopup" runat="server" Style="display: none" CssClass="modalPopup"
        Width="500px">
        <asp:UpdatePanel ID="UpdatePanelDetail" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DayPilotMonth1" EventName="EventMenuClick" />
            </Triggers>
            <ContentTemplate>
                <asp:DetailsView ID="EventDetail" runat="server" DefaultMode="Edit" OnItemUpdated="EventDetail_ItemUpdated"
                    DataSourceID="SqlDataSourceDetail" DataKeyNames="id" AutoGenerateEditButton="True" OnItemCommand="EventDetail_ItemCommand"
                    Width="500px" OnItemUpdating="EventDetail_ItemUpdating" AutoGenerateInsertButton="True" AutoGenerateRows="False" OnItemInserted="EventDetail_ItemInserted"
                    CssClass="detail" GridLines="None">
                    <HeaderStyle HorizontalAlign="Right" />
                    <Fields>
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                        <asp:BoundField DataField="eventstart" HeaderText="Start" SortExpression="eventstart"   />
                        <asp:BoundField DataField="eventend" HeaderText="End" SortExpression="eventend" />
                    </Fields>
                </asp:DetailsView>
               <%--<%
                   Convert.ToDateTime(DateTime.Now, System.Globalization.CultureInfo.CurrentCulture).ToString("MM/dd/yyyy hh:MM:ss");
                    %>--%>
                <% string email = Session["LLS_EmailId"].ToString(); %>
                <asp:SqlDataSource ID="SqlDataSourceDetail" runat="server" ConnectionString="<%$ ConnectionStrings:dbconnection %>"
                    SelectCommand="SELECT [id], [name], [eventstart], [eventend] FROM [events] WHERE ([id] = @id)"
                    UpdateCommand="UPDATE [events] SET [name] = @name, [eventstart] = @eventstart, [eventend] = @eventend WHERE [id] = @id"
                    InsertCommand="INSERT INTO [events] ([name], [emailId], [eventstart], [eventend]) values (@name,@emailId,@eventstart,@eventend)"
                    >
                    <SelectParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                 
                    </SelectParameters>
                     <InsertParameters>
                         
                         <%--<asp:Parameter Name="emailId" Type="String"  />--%>
                         <asp:SessionParameter Name ="emailId" SessionField ="LLS_EmailId" Type ="String" />
                         
                       
                     </InsertParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <br />
    </div>
       </form>
</asp:Content>