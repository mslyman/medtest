using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBMigrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date_updated = table.Column<DateTime>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    first_name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    patronymic = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: false),
                    hobby = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "address", "birthday", "date_updated", "email", "first_name", "gender", "hobby", "is_deleted", "patronymic", "phone", "surname" },
                values: new object[] { new Guid("00000000-0000-0000-8000-000000000001"), "Test address", new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 25, 13, 27, 21, 877, DateTimeKind.Utc).AddTicks(3503), "test@test.com", "Петр", 0, null, false, null, null, "Иванов" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
