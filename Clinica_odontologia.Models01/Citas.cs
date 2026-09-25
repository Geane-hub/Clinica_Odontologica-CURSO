using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_odontologia.Models01
{
    [Table("Cita", Schema = "public")]
    public class Citas
    {
        [Key]
        [Column ("id_cita")]
        public int Id_cita { get; set; }

        [Required]
        [Column ("fecha_cita", TypeName = "timestamp")]
        public DateTime Fecha_cita { get; set; }

        [Required]
        [MaxLength(20)]
        [Column ("motivo")]
        public string Motivo {  get; set; }

        [Required]
        [MaxLength(20)]
        [Column ("estado_cita")]
        public string Estado_cita { get; set; }

        // Llaves foraneas
        [ForeignKey("paciente")]
        [Column ("id_paciente")]
        public int IdPaciente { get; set; }
        public Paciente? paciciente { get; set; }

        [ForeignKey("odontologo")]
        [Column ("id_odontologo")]
        public int IdOdontologo { get; set; }
        public Odontologo? odontologo { get; set; }

        [ForeignKey("consultorio")]
        [Column ("id_consultorio")]
        public int IdConsultorio { get; set; }
        public Consultorio? consultorio { get; set; }

        //relaciones
        List<Detallescita> Detallescitas { get; set; } = new List<Detallescita>();
        List<Receta>? Recetas { get; set; } = new List<Receta>();
    }
}
