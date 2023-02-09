using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore.Migrations
{
    /// <inheritdoc />
    public partial class convertOwnertoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Owner_IdOwner",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.RenameColumn(
                name: "IdOwner",
                table: "Receipts",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_IdOwner",
                table: "Receipts",
                newName: "IX_Receipts_IdUser");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_User_IdUser",
                table: "Receipts",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_User_IdUser",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Receipts",
                newName: "IdOwner");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_IdUser",
                table: "Receipts",
                newName: "IX_Receipts_IdOwner");

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Owner_IdOwner",
                table: "Receipts",
                column: "IdOwner",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
