using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminPanelApi.Migrations
{
    public partial class in3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DdescriptionEn",
                table: "Benefit",
                newName: "DescriptionEn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionEn",
                table: "Benefit",
                newName: "DdescriptionEn");
        }
    }
}
