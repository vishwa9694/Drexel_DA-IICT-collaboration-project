<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PollSolutions.aspx.cs" Inherits="Collaboration_LLS.Panel.PollSolutions" MasterPageFile="~/Panel/PanelAdmin.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <title>Poll Details </title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cpAdmin" runat="server">

    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                POLLS RESULTS 
            </header>
             <a href="PollCreation.aspx" runat="server" class="btn btn-success" style="margin-left:10px; margin-top:15px;">
                    <i class="glyphicon glyphicon-plus"></i>
                    <span>Create Poll.. </span>
                </a>
            <div class="panel-body">
                <form id="Form1" runat="server" class="form-horizontal" role="form">
                    <asp:Table ID="TableId" CssClass="table table-hover" runat="server">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>
                                Index
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                Poll Question
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                Asked By
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                Date Time
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                Responses
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>

                    </asp:Table>

                </form>
            </div>

        </section>

    </div>

</asp:Content>

