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
                if (txtUserName.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    DiscountsYourWayEntities entities = new DiscountsYourWayEntities();
                    var userName = entities.ClientLogins.Where(s => s.UserName == txtUserName.Text.Trim());
                    var password = entities.ClientLogins.Where(s => s.Password == txtPassword.Text.Trim() && s.UserName == txtUserName.Text.Trim());

                    if (userName == null)
                    {
                        FailureText.Text = "Invalid username.";
                    }
                    else
                    {
                        if (password == null)
                        {
                            FailureText.Text = "Invalid password.";
                        }
                    }
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}