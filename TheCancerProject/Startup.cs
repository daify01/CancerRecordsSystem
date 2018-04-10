using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCancerProject.Startup))]
namespace TheCancerProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
