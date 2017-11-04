using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBFORM.Startup))]
namespace WEBFORM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
