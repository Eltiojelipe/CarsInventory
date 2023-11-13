using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsInventory.API.Migrations
{
    /// <inheritdoc />
    public partial class Correep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cod_postal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedulaId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fec_Nac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personaId = table.Column<int>(type: "int", nullable: true),
                    Med_Pago = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.clienteId);
                    table.ForeignKey(
                        name: "FK_clientes_personas_personaId",
                        column: x => x.personaId,
                        principalTable: "personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tecnicos",
                columns: table => new
                {
                    tecnicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personaId = table.Column<int>(type: "int", nullable: true),
                    Num_Permiso_Conducir = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tecnicos", x => x.tecnicoId);
                    table.ForeignKey(
                        name: "FK_tecnicos_personas_personaId",
                        column: x => x.personaId,
                        principalTable: "personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placaVh = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelo = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehiculos_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Direccion_origen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion_fin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    fechaServicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TecnicoId = table.Column<int>(type: "int", nullable: false),
                    placaVh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehiculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicios_ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicios_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicios_tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "tecnicos",
                        principalColumn: "tecnicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicios_vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudades_Name",
                table: "ciudades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_personaId",
                table: "clientes",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_cedulaId",
                table: "personas",
                column: "cedulaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_servicios_CiudadId",
                table: "servicios",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_ClienteId",
                table: "servicios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_TecnicoId",
                table: "servicios",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_VehiculoId",
                table: "servicios",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_tecnicos_personaId",
                table: "tecnicos",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_ClienteId",
                table: "vehiculos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_placaVh",
                table: "vehiculos",
                column: "placaVh",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "ciudades");

            migrationBuilder.DropTable(
                name: "tecnicos");

            migrationBuilder.DropTable(
                name: "vehiculos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
