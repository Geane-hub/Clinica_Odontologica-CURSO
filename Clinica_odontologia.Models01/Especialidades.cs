using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica_odontologia.Models01
{
    [Table("especialidades", Schema = "public")]
    public class Especialidad
    {
        [Key]
        [Column("id_especialidad")]
        public int IdEspecialidad { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nombre_especialidad")]
        public string NombreEspecialidad { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        //relaciones
        List<Odontologo>? Odontologos { get; set; } = new List<Odontologo>();
    }
}
