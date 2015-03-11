<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Poll.aspx.cs" Inherits="Collaboration_LLS.Panel.Poll" MasterPageFile="~/Panel/PanelAdmin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Poll </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="col-lg-12">
        <section class="panel" runat="server">
            <header class="panel-heading">
                POLLS     
            </header>
            <div class="panel-body">
                <form id="Form1" runat="server" class="form-horizontal" role="form">

                    <asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder>
                    <h5 style="margin-left:30px;">
                        <asp:RadioButtonList ID="cntrl" runat="server">
                        </asp:RadioButtonList>
                    </h5>
                    <br />
                    <asp:Button ID="Button1" style="margin-left:30px;" runat="server" Text="Submit" OnClick="Button1_Click" class="btn btn-danger delete" />

                </form>

            </div>
        </section>

    </div>

</asp:Content>
