<%@ Page Title="Create Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create-account.aspx.cs" Inherits="DiscountsYourWay.Account.CreateAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="control-group">
        <label class="control-label" for="ddlAccountType">Account Type</label>
        <div class="controls">
            <asp:DropDownList ID="ddlAccountType" runat="server" AutoPostBack="true" CssClass="form-control" Width="25%" ClientIDMode="Static" OnSelectedIndexChanged="ddlAccountType_SelectedIndexChanged" />
        </div>
    </div>
    <asp:Panel ID="pnlBusinessAccount" runat="server" CssClass="form-horizontal" Visible="false">
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtBusinessName">Business Name:</label>
            <div class="controls">
                <asp:TextBox ID="txtBusinessName" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
             <label class="control-label" for="txtEmail">Email:</label>
            <div class="controls">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
       </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtContactName">Contact Name:</label>
            <div class="controls">
                <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtAddress">Address:</label>
            <div class="controls">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtCity">City:</label>
            <div class="controls">
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtState">State:</label>
            <div class="controls">
                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtZipCode">Zip Code:</label>
            <div class="controls">
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtUserName">User Name:</label>
            <div class="controls">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtPassword">Password:</label>
            <div class="controls">
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="txtConfirmPassword">Confirm Password:</label>
            <div class="controls">
                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="ddlContractLength">Contract Length:</label>
            <div class="controls">
                <asp:DropDownList ID="ddlContractLength" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static">
                    <asp:ListItem Value="3">3 months</asp:ListItem>
                    <asp:ListItem Value="6">6 months</asp:ListItem>
                    <asp:ListItem Value="12">12 months</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="control-group" style="width:50%; float:left">
            <label class="control-label" for="lblChargeAmount">Cost:</label>
            <div class="controls">
                <asp:Label ID="lblCost" runat="server" CssClass="form-control" Width="50%" ClientIDMode="Static" />
            </div>
        </div>
        <img src="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" align="left" style="margin-right:7px;">
    </asp:Panel>
</asp:Content>
