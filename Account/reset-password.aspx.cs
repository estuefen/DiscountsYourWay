using System;
using System.Linq;
using System.Web;
using System.Web.UI;

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
        }
    }
}