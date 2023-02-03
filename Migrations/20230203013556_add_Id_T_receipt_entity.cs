using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore.Migrations
{
    /// <inheritdoc />
    public partial class addIdTreceiptentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Owner_OwnerId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Vendor_VendorId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Receipts",
                newName: "IdVendor");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Receipts",
                newName: "IdOwner");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_VendorId",
                table: "Receipts",
                newName: "IX_Receipts_IdVendor");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_OwnerId",
                table: "Receipts",
                newName: "IX_Receipts_IdOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Owner_IdOwner",
                table: "Receipts",
                column: "IdOwner",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Vendor_IdVendor",
                table: "Receipts",
                column: "IdVendor",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Owner_IdOwner",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Vendor_IdVendor",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "IdVendor",
                table: "Receipts",
                newName: "VendorId");

            migrationBuilder.RenameColumn(
                name: "IdOwner",
                table: "Receipts",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_IdVendor",
                table: "Receipts",
                newName: "IX_Receipts_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_IdOwner",
                table: "Receipts",
                newName: "IX_Receipts_OwnerId");

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
    }
}
