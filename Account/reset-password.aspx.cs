using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DiscountsYourWay.Models;

namespace DiscountsYourWay.Account
{
    public partial class ResetPassword : Page
    {
		public int? ClientLoginID
		{
			get
			{
				int tempID;
				if (Request.Cookies["ClientLoginID"] != null)
				{
					int.TryParse(Request.Cookies["ClientLoginID"].ToString(), out tempID);
					return tempID;
				}
				else
				{
					return null;
				}
			}
		}
		
		protected string StatusMessage
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
			if (this.ClientLoginID == null)
			{
				Response.Redirect("~/Account/login.aspx");
			}
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            if (code != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var user = manager.FindByName(Email.Text);
                if (user == null)
                {
                    ErrorMessage.Text = "No user found";
                    return;
                }
                var result = manager.ResetPassword(user.Id, code, Password.Text);
                if (result.Succeeded)
                {
                    Response.Redirect("~/Account/reset-password-confirmation.aspx");
                    return;
                }
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                return;
            }

            ErrorMessage.Text = "An error has occurred";
        }
    }
}