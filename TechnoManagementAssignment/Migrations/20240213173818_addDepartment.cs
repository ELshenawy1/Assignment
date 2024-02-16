using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnoManagementAssignment.Migrations
{
    /// <inheritdoc />
    public partial class addDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b72d547-907b-41cc-a209-6a584a63b016", "AQAAAAIAAYagAAAAEK7Loh+R3R8uVmiKPgJNV6A0XMWAvpOv+xyem/kPXpkgm6c/KdQCf5uZHU9OtoXcQQ==" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SD" },
                    { 2, ".Net" },
                    { 3, "OS" },
                    { 4, "PHP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "673e1ffc-ee06-4ed0-9aaf-b8e79876b6d1", "AQAAAAIAAYagAAAAEG4TnnY+KVIL/xgWNW4neJ+PmwXU4MWbMh4T9X/FG9iPAqjDveZW7I76uDEd5ny6KA==" });
        }
    }
}
