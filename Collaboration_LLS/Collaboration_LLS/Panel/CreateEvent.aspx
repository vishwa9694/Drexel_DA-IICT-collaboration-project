<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="Collaboration_LLS.Panel.CreateEvent" MasterPageFile="~/Panel/PanelAdmin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Create Event </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <section class="panel">
                <header class="panel-heading">
                    Create New Event
                        <span class="tools pull-right">
                            <a href="javascript:;" class="fa fa-chevron-down"></a>
                            <a href="javascript:;" class="fa fa-cog"></a>
                            <a href="javascript:;" class="fa fa-times"></a>
                        </span>
                </header>
                <div class="panel-body">
                    <div class="adv-table">  
                        <form id="form3" runat="server">
                        <table class="display table table-bordered table-striped" id="dynamic-table">
                          
                          
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Event Name" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="txtEventName" type="text" class="form-control" style="width:400px;" runat="server" required    />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Event Description"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="EventDesc" cols="60" rows="5" class="form-control" style="width:400px;" runat="server" required></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td> 
                                    <asp:Label ID="Label3" runat="server" Text="StartDate"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="StartDate" type="text" class="form-control dpd1" style="width:200px;" runat="server" placeholder="mm/dd/yyyy" required/>
                                </td>     
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="End Date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="EndDate" type="text" class="form-control dpd2" style="width:200px;" runat="server" placeholder="mm/dd/yyyy" required/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btCreateEvent" runat="server" Text="Create Event" CssClass="btn btn-danger"  OnClick="btCreateEvent_Click" />
                                   <%--<input id="BtnCreateEvent" type="button" value="Create Event" runat="server" onclick="Button1_OnClick" />--%>
                                </td>
                            </tr>
                         
                    </table>
                   </form>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>






