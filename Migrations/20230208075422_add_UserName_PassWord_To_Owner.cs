using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore.Migrations
{
    /// <inheritdoc />
    public partial class addUserNamePassWordToOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Owner",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Owner");
        }
    }
}
