using Fenix;
using Fenix.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;
using System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var host = CreateHostBuilder(args).Build();
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<DataContext>(c =>
            c.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Fenix;Trusted_Connection=True;MultipleActiveResultSets=true"));

        CreateDbIfNotExists(host);

        // Add services to the container.
        var app = builder.Build();


        RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)app.Environment);

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    static void CreateDbIfNotExists(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<DataContext>();
            context.Database.EnsureCreated();

            if (context.Cidades.Any() && context.Clientes.Any())
            {
                Console.WriteLine(context.Clientes.First());
                Console.WriteLine(context.Cidades.First());
                return;
            }

            var cidade = new Cidade { Nome = "Goiania", UF = "GO" };
            var cliente = new Cliente
            {
                Nome = "Matheus",
                Bairro = "Setor 2",
                Cep = "70000-000",
                Cidade = cidade,
                Endereco = "Rua 1",
                Telefone = "62999999999"
            };

            context.Cidades.Add(cidade);
            context.Clientes.Add(cliente);
            context.SaveChanges();

        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}