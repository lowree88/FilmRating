using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FilmRatingService.Startup))]

namespace FilmRatingService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}