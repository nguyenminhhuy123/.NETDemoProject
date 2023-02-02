using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netcore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owner",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Car",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Owner",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Car",
                type: "int",
                maxLength: 30,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
