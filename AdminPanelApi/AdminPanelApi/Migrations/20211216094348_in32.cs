using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminPanelApi.Migrations
{
    public partial class in32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Benefit",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Benefit",
                newName: "Image");
        }
    }
}
