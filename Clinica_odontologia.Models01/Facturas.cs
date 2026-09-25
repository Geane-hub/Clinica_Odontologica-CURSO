using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_odontologia.Models01
{
    [Table("facturas")]
    public class Facturas
    {
        [Key]
        [Column("id_facturas")]
        public int IdFactura { get; set; }

        [Required]
        [Column("fecha_emision", TypeName = "timestamp")]
        public DateTime Fecha_emision { get; set; }

        [Required]
        [Column("subtotal", TypeName = "numeric(10,2)")]
        public decimal Subtotal { get; set; }

        [Required]
        [Column("impuestos", TypeName = "numeric(10,2)")]
        public decimal Impuestos { get; set; }

        [Required]
        [Column("total", TypeName = "numeric(10,2)")]
        public decimal Total { get; set; }

        [Required]
        [Column("estado_pago")]
        [MaxLength(20)]
        public string Estado_pago { get; set; }

        //llave foranea
        [ForeignKey("citas")]
        [Column("id_cita")]
        public int IdCita { get; set; }
        public Citas? citas { get; set; }
    }
}
