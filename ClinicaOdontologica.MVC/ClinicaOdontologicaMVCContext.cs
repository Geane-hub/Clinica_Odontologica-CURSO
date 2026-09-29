using Microsoft.EntityFrameworkCore;

public class ClinicaOdontologicaMVCContext(DbContextOptions<ClinicaOdontologicaMVCContext> options) : DbContext(options)
{
    public DbSet<Clinica_odontologia.Models01.Tratamiento> Tratamiento { get; set; } = default!;
}
