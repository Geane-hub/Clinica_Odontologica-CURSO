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
        [Column ("id_cita", TypeName = "serial")]
        public int Id_cita { get; set; }

        [Required]
        [Column ("fecha_cita", TypeName = "day")]
        public TimeOnly Fecha_cita { get; set; }

        [Required]
        [Column ("motivo", TypeName ="text")]
        public string Motivo {  get; set; }

        [Required]
        [Column ("estado_cita", TypeName = "string")]
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
    }
}
