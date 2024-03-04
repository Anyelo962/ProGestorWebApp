using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGestor.Infraestruture.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionEnInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtherExpenses",
                table: "Invoice",
                newName: "PaymentType");

            migrationBuilder.RenameColumn(
                name: "MaterialUsed",
                table: "Invoice",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LaborUsed",
                table: "Invoice",
                newName: "DescriptionProject");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Invoice",
                newName: "OtherExpenses");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Invoice",
                newName: "MaterialUsed");

            migrationBuilder.RenameColumn(
                name: "DescriptionProject",
                table: "Invoice",
                newName: "LaborUsed");
        }
    }
}
