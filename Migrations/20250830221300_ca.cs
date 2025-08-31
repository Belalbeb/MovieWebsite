using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_App.Migrations
{
    /// <inheritdoc />
    public partial class ca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Movies_MovieId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_UserId1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_UserId1",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "Items",
                newName: "IX_Items_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_MovieId",
                table: "Items",
                newName: "IX_Items_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Movies_MovieId",
                table: "Items",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_orders_OrderId",
                table: "Items",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Movies_MovieId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_orders_OrderId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_UserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_UserId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_MovieId",
                table: "OrderItem",
                newName: "IX_OrderItem_MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId1",
                table: "orders",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Movies_MovieId",
                table: "OrderItem",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_UserId1",
                table: "orders",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
