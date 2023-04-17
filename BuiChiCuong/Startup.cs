using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuiChiCuong.Startup))]
namespace BuiChiCuong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
