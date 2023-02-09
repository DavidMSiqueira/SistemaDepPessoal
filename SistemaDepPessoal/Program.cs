using Microsoft.EntityFrameworkCore;
using SistemaDepPessoal.Data;
using SistemaDepPessoal.Repositorio;

namespace SistemaDepPessoal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var ConnectionString = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<DataContext>(options => options
                .UseSqlServer(ConnectionString));
            builder.Services.AddScoped<ICadastroRepositorio, CadastroRepositorio>();

            var app = builder.Build();

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

            app.Run();
        }
    }
}