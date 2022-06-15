using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAn_CoSo.Startup))]
namespace DoAn_CoSo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
