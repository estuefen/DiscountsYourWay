using DiscountsYourWay.Core.Manager;
using System;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.Security;

namespace DiscountsYourWay.Account
{
	public partial class Login : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
				usp_ClientLogin_SEL_ByUserName_Result user = ClientManager.GetClientLogin(txtUserName.Text);

				if (user == null || !PasswordHash.ValidatePassword(txtPassword.Text, user.Password))
				{
					FailureText.Text = "Invalid username or password.";
					ErrorMessage.Visible = true;
				}
				else
				{
					FormsAuthentication.RedirectFromLoginPage
								 (user.UserName, chkRememberMe.Checked);
				}
			}
		}
	}
}