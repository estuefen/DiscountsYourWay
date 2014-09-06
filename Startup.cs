using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiscountsYourWay.Startup))]
namespace DiscountsYourWay
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
