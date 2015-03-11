<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Collaboration_LLS.Panel.Profile" MasterPageFile="~/Panel/PanelAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <div class="panel-body profile-information">
                    <div class="col-md-3">
                        <div class="profile-pic text-center">
                            <img src="images/lock_thumb.jpg" alt="" id="imgUser" runat="server">
                        </div>
                    </div>
                    <div class="col-md-9">
                        <div class="profile-desk">
                            <h1 style="color: #cf6b4c;">
                                <asp:Label ID="lblName" runat="server">  </asp:Label></h1>
                            <asp:Label class="text-muted" Style="font-size: 15px;" ID="lblPosition" runat="server"></asp:Label>
                            <br />
                            <br />
                            <a href="#" class="btn btn-danger" id="btnLinkedIn" target="_blank" runat="server">Go to LinkedIn</a>
                            <a href="#myModal2" class="btn btn-primary" data-toggle="modal" id="changePic" runat="server">Change Profile Pic</a>
                            <span id="editProfile" runat="server">
                                <a href="EditProfile.aspx?EmailId=<%=Session["LLS_EmailId"].ToString() %>" class="btn btn-success">Edit Profile</a>
                            </span>
                            <div class="modal fade" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title">Change Your Profile Picture</h4>
                                        </div>
                                        <div class="modal-body">
                                            <form action="#" class="form-horizontal" runat="server">
                                                <div class="form-group" style="margin-left: 50px;">

                                                    <asp:FileUpload ID="fuImageUpload" runat="server" Style="background-color: #dddddd; color: #000000;" />
                                                    <br />
                                                    <asp:Button ID="BtnUpload" runat="server" Text="Change" OnClick="BtnChange_Click" class="btn btn-danger delete" />

                                                </div>
                                            </form>

                                        </div>
                                        <div class="modal-footer">
                                            <button data-dismiss="modal" class="btn btn-default" type="button">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <div class="profile-desk">

                    <div class="panel-body profile-information">
                        <h3>Personal Info </h3>
                        <br />
                        <asp:Table ID="tblPersonal" runat="server" Font-Size="15px" CssClass="table-condensed">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgEmailId" runat="server">Email Id : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgMobileNumber" runat="server">Mobile Number : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgDueToRotate" runat="server">Due To Rotate : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDueToRotate" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgSpouseName" runat="server">Spouse Name : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblSpouseName" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgDOB" runat="server">Birth Date : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell VerticalAlign="Top">
                                    <asp:Label ID="msgHomeAddress" runat="server">Address : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblHomeAddress" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>

                    </div>

                </div>
            </section>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <div class="profile-desk">

                    <div class="panel-body profile-information">
                        <h3>Company Info </h3>
                        <br />
                        <asp:Table ID="Table1" runat="server" Font-Size="15px" CssClass="table-condensed">
                            <asp:TableRow>
                                <asp:TableCell VerticalAlign="Top">
                                    <asp:Label ID="msgCompany" runat="server">Company : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell VerticalAlign="Top">
                                    <asp:Label ID="msgCAddress" runat="server">Address : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblCAddress" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>


                        </asp:Table>

                    </div>

                </div>
            </section>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <div class="profile-desk">

                    <div class="panel-body profile-information">
                        <h3>References </h3>
                        <br />
                        <asp:Table ID="Table2" runat="server" Font-Size="15px" CssClass="table-condensed">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgMailPref" runat="server">Mail Preferences : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblMailPref" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgAssistant" runat="server">Assistant Name : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblAssistant" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgAssiEmail" runat="server">Email Id : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblAssiEmail" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="msgAssiPhone" runat="server">Phone Number : </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblAssiPhone" runat="server"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>


                        </asp:Table>

                    </div>

                </div>
            </section>
        </div>
    </div>
</asp:Content>
