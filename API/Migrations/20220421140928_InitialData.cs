using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "Address", "Name", "State" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "15b Abaga Da", "De Pema Gift", "Edo" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "Address", "Name", "State" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "20n Durosimi", "Jessey Children", "Lagos" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "Name", "SchoolId", "Year" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 12, "Kane Miller", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Year 10" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "Name", "SchoolId", "Year" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 15, "Taiwo Akin", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Year 12" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "Name", "SchoolId", "Year" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 14, "God Knows", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Year 15" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
