using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminPanelApi.Migrations
{
    public partial class intial342232 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "2", "Admin", "Admin" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "3", "SuperAdmin", "SuperAdmin" },
                    { "0E50AF81-221B-43A5-9DA0-B0F2CF5A7DD2", "4", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "Section",
                columns: new[] { "Id", "Index", "SectionName" },
                values: new object[,]
                {
                    { 1, 1, "Home" },
                    { 2, 2, "Home" },
                    { 3, 3, "Home" },
                    { 4, 4, "Home" },
                    { 5, 1, "aboutus" },
                    { 6, 2, "aboutus" },
                    { 7, 1, "footer" }
                });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Description", "DescriptionEn", "Title", "TitleEn" },
                values: new object[,]
                {
                    { 1, "Use the 99Inbound form builder to easily create a great looking form.", "Use the 99Inbound form builder to easily create a great looking form.", "Create a form", "Create a form" },
                    { 2, "Use the 99Inbound form builder to easily create a great looking form.", "Use the 99Inbound form builder to easily create a great looking form.", "Link Zendesk Sell", "Link Zendesk Sell" },
                    { 3, "Use the 99Inbound form builder to easily create a great looking form.", "Use the 99Inbound form builder to easily create a great looking form.", "Publish your form", "Publish your form" }
                });

            migrationBuilder.InsertData(
                table: "SectionImages",
                columns: new[] { "SectionId", "ImagePath" },
                values: new object[] { 1, "" });

            migrationBuilder.InsertData(
                table: "Text",
                columns: new[] { "Id", "Content", "ContentEn", "SectionId", "Title", "TitleEn" },
                values: new object[,]
                {
                    { 17, "", "", 6, "Description Text ", "Description Text " },
                    { 16, "Meet Our Investors", "Meet Our Investors", 6, "Title Text ", "Title Text " },
                    { 15, "", "", 5, "Description Text ", "Description Text " },
                    { 14, "Our Location", "Our Location", 5, "Title Text ", "Title Text " },
                    { 13, "The seamless nature of the service has saved my team a ton of time manually inserting lead data into our CRM and the quick notifications means our response time has dramatically decreased. This has directly resulted in more sales and productivity.", null, 4, "description Text ", "Title Text " },
                    { 12, "Customers love using 99inbound for their forms", "Customers love using 99inbound for their forms", 4, "Title Text ", "Title Text " },
                    { 11, "Our forms do a lot of heavy lifting so you don't have to.Create LeadsNew submissions create a lead and add a note with all the form values.", "Our forms do a lot of heavy lifting so you don't have to.Create LeadsNew submissions create a lead and add a note with all the form values.", 3, "description Text ", "Title Text " },
                    { 10, "Zendesk Sell lead capture automation", "Zendesk Sell lead capture automation", 3, "Title Text ", "Title Text " },
                    { 9, "", "", 2, "description Text ", "Title Text " },
                    { 8, "How it works", "How it works", 2, "Title Text ", "Title Text " },
                    { 7, "Get started free", "Get started free", 1, "button  Text ", "Title Text " },
                    { 6, "Build forms and share them online. Get an email or Slack message for each submission.", "Build forms and share them online. Get an email or Slack message for each submission.", 1, "description Text ", "description Text " },
                    { 5, "in minutes", "in minutes", 1, "Title Text ", "Title Text " },
                    { 4, "HTML characters &times; &copy;", "HTML characters &times; &copy;", 1, "Animated Text ", "Animated Text " },
                    { 3, "Some strings are bold", "Some strings are bold", 1, "Animated Text ", "Animated Text " },
                    { 2, "are slanted", "are slanted", 1, "Animated Text ", "Animated Text " },
                    { 1, "Build a", "Build a", 1, "Title Text ", "Title Text " },
                    { 19, "Solutions for Ships Tracking", "Solutions for Ships Tracking", 7, "Text ", "Text " },
                    { 20, "Copyright © 2021. All rights reserved ", "Copyright © 2021. All rights reserved", 7, "Text ", "Text " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0E50AF81-221B-43A5-9DA0-B0F2CF5A7DD2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.DeleteData(
                table: "SectionImages",
                keyColumn: "SectionId",
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Text",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Section",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Section",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Section",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Section",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Section",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Section",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Section",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
