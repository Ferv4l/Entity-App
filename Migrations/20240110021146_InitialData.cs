using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
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
                    { new Guid("4d67fc4f-3436-4140-b998-477de313808c"), null, "Actividades Pendientes", 20 },
                    { new Guid("b35ae885-e17a-40ca-9de3-8b4c1a7bb2d6"), null, "Actividades Personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaModificacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("4d67fc4f-3436-4140-b998-477de313832c"), new Guid("b35ae885-e17a-40ca-9de3-8b4c1a7bb2d6"), null, new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(684), new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(788), "Baja", "Cosas personales" },
                    { new Guid("4d67fc4f-3436-4140-b998-477de313833c"), new Guid("4d67fc4f-3436-4140-b998-477de313808c"), null, new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(800), new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(801), "Media", "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4d67fc4f-3436-4140-b998-477de313832c"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4d67fc4f-3436-4140-b998-477de313833c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4d67fc4f-3436-4140-b998-477de313808c"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("b35ae885-e17a-40ca-9de3-8b4c1a7bb2d6"));

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
