using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_odontologia.Models01
{
    [Table("odontologos")]

    public class Odontologo
    {
        [Key]
        [Column ("id_odontologo", TypeName = "Serial")]
        public int IdOdontologo { get; set; }

        [Required]
        [MaxLength (50)]
        [Column("nombres", TypeName = "string")]

        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("apellidos", TypeName = "string")]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("registro_medico", TypeName = "string")]
        public string Registro_medico { get; set; }

        [ForeignKey("especialidad")]
        [Column("id_especialidad")]
        public int IdEspecialidad { get; set; }
        public Especialidad? especialidad { get; set; }

    }
}
