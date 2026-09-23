using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica_odontologia.Models01
{
    [Table("tratamientos", Schema = "public")]
    public class Tratamiento
    {
        [Key]
        [Column("id_tratamiento")]
        public int IdTratamiento { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nombre_tratamiento")]
        public string NombreTratamiento { get; set; }

        [Required]
        [Column("costo_base", TypeName = "decimal(10,2)")]
        public decimal CostoBase { get; set; }

        [Required]
        [Column("duracion_estimada_minutos")]
        public int DuracionEstimadaMinutos { get; set; }
    }
}
