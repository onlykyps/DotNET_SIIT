using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmTicketApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Cinemas_CinemaID",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Producers_ProducerID",
                table: "Films");

            migrationBuilder.DropTable(
                name: "ActorToFilm");

            migrationBuilder.DropIndex(
                name: "IX_Films_CinemaID",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CinemaID",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "ProducerID",
                table: "Films",
                newName: "ProducerId");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Films",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Films",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Films",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "FilmGenre",
                table: "Films",
                newName: "DurationMinutes");

            migrationBuilder.RenameIndex(
                name: "IX_Films_ProducerID",
                table: "Films",
                newName: "IX_Films_ProducerId");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Films",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Films",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterImageUrl",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is3D = table.Column<bool>(type: "bit", nullable: false),
                    IsReduced = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seats_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<string>(type: "TEXT", nullable: false),
                    BookingReference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CancelledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketReservations_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketReservations_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketReservations_TicketTypes_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CinemaId_Row_SeatNumber",
                table: "Seats",
                columns: new[] { "CinemaId", "Row", "SeatNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SessionId",
                table: "Seats",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CinemaId",
                table: "Sessions",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_FilmId",
                table: "Sessions",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_BookingReference",
                table: "TicketReservations",
                column: "BookingReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_SeatId",
                table: "TicketReservations",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_SessionId",
                table: "TicketReservations",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_TicketTypeId",
                table: "TicketReservations",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Producers_ProducerId",
                table: "Films",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Producers_ProducerId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "TicketReservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "PosterImageUrl",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Films",
                newName: "ProducerID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Films",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Films",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Films",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "DurationMinutes",
                table: "Films",
                newName: "FilmGenre");

            migrationBuilder.RenameIndex(
                name: "IX_Films_ProducerId",
                table: "Films",
                newName: "IX_Films_ProducerID");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerID",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CinemaID",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Films",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Films",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ActorToFilm",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorToFilm", x => new { x.FilmID, x.ActorID });
                    table.ForeignKey(
                        name: "FK_ActorToFilm_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorToFilm_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_CinemaID",
                table: "Films",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_ActorToFilm_ActorID",
                table: "ActorToFilm",
                column: "ActorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Cinemas_CinemaID",
                table: "Films",
                column: "CinemaID",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Producers_ProducerID",
                table: "Films",
                column: "ProducerID",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
