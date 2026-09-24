using Microsoft.EntityFrameworkCore;

public class Clinica_OdontologicaAPIContext(DbContextOptions<Clinica_OdontologicaAPIContext> options) : DbContext(options)
{
    public DbSet<Clinica_odontologia.Models01.Citas> Citas { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Consultorio> Consultorio { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Detallescita> Detallescitas { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Especialidad> Especialidads { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Facturas> Facturas { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.HistorialMedico> HistorialMedicos { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Odontologo> Odontologos { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Paciente> Pacientes { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Receta> Recetas { get; set; } = default!;
    public DbSet<Clinica_odontologia.Models01.Tratamiento> Tratamientos { get; set; } = default!;
}
