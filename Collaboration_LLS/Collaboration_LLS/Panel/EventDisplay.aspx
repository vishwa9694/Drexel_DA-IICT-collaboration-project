<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventDisplay.aspx.cs" Inherits="Collaboration_LLS.Panel.EventDisplay" MasterPageFile="~/Panel/PanelAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Event </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <div class="profile-desk">

                    <div class="panel-body profile-information">
                        <h3>Event Details</h3>
                        <br />
                        <asp:Table ID="tblPersonal" runat="server" Font-Size="15px" CssClass="table-condensed">
                            <asp:TableRow>
                                <asp:TableCell>
                                    Event Name:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lbleventname" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    Name of Creator:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblcreator" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    Event Description:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lbleventdesc" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    Start Date:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblstartdate" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    End Date:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblenddate" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    Created At:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblcreatetime" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            
                        </asp:Table>

                    </div>
                    <h4>Note: Event has been added in your calendar.</h4>
                </div>
            </section>
        </div>
    </div>
</asp:Content>