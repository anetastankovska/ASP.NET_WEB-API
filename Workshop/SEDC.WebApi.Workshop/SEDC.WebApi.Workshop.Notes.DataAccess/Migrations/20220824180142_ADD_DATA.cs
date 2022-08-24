using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.WebApi.Workshop.Notes.DataAccess.Migrations
{
    public partial class ADD_DATA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "Color", "Tag", "Text", "UserId" },
                values: new object[] { 1, "Orange", 1, "Buy Juice", 1 });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "Color", "Tag", "Text", "UserId" },
                values: new object[] { 2, "Green", 2, "Learn ASP.Net Core Web Api", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Note",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Note",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
