using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerAccountManagement.Startup))]
namespace CustomerAccountManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
