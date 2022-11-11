using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Data.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProfissionais_Clientes_ClienteId1",
                table: "ClientesProfissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProfissionais_Profissionais_ProfissionalId1",
                table: "ClientesProfissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicosProfissionais_Profissionais_ProfissionalId1",
                table: "ServicosProfissionais");

            migrationBuilder.DropIndex(
                name: "IX_ServicosProfissionais_ProfissionalId1",
                table: "ServicosProfissionais");

            migrationBuilder.DropIndex(
                name: "IX_ClientesProfissionais_ClienteId1",
                table: "ClientesProfissionais");

            migrationBuilder.DropIndex(
                name: "IX_ClientesProfissionais_ProfissionalId1",
                table: "ClientesProfissionais");

            migrationBuilder.DropColumn(
                name: "ProfissionalId1",
                table: "ServicosProfissionais");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "ClientesProfissionais");

            migrationBuilder.DropColumn(
                name: "ProfissionalId1",
                table: "ClientesProfissionais");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfissionalId",
                table: "ServicosProfissionais",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "ClientesProfissionais",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfissionalId",
                table: "ClientesProfissionais",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesProfissionais_ClienteId",
                table: "ClientesProfissionais",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProfissionais_Clientes_ClienteId",
                table: "ClientesProfissionais",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProfissionais_Profissionais_ProfissionalId",
                table: "ClientesProfissionais",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicosProfissionais_Profissionais_ProfissionalId",
                table: "ServicosProfissionais",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProfissionais_Clientes_ClienteId",
                table: "ClientesProfissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProfissionais_Profissionais_ProfissionalId",
                table: "ClientesProfissionais");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicosProfissionais_Profissionais_ProfissionalId",
                table: "ServicosProfissionais");

            migrationBuilder.DropIndex(
                name: "IX_ClientesProfissionais_ClienteId",
                table: "ClientesProfissionais");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "ServicosProfissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfissionalId1",
                table: "ServicosProfissionais",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "ClientesProfissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "ClientesProfissionais",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId1",
                table: "ClientesProfissionais",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfissionalId1",
                table: "ClientesProfissionais",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosProfissionais_ProfissionalId1",
                table: "ServicosProfissionais",
                column: "ProfissionalId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesProfissionais_ClienteId1",
                table: "ClientesProfissionais",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesProfissionais_ProfissionalId1",
                table: "ClientesProfissionais",
                column: "ProfissionalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProfissionais_Clientes_ClienteId1",
                table: "ClientesProfissionais",
                column: "ClienteId1",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProfissionais_Profissionais_ProfissionalId1",
                table: "ClientesProfissionais",
                column: "ProfissionalId1",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicosProfissionais_Profissionais_ProfissionalId1",
                table: "ServicosProfissionais",
                column: "ProfissionalId1",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
