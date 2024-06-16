using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Api.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    RG = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mae = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SituacaoCadastro = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DataCadastro = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contatos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentoUsuario",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoUsuario", x => new { x.DepartamentoId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_DepartamentoUsuario_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentoUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecosEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEndereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosEntrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecosEntrega_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contatos_Telefone_Celular",
                table: "contatos",
                columns: new[] { "Telefone", "Celular" });

            migrationBuilder.CreateIndex(
                name: "IX_contatos_UsuarioId",
                table: "contatos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentoUsuario_UsuariosId",
                table: "DepartamentoUsuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosEntrega_CEP",
                table: "EnderecosEntrega",
                column: "CEP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosEntrega_UsuarioId",
                table: "EnderecosEntrega",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CPF_Nome",
                table: "Usuarios",
                columns: new[] { "CPF", "Nome" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CPF_RG",
                table: "Usuarios",
                columns: new[] { "CPF", "RG" },
                unique: true,
                filter: "[RG] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "DepartamentoUsuario");

            migrationBuilder.DropTable(
                name: "EnderecosEntrega");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
