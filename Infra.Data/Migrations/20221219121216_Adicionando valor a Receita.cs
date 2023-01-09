﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandovaloraReceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Receitas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Receitas");
        }
    }
}
