using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateTwoOldPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(2297),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 126, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(6476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(9347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(7667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(3597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(1442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.AlterColumn<int>(
                name: "PercentDiscount",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(5566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(9785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(8321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(3481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 695, DateTimeKind.Local).AddTicks(9896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(1831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(9775));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 126, DateTimeKind.Local).AddTicks(1010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(9118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(4885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(7667),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 125, DateTimeKind.Local).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(9562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.AlterColumn<int>(
                name: "PercentDiscount",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(3071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(5566));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(8039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(6561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 124, DateTimeKind.Local).AddTicks(1346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(7979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 695, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 34, 10, 123, DateTimeKind.Local).AddTicks(9775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(1831));
        }
    }
}
