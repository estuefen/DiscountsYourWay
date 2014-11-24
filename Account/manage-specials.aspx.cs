using DiscountsYourWay.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiscountsYourWay.Account
{
	public partial class ManageSpecialsPage : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["Successful"] == "True")
				{
					if (Request.QueryString["ClientID"] != string.Empty)
					{
						int contractLength = 0;
						int clientID = 0;
						int.TryParse(Request.QueryString["ContractLength"], out contractLength);
						int.TryParse(Request.QueryString["ClientID"], out clientID);
						DateTime today = DateTime.Now;
						DateTime expirationDate = DateTime.Now.AddMonths(contractLength);

						ClientAccount clientAccount = new ClientAccount();
						clientAccount.AccountStartDate = today;
						clientAccount.AccountEndDate = expirationDate;
						clientAccount.ClientID = clientID;

						ClientManager.SaveClientAccount(clientAccount);
					}
				}
			}
		}
	}
}