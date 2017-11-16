using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetsAndOwners.Startup))]
namespace PetsAndOwners
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
