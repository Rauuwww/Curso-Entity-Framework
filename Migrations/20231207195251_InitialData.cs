using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curso_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("97c9f346-b27c-4d0f-98ba-ae0b769604b6"), null, "Actividades pendientes", 20 },
                    { new Guid("97c9f346-b27c-4d0f-98ba-ae0b769714b6"), null, "Actividades personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "titulo" },
                values: new object[,]
                {
                    { new Guid("abd281ac-d1fb-4fb6-8c4e-39a82c63701f"), new Guid("97c9f346-b27c-4d0f-98ba-ae0b769714b6"), null, new DateTime(2023, 12, 7, 13, 52, 51, 40, DateTimeKind.Local).AddTicks(4428), 2, "Ver los cursos de Platzi" },
                    { new Guid("abd281ac-d1fb-4fb6-8c4e-39a82c6370ef"), new Guid("97c9f346-b27c-4d0f-98ba-ae0b769604b6"), null, new DateTime(2023, 12, 7, 13, 52, 51, 40, DateTimeKind.Local).AddTicks(4412), 1, "Pago de telefono fijo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("abd281ac-d1fb-4fb6-8c4e-39a82c63701f"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("abd281ac-d1fb-4fb6-8c4e-39a82c6370ef"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("97c9f346-b27c-4d0f-98ba-ae0b769604b6"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("97c9f346-b27c-4d0f-98ba-ae0b769714b6"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
