using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_odontologia.Models01
{
    [Table ("detallecita")]
    public class Detallescita
    {
        [Key]
        [Column ("id_detalle_cita")]
        public int IdDetallecita { get; set; }

        [Required]
        [Column("costo_aplicado", TypeName = "numeric(10, 2)")]
        public double Costo_aplicado { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("observaciones")]
        public string Observaciones { get; set; }

        // Llaves foraneas
        [ForeignKey("citas")]
        [Column("id_cita")]
        public int IdCita { get; set; }
        public Citas? citas { get; set; }

        [ForeignKey("tratimientio")]
        [Column("id_tratamiento")]
        public int IdTratimiento { get; set; }
        public Tratamiento? Tratamiento { get; set;}

    }
}
