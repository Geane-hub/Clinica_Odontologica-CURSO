using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_odontologia.Models01
{
    [Table("recetas")]
    public class Receta
    {
        [Key]
        [Column ("id_receta", TypeName = "serial")]
        public int IdReceta { get; set; }

        [Required]
        [Column ("fecha_emision", TypeName = "timestamp without time zone")]
        public DateTime Fecha_emision { get; set; }

        [Required]
        [Column("indicaciones", TypeName = "text")]
        public string Indicaciones { get; set; }

        //llave foranea
        [ForeignKey("citas")]
        [Column("id_cita")]
        public int IdCita { get; set; }
        public Citas? citas { get; set; }
    }
}
