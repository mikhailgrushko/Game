using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuessGameWeb.Startup))]
namespace GuessGameWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
