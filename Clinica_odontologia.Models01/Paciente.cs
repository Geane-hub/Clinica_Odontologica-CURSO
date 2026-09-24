using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica_odontologia.Models01
{
    [Table("pacientes", Schema = "public")]
    public class Paciente
    {
        [Key]
        [Column("id_paciente", TypeName = "serial")]
        public int IdPaciente { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("dni")]
        public string Dni { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nombres")]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("telefono")]
        public string Telefono { get; set; }

        List<Citas> Citas { get; set; } = new List<Citas>();
    }
}
