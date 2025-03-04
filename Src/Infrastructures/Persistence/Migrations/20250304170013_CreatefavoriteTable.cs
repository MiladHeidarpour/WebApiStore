using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CreatefavoriteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(6534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(5156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(3542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(7861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(5794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(7812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(5566));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(4007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(2551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(5975),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(2380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 695, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(4342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.CreateTable(
                name: "CatalogItemFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(1151)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItemFavorites_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemFavorites_CatalogItemId",
                table: "CatalogItemFavorites",
                column: "CatalogItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItemFavorites");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(2297),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 698, DateTimeKind.Local).AddTicks(887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(5156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(6476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(9347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 618, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(3597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 697, DateTimeKind.Local).AddTicks(1442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(5794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(5566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(9785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(8321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 617, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(3481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 695, DateTimeKind.Local).AddTicks(9896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 4, 10, 47, 2, 696, DateTimeKind.Local).AddTicks(1831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 3, 4, 20, 30, 13, 616, DateTimeKind.Local).AddTicks(4342));
        }
    }
}
