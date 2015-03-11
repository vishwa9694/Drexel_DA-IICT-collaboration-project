<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PollCreation.aspx.cs" Inherits="Collaboration_LLS.Panel.PollCreation" MasterPageFile="~/Panel/PanelAdmin.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <title>Create Poll </title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cpAdmin" runat="server">

    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                POLL CREATION
            </header>
            <div class="panel-body">
                <form class="form-horizontal" role="form" runat="server">
                    <div class="form-group">
                        <div class="col-lg-10">
                            <p class="help-block">Enter the new poll question:</p>
                            <input type="text" autopostback="True" runat="server" class="form-control" style="width: 500px; color:#000;" id="pollQues" placeholder="Poll Question">
                        </div>
                    </div>
                    Choices:
                                <div class="form-group">
                                    <div class="col-lg-6">
                                        <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                    <asp:Button ID="addControlButton" class="btn btn-danger" runat="server" Text="+" OnClick="addControlButton_Click" />

                    <div class="form-group">
                        <div class="col-lg-2">
                            <br />
                            <asp:Button ID="Submit" class="btn btn-primary" runat="server" Text="Create Poll" OnClick="BtnGetAllValues_Click" />
                        </div>
                    </div>
                </form>
            </div>
        </section>

    </div>

</asp:Content>

