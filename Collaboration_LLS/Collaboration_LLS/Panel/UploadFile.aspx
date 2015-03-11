<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="Collaboration_LLS.Panel.UploadFile" MasterPageFile="~/Panel/PanelAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>File Upload </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Upload File</h3>
                </div>
                <div class="panel-body">
                    <h2 class="lead">Select Files</h2>
                   
                    <!-- The file upload form used as target for the file upload widget -->
                    <form id="form1" runat="server">

                        <asp:FileUpload ID="fuFileUpload" runat="server" Style="background-color: #dddddd; color: #000000;" AllowMultiple="true" />
                        <br />
                        <asp:Button ID="BtnUpload" runat="server" Text="Upload Files" OnClick="BtnUpload_Click" class="btn btn-danger delete" />
                        <asp:LinkButton ID="BtnView" runat="server" Text="View & Submit" OnClick="BtnViewFiles_Click" class="btn btn-primary start" />
                        <asp:LinkButton ID="BtnFileManager" runat="server" Text="Go to File Manager" PostBackUrl="~/Panel/FileManager.aspx" class="btn btn-warning cancel" />

                        <br />
                        The maximum file limit is <strong>500 MB</strong>.
                        <br />
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Visible="false" Font-Bold="true" Font-Size="Small" ForeColor="Green"> Successfully Uploaded..!! </asp:Label>
                        <br />
                        <br />
                        <asp:Table ID="fileDisp" CssClass="table" runat="server">
                            <asp:TableHeaderRow>
                                <asp:TableCell>
                                    <strong>File Name</strong>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <strong>Size</strong>
                                </asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </form>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
