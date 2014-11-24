<%@ Page Title="Create Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="manage-account-information.aspx.cs" Inherits="DiscountsYourWay.Account.ManageAccountInformation" %>

<%@ Register Assembly="DiscountsYourWay" Namespace="DiscountsYourWay.controls" TagPrefix="dyw" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript" src="/js/account-info.js"></script>
	<script type="text/javascript">
		$(document).ready(function () {
			$('input:checkbox[id*="ddlDisplayStates"]').each(function (index, value) {
				$(this).change(function () {
					StateCheckChanged(this);
				});
			});

			$('input:checkbox[id*="ddlDisplayCategories"]').each(function (index, value) {
				$(this).change(function () {
					CategoryCheckChanged(this);
				});
			});
		});
	</script>
	<asp:ValidationSummary ID="vsForm" runat="server" ValidationGroup="business" CssClass="alert-danger" DisplayMode="BulletList" HeaderText="Please Fix the following errors:" ShowMessageBox="false" ShowSummary="true" ShowValidationErrors="true" />
	<div class="control-group">
		<label class="control-label" for="ddlAccountType">Account Type</label>
		<div class="controls">
			<asp:DropDownList ID="ddlAccountType" runat="server" AutoPostBack="true" CssClass="form-control" Width="40%" ClientIDMode="Static" OnSelectedIndexChanged="ddlAccountType_SelectedIndexChanged" />
		</div>
	</div>
	<asp:Panel ID="pnlBusinessAccount" runat="server" ClientIDMode="Static" CssClass="form-horizontal" Visible="false">
		<h3>Business Info:</h3>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtBusinessName">Business Name:</label>
			<div class="controls">
				<asp:TextBox ID="txtBusinessName" runat="server" AutoPostBack="true" CssClass="form-control" Width="80%" ClientIDMode="Static" OnTextChanged="txtBusinessName_TextChanged" />
				<asp:RequiredFieldValidator ID="rfvBusinessName" runat="server" ControlToValidate="txtBusinessName" ErrorMessage="You must enter a business name." ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtContactName">Contact Name:</label>
			<div class="controls">
				<asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtAddress">Address:</label>
			<div class="controls">
				<asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
				<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter an address." ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtCity">City:</label>
			<div class="controls">
				<asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
				<asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ErrorMessage="Please enter a city." ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtState">State: ex. (MN)</label>
			<div class="controls">
				<asp:TextBox ID="txtState" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" MaxLength="2" />
				<asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtState" ErrorMessage="Please enter a state." ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtZipCode">Zip Code:</label>
			<div class="controls">
				<asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" MaxLength="5" />
				<asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please enter an address." ValidationGroup="business" Display="None" SetFocusOnError="true" />
				<asp:RegularExpressionValidator ID="revZipCode" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please enter a valid zip code." ValidationExpression="\d{5}-?(\d{4})?$" ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtPhone">Phone:</label>
			<div class="controls">
				<asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
				<asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Please enter a phone number." ValidationGroup="business" Display="None" SetFocusOnError="true" />
				<asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="please enter a valid phone number." ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$" ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtEmail">Email:</label>
			<div class="controls">
				<asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
				<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter an email address." ValidationGroup="business" Display="None" SetFocusOnError="true" />
				<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid email address." ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="fuLogo">Logo (.gif, .jpg, .png, .svg files only):</label>
			<div class="controls">
				<asp:FileUpload ID="fuLogo" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtUserName">User Name:</label>
			<div class="controls">
				<asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
				<asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please enter a user name." ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtPassword">Password:</label>
			<div class="controls">
				<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
				<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password." ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="txtConfirmPassword">Confirm Password:</label>
			<div class="controls">
				<asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
				<asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Please enter a confirmation password." ValidationGroup="business" Display="None" SetFocusOnError="true" />
				<asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="The passwords you have entered don't match." ValidationGroup="business" Display="None" SetFocusOnError="true" />
			</div>
		</div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="ddlContractLength">Contract Length:</label>
			<div class="controls">
				<asp:DropDownList ID="ddlContractLength" runat="server" AutoPostBack="true" CssClass="form-control" Width="80%" ClientIDMode="Static" OnSelectedIndexChanged="ddlContractLength_SelectedIndexChanged">
					<asp:ListItem Value="3">3 months</asp:ListItem>
					<asp:ListItem Value="6">6 months</asp:ListItem>
					<asp:ListItem Value="12">12 months</asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
		<div style="clear: both;"></div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="lblChargeAmount">Cost:</label>
			<div class="controls">
				<asp:Label ID="lblCost" runat="server" CssClass="form-control" Width="80%" ClientIDMode="Static" />
			</div>
		</div>
	</asp:Panel>
	<div style="clear: both;"></div>
	<br />
	<asp:Panel ID="pnlDisplayInfo" runat="server" ClientIDMode="Static" CssClass="form-horizontal" Visible="false">
		<h3>Display Info:</h3>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="ddlDisplayStates">States:</label>
			<div class="controls">
				<dyw:MultiSelectDropdown ID="ddlDisplayStates" runat="server" Title="Select Display States" ImageURL="/images/Arrow.PNG" />
				<asp:Hiddenfield ID="hdnStates" runat="server" ClientIDMode="Static" />
			</div>
		</div>
		<div style="clear: both;"></div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="ddlDisplayCities">Cities:</label>
			<div class="controls">
				<dyw:MultiSelectDropdown ID="ddlDisplayCities" runat="server" Title="Select Display Cities" ImageURL="/images/Arrow.PNG" />
				<asp:Hiddenfield ID="hdnCities" runat="server" ClientIDMode="Static" />
				<asp:Hiddenfield ID="hdnCitiesJSON" runat="server" ClientIDMode="Static" />
			</div>
		</div>
		<div style="clear: both;"></div>
		<div class="control-group" style="width: 50%; float: left">
			<label class="control-label" for="ddlDisplayCategories">Categories:</label>
			<div class="controls">
				<dyw:MultiSelectDropdown ID="ddlDisplayCategories" runat="server" Title="Select Display Categories" ImageURL="/images/Arrow.PNG" />
				<asp:Hiddenfield ID="hdnCategories" runat="server" ClientIDMode="Static" />
			</div>
		</div>
	</asp:Panel>
	<div style="clear: both;"></div>
	<br />
	<asp:Panel ID="pnlPayment" runat="server" ClientIDMode="Static" CssClass="form-horizontal" Visible="false">
		<div class="control-group" style="width: 50%; float: left">
			<asp:LinkButton ID="lbBusinessPay" runat="server" OnClick="lbBusinessPay_Click" ValidationGroup="business">
				<img src="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" style="margin-right: 7px;">
			</asp:LinkButton>
		</div>
	</asp:Panel>
</asp:Content>
