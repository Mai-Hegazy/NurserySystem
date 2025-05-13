using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurserySystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChildProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Allergies",
                table: "Children",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Children",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Children",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Children",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Children",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Children",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Children");

            migrationBuilder.AlterColumn<string>(
                name: "Allergies",
                table: "Children",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
