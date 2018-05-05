using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DW.Web.Startup))]
namespace DW.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
