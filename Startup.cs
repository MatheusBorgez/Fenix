using Microsoft.EntityFrameworkCore;

namespace Fenix
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        { 
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<DataContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        public void Configure(WebApplicationBuilder builder)
        {

        }
    }
}
