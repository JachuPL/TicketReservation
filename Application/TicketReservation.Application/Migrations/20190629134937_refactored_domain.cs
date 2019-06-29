using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservation.Application.Migrations
{
    public partial class refactored_domain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Shows_ShowId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedSeats_Reservations_ReservationId",
                table: "ReservedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Cinemas_CinemaId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows");

            migrationBuilder.DropTable(
                name: "CinemaMovies");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2449b5e1-f6bd-40bb-9c38-eb22c5431839"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6feffd38-8779-4029-bc53-7b0dba014a08"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b4230381-cbb4-4509-ab44-5e148cde3e43"));

            migrationBuilder.RenameColumn(
                name: "Column",
                table: "ReservedSeats",
                newName: "Seat");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CinemaId",
                table: "Shows",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReservationId",
                table: "ReservedSeats",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShowId",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Shows_ShowId",
                table: "Reservations",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedSeats_Reservations_ReservationId",
                table: "ReservedSeats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Cinemas_CinemaId",
                table: "Shows",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Shows_ShowId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedSeats_Reservations_ReservationId",
                table: "ReservedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Cinemas_CinemaId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows");

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

            migrationBuilder.RenameColumn(
                name: "Seat",
                table: "ReservedSeats",
                newName: "Column");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "Shows",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CinemaId",
                table: "Shows",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ReservationId",
                table: "ReservedSeats",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ShowId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateTable(
                name: "CinemaMovies",
                columns: table => new
                {
                    CinemaId = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovies", x => new { x.CinemaId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CinemaMovies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("6feffd38-8779-4029-bc53-7b0dba014a08"), "admin", "RBwia7l/XT55UPAXwcG8EeaD9Ptxwlqc1iHXKC9Ud62XEoKVlF+A6w==", "xKE27N+FJPrxbDch8p0E/MOMTd1ueLi9u74Z4sbM+JyGThQileDifA==", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("2449b5e1-f6bd-40bb-9c38-eb22c5431839"), "cashier", "u604IwZO4CqYWZN3F/6BCh3e9xji1O2P57xKrYQHLNnRsv+Y/BPeCQ==", "Dqd/i1QlsgMR2UV9vz0dA/LBiul4s+1eHXL2uMhKa6uszDhY9+80Tg==", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new Guid("b4230381-cbb4-4509-ab44-5e148cde3e43"), "user", "8Wp1FTPfFuV9y3WwbEQAM6WWxrQ27zdMF2ok8ROE1tcIMrBKhCd2sg==", "LwDSAG2EZmhphdnyxKnFUnl0ixvZCjvKwpusqfvmXDaIAkLQmad60A==", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovies_MovieId",
                table: "CinemaMovies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Shows_ShowId",
                table: "Reservations",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedSeats_Reservations_ReservationId",
                table: "ReservedSeats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Cinemas_CinemaId",
                table: "Shows",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
