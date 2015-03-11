<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManager.aspx.cs" Inherits="Collaboration_LLS.Panel.FileManager" MasterPageFile="~/Panel/PanelAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>File Manager</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <section class="panel">
                <header class="panel-heading">
                    File Manager
                            <span class="tools pull-right">
                                <a href="javascript:;" class="fa fa-chevron-down"></a>
                                <a href="javascript:;" class="fa fa-cog"></a>
                                <a href="javascript:;" class="fa fa-times"></a>
                            </span>
                </header>
                <a href="UploadFile.aspx" runat="server" class="btn btn-success" style="margin-left:10px; margin-top:15px;">
                    <i class="glyphicon glyphicon-plus"></i>
                    <span>Add files...</span>
                </a>
                <asp:Label ID="msg" runat="server"></asp:Label>
                <div class="panel-body">
                    <asp:Table ID="FilesDisp" CssClass="table table-hover" runat="server">
                    </asp:Table>
                    
                </div>
            </section>
        </div>

    </div>
</asp:Content>
