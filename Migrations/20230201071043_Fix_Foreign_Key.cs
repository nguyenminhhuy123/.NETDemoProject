using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Receipt_IdReceipt",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Owner_OwnerId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Vendor_VendorId",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_IdReceipt",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IdReceipt",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_VendorId",
                table: "Receipts",
                newName: "IX_Receipts_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_OwnerId",
                table: "Receipts",
                newName: "IX_Receipts_OwnerId");

            migrationBuilder.AddColumn<int>(
                name: "IdCar",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_IdCar",
                table: "Receipts",
                column: "IdCar",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Car_IdCar",
                table: "Receipts",
                column: "IdCar",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Owner_OwnerId",
                table: "Receipts",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Vendor_VendorId",
                table: "Receipts",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Car_IdCar",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Owner_OwnerId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Vendor_VendorId",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_IdCar",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "IdCar",
                table: "Receipts");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_VendorId",
                table: "Receipt",
                newName: "IX_Receipt_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_OwnerId",
                table: "Receipt",
                newName: "IX_Receipt_OwnerId");

            migrationBuilder.AddColumn<int>(
                name: "IdReceipt",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdReceipt",
                table: "Cars",
                column: "IdReceipt",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Receipt_IdReceipt",
                table: "Cars",
                column: "IdReceipt",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Owner_OwnerId",
                table: "Receipt",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Vendor_VendorId",
                table: "Receipt",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
