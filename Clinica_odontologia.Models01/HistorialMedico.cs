using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Clinica_odontologia.Models01
{
    [Table("historialesmedico")]
    public class HistorialMedico
    {
        [Key]
        [Column("id_historial")]
        public int idHistorialMedico { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("alergias")]
        public string Alergias { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("enfermedades_previas")]
        public string Enfermedades_previas {  get; set; }

        [Required]
        [MaxLength(5)]
        [Column("tipo_sangre")]
        public string Tipo_sangre {  get; set; }

        //tablas debiles (llaves foraneas) OBJETOS DE NAVEGACION
        [ForeignKey("paciente")]
        [Column("id_paciente")]
        public int IdPaciente { get; set; }
        public Paciente? paciente { get; set; }

    }
}
