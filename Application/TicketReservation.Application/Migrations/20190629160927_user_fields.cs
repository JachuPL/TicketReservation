using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TicketReservation.Application.Migrations
{
    public partial class user_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02a05980-7a56-41e9-800e-6bc7f2eca063"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7761459d-f3ae-4af0-996f-4b84bea3b71a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5bc32ae-ffe5-443d-849f-9c796f93299c"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Login", "PasswordHash", "PasswordSalt", "Phone", "Role" },
                values: new object[] { new Guid("c744871e-8e30-4bef-b0df-9a0bee8b01b9"), null, null, null, "admin", "wQ6cDrcWiFS6LNZ3ieG6DYR9zthofrRs9a6rzxYFXnyu4cFka+a4Ag==", "QN0ZGBESjAY0KkcxouwcuhUa9bbfQd4cV+HCw4xwoULAh4jUqnuUxw==", null, 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Login", "PasswordHash", "PasswordSalt", "Phone", "Role" },
                values: new object[] { new Guid("24e026ad-e069-4ab7-8003-f623a3a3d146"), null, null, null, "cashier", "aSGUzrjSGaN8vWa8nq0bAIfWfu/ZX6hqyRLepNdjG1RrM3xobM9p/g==", "NuU5eKt6sxp5pLUwGOu5HPMChEwXnDNG51lQJd6x8lFGkEFI9tiYJQ==", null, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Login", "PasswordHash", "PasswordSalt", "Phone", "Role" },
                values: new object[] { new Guid("8d4b7ed2-a241-4744-b776-da80cae8e0a9"), null, null, null, "user", "TI/o5T3zrn9XaKkx29WtG27aNRIFd62mhiMiZq2RsglSj8Xr5bpVww==", "KspogfYOBAo0/tXk8poWuihixt2J/9BwJZzfB+NtN1ZT54OHW6VfSA==", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("24e026ad-e069-4ab7-8003-f623a3a3d146"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d4b7ed2-a241-4744-b776-da80cae8e0a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c744871e-8e30-4bef-b0df-9a0bee8b01b9"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("c5bc32ae-ffe5-443d-849f-9c796f93299c"), "admin", "UOhOvyRhsQODsg5zHK2Fg7HyiFPfuHMVxfH+Q3cCusJeWveOwptGTw==", "NjatPUsN7fWNrA5TcOh6qXo7JdqaDoaEKESC0R/Qq+BmMf6tbO+cdg==", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("7761459d-f3ae-4af0-996f-4b84bea3b71a"), "cashier", "6pVcohC92nsfbqZbM8//OerciQB6TbrOyDnTRzjVZYxz6PCXDGGDaw==", "fz5oNiRK56a5cx27G0dA3FHnT+oqjjWooEWJlXQXiFUGx7VCZQEg9g==", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("02a05980-7a56-41e9-800e-6bc7f2eca063"), "user", "lRspeYpetNTf8bRqh2RgIXlR9XGUv9wGwlGtxVuVA0uBySKdg1YpIQ==", "CWDnbhLbmyoErCqKPqCWTL/7MNqM5EhVa4s3o15RqXAJzD9GwxxEBg==", 0 });
        }
    }
}