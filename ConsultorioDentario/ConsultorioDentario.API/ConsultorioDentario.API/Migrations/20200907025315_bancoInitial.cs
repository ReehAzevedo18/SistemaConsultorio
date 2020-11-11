using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultorioDentario.API.Migrations
{
    public partial class bancoInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id_endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    num = table.Column<int>(type: "int", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id_endereco);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    id_procedimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duracao = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.id_procedimento);
                });

            migrationBuilder.CreateTable(
                name: "Dentista",
                columns: table => new
                {
                    id_dentista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_endereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentista", x => x.id_dentista);
                    table.ForeignKey(
                        name: "FK_Dentista_Endereco_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "Endereco",
                        principalColumn: "id_endereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dt_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numCarteira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dt_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_endereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.id_paciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Endereco_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "Endereco",
                        principalColumn: "id_endereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    id_consulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dt_consulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_dentista = table.Column<int>(type: "int", nullable: false),
                    Dentistaid_dentista = table.Column<int>(type: "int", nullable: true),
                    id_paciente = table.Column<int>(type: "int", nullable: false),
                    Pacienteid_paciente = table.Column<int>(type: "int", nullable: true),
                    id_procedimento = table.Column<int>(type: "int", nullable: false),
                    Procedimentoid_procedimento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.id_consulta);
                    table.ForeignKey(
                        name: "FK_Consulta_Dentista_Dentistaid_dentista",
                        column: x => x.Dentistaid_dentista,
                        principalTable: "Dentista",
                        principalColumn: "id_dentista",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_Pacienteid_paciente",
                        column: x => x.Pacienteid_paciente,
                        principalTable: "Paciente",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_Procedimento_Procedimentoid_procedimento",
                        column: x => x.Procedimentoid_procedimento,
                        principalTable: "Procedimento",
                        principalColumn: "id_procedimento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_Dentistaid_dentista",
                table: "Consulta",
                column: "Dentistaid_dentista");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_Pacienteid_paciente",
                table: "Consulta",
                column: "Pacienteid_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_Procedimentoid_procedimento",
                table: "Consulta",
                column: "Procedimentoid_procedimento");

            migrationBuilder.CreateIndex(
                name: "IX_Dentista_id_endereco",
                table: "Dentista",
                column: "id_endereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_id_endereco",
                table: "Paciente",
                column: "id_endereco",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Dentista");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
