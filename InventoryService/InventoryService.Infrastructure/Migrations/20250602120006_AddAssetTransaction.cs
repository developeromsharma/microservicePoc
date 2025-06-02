using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "AssetTransactions");

            migrationBuilder.RenameColumn(
                name: "CheckoutDate",
                table: "AssetTransactions",
                newName: "Timestamp");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AssetTransactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "AssetTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "AssetTransactions");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "AssetTransactions",
                newName: "CheckoutDate");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AssetTransactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "AssetTransactions",
                type: "datetime2",
                nullable: true);
        }
    }
}
