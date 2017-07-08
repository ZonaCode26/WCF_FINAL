using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPractFinal.Startup))]
namespace WebPractFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
