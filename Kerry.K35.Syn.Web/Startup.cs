using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kerry.K35.Syn.Web.Startup))]
namespace Kerry.K35.Syn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
