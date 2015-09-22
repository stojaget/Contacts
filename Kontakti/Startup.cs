using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kontakti.Startup))]
namespace Kontakti
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
