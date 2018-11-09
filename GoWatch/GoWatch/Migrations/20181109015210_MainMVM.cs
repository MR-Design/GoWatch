using Microsoft.EntityFrameworkCore.Migrations;

namespace GoWatch.Migrations
{
    public partial class MainMVM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Fans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "EventsPlace",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventsPlace",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Fans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Events",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
