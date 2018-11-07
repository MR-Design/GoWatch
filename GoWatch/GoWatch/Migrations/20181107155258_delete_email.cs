using Microsoft.EntityFrameworkCore.Migrations;

namespace GoWatch.Migrations
{
    public partial class delete_email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Fans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Fans",
                nullable: true);
        }
    }
}
