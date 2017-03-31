using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FilmRating.BLL.Startup))]

namespace FilmRating.BLL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}