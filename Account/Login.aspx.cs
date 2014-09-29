using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DiscountsYourWay.Models;
using System.Linq;
using System.Web.Security;

namespace DiscountsYourWay.Account
{
	public partial class Login : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//FormsAuthentication.SignOut();
			//FormsAuthentication.RedirectToLoginPage();

			RegisterHyperLink.NavigateUrl = "register";
			// Enable this once you have account confirmation enabled for password reset functionality
			// ForgotPasswordHyperLink.NavigateUrl = "Forgot";
			OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
			var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
			if (!String.IsNullOrEmpty(returnUrl))
			{
				RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
				DiscountsYourWayEntities entities = new DiscountsYourWayEntities();

				using (entities)
				{
					usp_ClientLogin_SEL_ByUserNameAndPassword_Result user = (from c in entities.usp_ClientLogin_SEL_ByUserNameAndPassword(txtUserName.Text, txtPassword.Text)
																			 select c).FirstOrDefault();


					if (user == null)
					{
						FailureText.Text = "Invalid username or password.";
						ErrorMessage.Visible = true;
					}
					else
					{
						FormsAuthentication.RedirectFromLoginPage
									 (user.UserName, chkRememberMe.Checked);
						//HttpCookie cookie = new HttpCookie("ClientLoginID");
						//cookie.Value = user.ClientLoginID.ToString();
						//cookie.Expires = DateTime.Now.AddMinutes(30);
						//Response.Cookies.Add(cookie);
						//Response.Redirect("~/default.aspx");
					}
				}
			}
		}
	}
}