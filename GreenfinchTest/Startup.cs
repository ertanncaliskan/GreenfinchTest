using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenfinchTest.Startup))]
namespace GreenfinchTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
