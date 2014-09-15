using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DiscountsYourWay.Models;
using System.Linq;

namespace DiscountsYourWay.Account
{
	public partial class Login : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			RegisterHyperLink.NavigateUrl = "Register";
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
					ClientLogin user = (from c in entities.ClientLogins
										where c.UserName == txtUserName.Text.Trim() && c.Password == txtPassword.Text.Trim()
										select c).FirstOrDefault();


					if (user == null)
					{
						FailureText.Text = "Invalid username or password.";
						ErrorMessage.Visible = true;
					}
					else
					{
						HttpCookie cookie = new HttpCookie("ClientLoginID");
						cookie.Value = user.ClientLoginID.ToString();
						cookie.Expires = DateTime.Now.AddMinutes(30);
						Response.Cookies.Add(cookie);
						Response.Redirect("~/default.aspx");
					}
				}
			}
		}
	}
}