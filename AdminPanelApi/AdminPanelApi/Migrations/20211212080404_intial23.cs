using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminPanelApi.Migrations
{
    public partial class intial23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Description", "DescriptionEn", "Title", "TitleEn" },
                values: new object[] { 1, "Use the 99Inbound form builder to easily create a great looking form.", "Use the 99Inbound form builder to easily create a great looking form.", "Create a form", "Create a form" });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Description", "DescriptionEn", "Title", "TitleEn" },
                values: new object[] { 2, "Use the 99Inbound form builder to easily create a great looking form.", "Use the 99Inbound form builder to easily create a great looking form.", "Link Zendesk Sell", "Link Zendesk Sell" });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Description", "DescriptionEn", "Title", "TitleEn" },
                values: new object[] { 3, "Use the 99Inbound form builder to easily create a great looking form.", "Use the 99Inbound form builder to easily create a great looking form.", "Publish your form", "Publish your form" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Step",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Step",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Step",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
