using ControleDeCadastros.Data;
using ControleDeCadastros.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCadastros
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
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(O => O.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }

    }
}
