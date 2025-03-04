using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class OldPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(9080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 638, DateTimeKind.Local).AddTicks(8919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(7640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 638, DateTimeKind.Local).AddTicks(5718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(9942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(9055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(3520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 638, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(7178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(5065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(3759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(9367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(3521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(1918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(7665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(4339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(6148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.CreateTable(
                name: "DiscountUsageHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountUsageHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountUsageHistories_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountUsageHistories_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountUsageHistories_DiscountId",
                table: "DiscountUsageHistories",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountUsageHistories_OrderId",
                table: "DiscountUsageHistories",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountUsageHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 638, DateTimeKind.Local).AddTicks(8919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 638, DateTimeKind.Local).AddTicks(5718),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(9055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(9942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 638, DateTimeKind.Local).AddTicks(3339),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 44, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(5825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(3759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(7773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(2050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 637, DateTimeKind.Local).AddTicks(483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 43, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(5872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(1653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 2, 14, 47, 55, 636, DateTimeKind.Local).AddTicks(3609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 31, 49, 42, DateTimeKind.Local).AddTicks(6148));
        }
    }
}
