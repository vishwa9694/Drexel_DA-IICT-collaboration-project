<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PollAns.aspx.cs" Inherits="Collaboration_LLS.Panel.PollAns" MasterPageFile="~/Panel/PanelAdmin.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/Home/css/style.css" rel="stylesheet">
    <link href="../App_Themes/Home/css/style-responsive.css" rel="stylesheet" />
    <title> Answer to Poll</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                POLLS RESULTS 
            </header>
            <div class="panel-body">
                <div class="progress progress-xs" style="display:none;">
                    <div class="progress-bar" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 10%;">
                    </div>
                </div>
                <form id="Form1" runat="server" class="form-horizontal" role="form">
                </form>
            </div>
        </section>

    </div>
</asp:Content>
