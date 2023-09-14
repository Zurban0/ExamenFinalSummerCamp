using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "FechaNacimiento", "Nombre", "Password", "Telefono", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "Contraseña", "948230430", "Paco1" },
                    { 2, new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "Contraseña", "123456789", "Paco2" },
                    { 3, new DateTime(1990, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis", "Contraseña", "987654321", "Paco3" },
                    { 4, new DateTime(1987, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "Contraseña", "555123789", "Paco4" },
                    { 5, new DateTime(2005, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Contraseña", "777888999", "Paco5" },
                    { 6, new DateTime(2002, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Contraseña", "333444555", "Paco6" },
                    { 7, new DateTime(1978, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", "Contraseña", "999111222", "Paco7" },
                    { 8, new DateTime(1983, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marta", "Contraseña", "444555666", "Paco8" },
                    { 9, new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrés", "Contraseña", "888999000", "Paco9" },
                    { 10, new DateTime(1970, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabel", "Contraseña", "222333444", "Paco10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
