using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Owner_OwnersId",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_OwnersId",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameColumn(
                name: "OwnersId",
                table: "Cars",
                newName: "IdReceipt");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Bithdate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipt_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdReceipt",
                table: "Cars",
                column: "IdReceipt",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_OwnerId",
                table: "Receipt",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_VendorId",
                table: "Receipt",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Receipt_IdReceipt",
                table: "Cars",
                column: "IdReceipt",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Receipt_IdReceipt",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_IdReceipt",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameColumn(
                name: "IdReceipt",
                table: "Car",
                newName: "OwnersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Car_OwnersId",
                table: "Car",
                column: "OwnersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Owner_OwnersId",
                table: "Car",
                column: "OwnersId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
