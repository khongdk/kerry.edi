using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kerry.K35Syn.Web.Startup))]
namespace Kerry.K35Syn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
