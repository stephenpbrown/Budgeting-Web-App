using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetingWebApp.Startup))]
namespace BudgetingWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
