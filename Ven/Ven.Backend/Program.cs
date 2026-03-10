
using Microsoft.EntityFrameworkCore;
using Van.Shared.Data;

namespace Ven.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();

            //Conexion a la base de datos
            builder.Services.AddDbContext<DataContext>(x =>
                x.UseSqlServer("name=DefaultConnection", options => options.MigrationsAssembly("Ven.Backend")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
                var swaggerUrl = "http://localhost:5103/swagger/"; //URL de Swagger
                Task.Run(() => OpenBrowser(swaggerUrl));

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        static void OpenBrowser(string url)
        {
            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir el navegador: {ex.Message}");
            }
        }
    }
}
