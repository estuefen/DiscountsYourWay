using DiscountsYourWay.Core.Manager;
using DiscountsYourWay.enumerations;
using DiscountsYourWay.payment;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscountsYourWay.Account
{
	public partial class CreateAccount : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				List<usp_AccountType_SEL_Result> accounts = ClientManager.GetClientAccounts();
				ddlAccountType.DataValueField = "AccountTypeID";
				ddlAccountType.DataTextField = "AccountName";
				ddlAccountType.DataSource = accounts;
				ddlAccountType.DataBind();

				ddlAccountType.Items.Insert(0, new ListItem("Please select the type of account you want to create", "0"));

				List<usp_Cities_SEL_Display_Result> cities = ClientManager.GetCities();

				string citiesJSON = new JavaScriptSerializer().Serialize(cities);

				hdnCitiesJSON.Value = citiesJSON;
			}
			else
			{
				if (!String.IsNullOrEmpty(txtPassword.Text.Trim()))
				{
					txtPassword.Attributes["value"]= txtPassword.Text;
				}

				if (!String.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
				{
					txtConfirmPassword.Attributes["value"] = txtConfirmPassword.Text;
				}
			}
		}

		protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
		{
			int accountType = 0;
			int.TryParse(ddlAccountType.SelectedValue, out accountType);
			if (accountType == (int)AccountType.Business)
			{
				pnlBusinessAccount.Visible = true;
				pnlDisplayInfo.Visible = true;
				pnlPayment.Visible = true;
				lblCost.Text = totalCost();
			}
			else if (accountType == (int)AccountType.GarageSale)
			{
				pnlBusinessAccount.Visible = false;
				pnlDisplayInfo.Visible = true;
				pnlPayment.Visible = true;
			}
			else if (accountType == (int)AccountType.GroupCoupon)
			{
				pnlBusinessAccount.Visible = false;
				pnlDisplayInfo.Visible = true;
				pnlPayment.Visible = true;
			}
			else
			{
				pnlBusinessAccount.Visible = false;
				pnlDisplayInfo.Visible = false;
				pnlPayment.Visible = false;
			}

			FillDisplayStates();
			FillDisplayCategories();
		}

		protected void ddlContractLength_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblCost.Text = totalCost();
		}


		private string totalCost()
		{
			int accountType = 0;
			int contractLength = 0;
			int businessCount = 0;
			decimal businessCost = 0.00M;
			int.TryParse(ddlAccountType.SelectedValue, out accountType);
			int.TryParse(ddlContractLength.SelectedValue, out contractLength);

			if (txtBusinessName.Text != string.Empty)
			{
				businessCount = ClientManager.GetClientCount(txtBusinessName.Text);
			}

			if (businessCount > 2)
			{
				businessCost = 30.00M;
			}
			else if (businessCount == 2)
			{
				businessCost = 35.00M;
			}
			else
			{
				businessCost = 40.00M;
			}

			return string.Format("${0}", (decimal)businessCost * contractLength);
		}

		protected void lbBusinessPay_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				string originalFileName = Path.GetFileName(string.Format("{0}", fuLogo.PostedFile.FileName));
				string[] splitFileName = originalFileName.Split('.');
				string fileName = splitFileName[0];
				string fileExtension = splitFileName[1];
				int contractLength = 0;
				
				int.TryParse(ddlContractLength.SelectedValue, out contractLength);

				Client client = new Client();
				ClientLogin clientLogin = new ClientLogin();

				client.BusinessName = txtBusinessName.Text.Trim();
				client.ContactName = txtContactName.Text.Trim();
				client.Address = txtAddress.Text.Trim();
				client.City = txtCity.Text.Trim();
				client.State = txtState.Text.Trim();
				client.PostalCode = txtZipCode.Text.Trim();
				client.Phone = txtPhone.Text.Trim();
				client.Email = txtEmail.Text.Trim();
				client.AccountTypeID = (int)AccountType.Business;
				client.LogoURL = string.Empty;

				try
				{
					client.ClientID = ClientManager.SaveClient(client, hdnStates.Value, hdnCities.Value, hdnCategories.Value);

					if (originalFileName != string.Empty && (originalFileName.EndsWith(".gif") || originalFileName.EndsWith(".jpg") || originalFileName.EndsWith(".png") || originalFileName.EndsWith(".svg")))
					{
						//Save files to disk
						fuLogo.SaveAs(Server.MapPath(string.Format("~/business-logos/{0}_{1}.{2}", fileName, client.ClientID, fileExtension)));

						//Save file name to database
						ClientManager.UpdateClientLogo(Server.MapPath(string.Format("~/business-logos/{0}_{1}.{2}", fileName, client.ClientID, fileExtension)), client.ClientID);
					}

					decimal cost;

					decimal.TryParse(lblCost.Text.Replace("$", ""), out cost);
					PayPalExpressCheckout test = new PayPalExpressCheckout();

					test.ShortcutExpressCheckout(cost.ToString(), client.ClientID, contractLength, "Business Account");
				}
				catch (DbEntityValidationException ex)
				{
					// Retrieve the error messages as a list of strings.
					var errorMessages = ex.EntityValidationErrors
							.SelectMany(x => x.ValidationErrors)
							.Select(x => x.ErrorMessage);

					// Join the list to a single string.
					var fullErrorMessage = string.Join("; ", errorMessages);

					// Combine the original exception message with the new one.
					var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

					// Throw a new DbEntityValidationException with the improved exception message.
					throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
				}

				clientLogin.UserName = txtUserName.Text.Trim();
				clientLogin.Password = PasswordHash.CreateHash(txtPassword.Text);
				clientLogin.ClientID = client.ClientID;

				ClientManager.SaveClientLogin(clientLogin);
			}
		}

		protected void txtBusinessName_TextChanged(object sender, EventArgs e)
		{
			lblCost.Text = totalCost();
		}

		protected void FillDisplayStates()
		{
			List<State> states = ClientManager.GetClientStates(); 

			ddlDisplayStates.DataValueField = "StateID";
			ddlDisplayStates.DataTextField = "StateName";
			ddlDisplayStates.DataSource = states;
			ddlDisplayStates.DataBind();
		}

		protected void FillDisplayCategories()
		{
			List<Category> categories = ClientManager.GetClientCategories();
			ddlDisplayCategories.DataValueField = "CategoryID";
			ddlDisplayCategories.DataTextField = "CategoryName";
			ddlDisplayCategories.DataSource = categories;
			ddlDisplayCategories.DataBind();
		}
	}
}