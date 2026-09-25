using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Clinica_Odontologica.API.Migrations
{
    /// <inheritdoc />
    public partial class V01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "consultorios",
                columns: table => new
                {
                    id_consultorio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_sala = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    piso = table.Column<int>(type: "integer", nullable: false),
                    equipamiento_principal = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultorios", x => x.id_consultorio);
                });

            migrationBuilder.CreateTable(
                name: "especialidades",
                schema: "public",
                columns: table => new
                {
                    id_especialidad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_especialidad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especialidades", x => x.id_especialidad);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                schema: "public",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    nombres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.id_paciente);
                });

            migrationBuilder.CreateTable(
                name: "tratamientos",
                columns: table => new
                {
                    id_tratamiento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_tratamiento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    costo_base = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    duracion_estimada_minutos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tratamientos", x => x.id_tratamiento);
                });

            migrationBuilder.CreateTable(
                name: "odontologos",
                columns: table => new
                {
                    id_odontologo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombres = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    registro_medico = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_especialidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odontologos", x => x.id_odontologo);
                    table.ForeignKey(
                        name: "FK_odontologos_especialidades_id_especialidad",
                        column: x => x.id_especialidad,
                        principalSchema: "public",
                        principalTable: "especialidades",
                        principalColumn: "id_especialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historialesmedico",
                columns: table => new
                {
                    id_historial = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alergias = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    enfermedades_previas = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    tipo_sangre = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    id_paciente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historialesmedico", x => x.id_historial);
                    table.ForeignKey(
                        name: "FK_historialesmedico_pacientes_id_paciente",
                        column: x => x.id_paciente,
                        principalSchema: "public",
                        principalTable: "pacientes",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                schema: "public",
                columns: table => new
                {
                    id_cita = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha_cita = table.Column<DateTime>(type: "timestamp", nullable: false),
                    motivo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    estado_cita = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_paciente = table.Column<int>(type: "integer", nullable: false),
                    pacicienteIdPaciente = table.Column<int>(type: "integer", nullable: true),
                    id_odontologo = table.Column<int>(type: "integer", nullable: false),
                    id_consultorio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.id_cita);
                    table.ForeignKey(
                        name: "FK_Cita_consultorios_id_consultorio",
                        column: x => x.id_consultorio,
                        principalTable: "consultorios",
                        principalColumn: "id_consultorio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_odontologos_id_odontologo",
                        column: x => x.id_odontologo,
                        principalTable: "odontologos",
                        principalColumn: "id_odontologo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_pacientes_pacicienteIdPaciente",
                        column: x => x.pacicienteIdPaciente,
                        principalSchema: "public",
                        principalTable: "pacientes",
                        principalColumn: "id_paciente");
                });

            migrationBuilder.CreateTable(
                name: "detallecita",
                columns: table => new
                {
                    id_detalle_cita = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    costo_aplicado = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    observaciones = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    id_cita = table.Column<int>(type: "integer", nullable: false),
                    id_tratamiento = table.Column<int>(type: "integer", nullable: false),
                    TratamientoIdTratamiento = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallecita", x => x.id_detalle_cita);
                    table.ForeignKey(
                        name: "FK_detallecita_Cita_id_cita",
                        column: x => x.id_cita,
                        principalSchema: "public",
                        principalTable: "Cita",
                        principalColumn: "id_cita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallecita_tratamientos_TratamientoIdTratamiento",
                        column: x => x.TratamientoIdTratamiento,
                        principalTable: "tratamientos",
                        principalColumn: "id_tratamiento");
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    id_facturas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha_emision = table.Column<DateTime>(type: "timestamp", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    impuestos = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    estado_pago = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id_cita = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.id_facturas);
                    table.ForeignKey(
                        name: "FK_facturas_Cita_id_cita",
                        column: x => x.id_cita,
                        principalSchema: "public",
                        principalTable: "Cita",
                        principalColumn: "id_cita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recetas",
                columns: table => new
                {
                    id_receta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha_emision = table.Column<DateTime>(type: "timestamp", nullable: false),
                    indicaciones = table.Column<string>(type: "text", nullable: false),
                    id_cita = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recetas", x => x.id_receta);
                    table.ForeignKey(
                        name: "FK_recetas_Cita_id_cita",
                        column: x => x.id_cita,
                        principalSchema: "public",
                        principalTable: "Cita",
                        principalColumn: "id_cita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_id_consultorio",
                schema: "public",
                table: "Cita",
                column: "id_consultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_id_odontologo",
                schema: "public",
                table: "Cita",
                column: "id_odontologo");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_pacicienteIdPaciente",
                schema: "public",
                table: "Cita",
                column: "pacicienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_detallecita_id_cita",
                table: "detallecita",
                column: "id_cita");

            migrationBuilder.CreateIndex(
                name: "IX_detallecita_TratamientoIdTratamiento",
                table: "detallecita",
                column: "TratamientoIdTratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_id_cita",
                table: "facturas",
                column: "id_cita");

            migrationBuilder.CreateIndex(
                name: "IX_historialesmedico_id_paciente",
                table: "historialesmedico",
                column: "id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_odontologos_id_especialidad",
                table: "odontologos",
                column: "id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_recetas_id_cita",
                table: "recetas",
                column: "id_cita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallecita");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "historialesmedico");

            migrationBuilder.DropTable(
                name: "recetas");

            migrationBuilder.DropTable(
                name: "tratamientos");

            migrationBuilder.DropTable(
                name: "Cita",
                schema: "public");

            migrationBuilder.DropTable(
                name: "consultorios");

            migrationBuilder.DropTable(
                name: "odontologos");

            migrationBuilder.DropTable(
                name: "pacientes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "especialidades",
                schema: "public");
        }
    }
}
