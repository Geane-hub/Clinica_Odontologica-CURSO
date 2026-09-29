using Clinica_odontologia.Models01;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologica.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CRUD<Citas>.Endpoint = "https://localhost:7263/api/Citas";
            CRUD<Consultorio>.Endpoint = "https://localhost:7263/api/Consultorios";
            CRUD<Detallescita>.Endpoint = "https://localhost:7263/api/Detallescitas";
            CRUD<Especialidad>.Endpoint = "https://localhost:7263/api/Especialidades";
            CRUD<Facturas>.Endpoint = "https://localhost:7263/api/Facturas";
            CRUD<HistorialMedico>.Endpoint = "https://localhost:7263/api/HistorialMedicos";
            CRUD<Odontologo>.Endpoint = "https://localhost:7263/api/Odontologos";
            CRUD<Paciente>.Endpoint = "https://localhost:7263/api/Pacientes";
            CRUD<Receta>.Endpoint = "https://localhost:7263/api/Recetas";
            CRUD<Tratamiento>.Endpoint = "https://localhost:7263/api/Tratamientos";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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
    }
}
