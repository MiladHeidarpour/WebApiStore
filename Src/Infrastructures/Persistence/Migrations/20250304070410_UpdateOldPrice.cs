using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateOldPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 126, DateTimeKind.Local).AddTicks(1010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(9118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(4885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(9942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(7667),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(9562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(3071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.AddColumn<int>(
                name: "OldPrice",
                table: "CatalogItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentDiscount",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(8039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(6561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(1346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(7979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(9775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(6148));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "PercentDiscount",
                table: "CatalogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(9080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 126, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(7640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(9942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(3520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(7667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(7178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(5065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(9367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(3521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(1918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(7665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(4339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(6148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(9775));
        }
    }
}
