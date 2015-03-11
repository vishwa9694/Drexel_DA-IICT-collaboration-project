<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="Collaboration_LLS.Panel.EditProfile" MasterPageFile="~/Panel/PanelAdmin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit Profile </title>
</asp:Content>
<asp:Content ContentPlaceHolderID="cpAdmin" runat="server">
    <form id="form1" runat="server">
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
                                    First Name
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtFirstName">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                     Last Name
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtLastName">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                    Birth Date
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtBirthDate">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                    Mobile Number
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtMobileNumber">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Spouse Name
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtSpouse">
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell>
                                    Home Address
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtHomeAddress">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        City
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtCity">
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell>
                                        State
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtState">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Zip Code
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtZip">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Phone Number (R)
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtHomePhone">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Position
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtPosition">
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
                                    Company
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtCompany">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                    Title
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtTitle">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                     Address
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtCompanyAddress">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                    City
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtCompanyCity">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                    State
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtComapnyState">
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                    Zip Code
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtComapnyZip">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                    Phone Number (O)
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtCompanyPhone">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                    Fax Number
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtFaxNumber">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell VerticalAlign="Top">
                                    Due To Rotate
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtDueToRotate">
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
                                    Mail Preferences
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtMailPref">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                    Assistant Name
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtAssistant">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                    Email Address (Assistant)
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtAssistantEmail">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                    Phone Number (Assistant)
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <input type="text" runat="server" class="form-control" style="width: 500px; color: #000;" id="txtPhoneAssistant">
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        &nbsp;
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ColumnSpan="2">
                                        <asp:Button class="btn btn-danger" Style="margin-left: 180px;" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" runat="server" />
                                        <asp:Button class="btn btn-primary" Style="margin-left: 30px;" ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />

                                    </asp:TableCell>
                                </asp:TableRow>

                            </asp:Table>

                        </div>

                    </div>
                </section>
            </div>
        </div>
    </form>
        <h3>
            <asp:Label ID="txtMessage" runat="server"> Sorry, you have no rights to view this page.</asp:Label>
        </h3>
</asp:Content>
