using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica_odontologia.Models01
{
    [Table("consultorios")]
    public class Consultorio
    {
        [Key]
        [Column("id_consultorio", TypeName = "Serial")]
        public int IdConsultorio { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("numero_sala")]
        public string NumeroSala { get; set; }

        [Required]
        [Column("piso")]
        public int Piso { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("equipamiento_principal")]
        public string EquipamientoPrincipal { get; set; }

        //relaciones (consultorios tiene una lista de citas)
        List<Citas>? Citas { get; set; } = new List<Citas>();
    }
}
