﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPesoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Categoria");
        }
    }
}
