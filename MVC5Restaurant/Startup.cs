using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5Restaurant.Startup))]
namespace MVC5Restaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
