using DiscountsYourWay.enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
				DiscountsYourWayEntities entities = new DiscountsYourWayEntities();

				List<usp_AccountType_SEL_Result> accounts = (from c in entities.usp_AccountType_SEL()
															 select c).ToList();
				ddlAccountType.DataValueField = "AccountTypeID";
				ddlAccountType.DataTextField = "AccountName";
				ddlAccountType.DataSource = accounts;
				ddlAccountType.DataBind();

				ddlAccountType.Items.Insert(0, new ListItem("Please select the type of account you want to create", "0"));
			}
		}

		protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
		{
			int accountType = 0;
			int.TryParse(ddlAccountType.SelectedValue, out accountType);
			if (accountType == (int)AccountType.Business)
			{
				pnlBusinessAccount.Visible = true;
			}
			else if (accountType == (int)AccountType.GarageSale)
			{
				pnlBusinessAccount.Visible = false;
			}
			else if (accountType == (int)AccountType.GroupCoupon)
			{
				pnlBusinessAccount.Visible = false;
			}
		}
	}
}