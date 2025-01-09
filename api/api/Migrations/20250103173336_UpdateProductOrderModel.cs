using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrders_Orders_OrderID",
                table: "ProductsOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductsOrders_OrderID",
                table: "ProductsOrders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "ProductsOrders");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_OrderId",
                table: "ProductsOrders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrders_Orders_OrderId",
                table: "ProductsOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrders_Orders_OrderId",
                table: "ProductsOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductsOrders_OrderId",
                table: "ProductsOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "ProductsOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_OrderID",
                table: "ProductsOrders",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrders_Orders_OrderID",
                table: "ProductsOrders",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
