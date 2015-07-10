using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SwcLmsMastery.Startup))]
namespace SwcLmsMastery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
