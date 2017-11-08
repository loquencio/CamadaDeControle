using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CamadaDeControle.Startup))]
namespace CamadaDeControle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
