<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkedIn.aspx.cs" Inherits="Collaboration_LLS.Panel.LinkedIn" MasterPageFile="~/Panel/PanelAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>LinkedIn </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <section class="panel">
                <header class="panel-heading">
                    LinkedIn Account
                            <span class="tools pull-right">
                                <a href="javascript:;" class="fa fa-chevron-down"></a>
                                <a href="javascript:;" class="fa fa-cog"></a>
                                <a href="javascript:;" class="fa fa-times"></a>
                            </span>
                </header>

                <form id="form1" runat="server">
                    <table style="width: 40%; margin-left: 30px; margin-top: 15px; margin-bottom: 25px; padding-bottom: 25px;" class="general-table">
                        <tr>
                            <td>URL </td>
                            <td>
                                <input type="text" id="txtUrl" class="form-control"  runat="server" style="width: 200px; color:#000;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button class="btn btn-danger" Style="margin-left: 50px;" ID="btnSubmit" OnClick="btnReset_Click" text="Add" runat="server" />
                                <asp:Button class="btn btn-primary" Style="margin-left: 10px;" ID="btnCancel" text="Cancel" runat="server" OnClick="btnCancel_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>

                            <td colspan="2">
                                <p> <strong> Note : </strong> Please copy full URL from the web browser.</p>
                            </td>
                        </tr>

                    </table>
                </form>
            </section>
        </div>

    </div>
</asp:Content>
