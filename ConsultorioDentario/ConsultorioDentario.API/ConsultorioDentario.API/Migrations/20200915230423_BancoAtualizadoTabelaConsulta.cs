using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultorioDentario.API.Migrations
{
    public partial class BancoAtualizadoTabelaConsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_dentista",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "id_paciente",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "id_procedimento",
                table: "Consulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_dentista",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_paciente",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_procedimento",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
