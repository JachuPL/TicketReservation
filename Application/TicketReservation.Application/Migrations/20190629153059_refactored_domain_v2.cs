using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TicketReservation.Application.Migrations
{
    public partial class refactored_domain_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a01a2df-a56a-4a45-ac9f-6136e6e8e93b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aede5155-1ff0-4773-94ce-8e1d5381d15f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b5b31071-9562-4fc8-b065-b343b6748e7b"));

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "ReservedSeats");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Reservations",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Reservations");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "ReservedSeats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("aede5155-1ff0-4773-94ce-8e1d5381d15f"), "admin", "dt6W6xHtY4pK2//53ULGwywWkqKq6j9hbrLRdtUO5x0yDB1FNSJvMw==", "bUWtXRtWVDDYcSU4GeP7juBAWlBBw+29Cv29VxOsRbhfy5AGvLY3Nw==", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("3a01a2df-a56a-4a45-ac9f-6136e6e8e93b"), "cashier", "VbBm9VM/XwuggYdKnh7NV57SIn4BgFXXD7NkKgOKkQnmF44lXXk0+w==", "5zKzkYZN/DTsTM0xjmUN1ZuRdjhgkGFYT1EaK3xRjbeHGmEuzbBKcg==", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("b5b31071-9562-4fc8-b065-b343b6748e7b"), "user", "D5ycKTP6Ri4zBcmtgU0v52hlYsbKEzCeKSofn8R229uPEGF/JDiwtg==", "lqiBu4LSWiKfBghl7PrgzYi914NAs7hUxnjdWODzsEY6Fy/zmmxhAw==", 0 });
        }
    }
}