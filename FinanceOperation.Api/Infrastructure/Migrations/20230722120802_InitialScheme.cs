using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceOperation.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    CreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PropositionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.CreditId);
                    table.ForeignKey(
                        name: "FK_Credits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    DepositId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PropositionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.DepositId);
                    table.ForeignKey(
                        name: "FK_Deposits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "CreditId", "EndDateTime", "IsDeleted", "Percentage", "PropositionNumber", "StartDateTime", "Summary", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1000.0, "5e639614-36ca-4f99-bff5-42dc131e0407", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.0, null });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "DepositId", "EndDateTime", "IsDeleted", "Percentage", "PropositionNumber", "StartDateTime", "Summary", "UserId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 102.0, "3becfec9-9dbb-4f78-b789-8a6ec0edb30b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10001.0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "IsDeleted", "Password", "PhoneNumber", "SecondName" },
                values: new object[] { 1, "kon@gmail.com", "Maksym", false, "password", null, "Konotop" });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "CreditId", "EndDateTime", "IsDeleted", "Percentage", "PropositionNumber", "StartDateTime", "Summary", "UserId" },
                values: new object[] { 2, new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3954), false, 102.0, "5d98ac45-6899-4b93-8291-04d82814b318", new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3951), 10001.0, 1 });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "DepositId", "EndDateTime", "IsDeleted", "Percentage", "PropositionNumber", "StartDateTime", "Summary", "UserId" },
                values: new object[] { 1, new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3990), false, 1000.0, "698fef24-d466-441c-8712-3ca222e20c27", new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3989), 1000.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_UserId",
                table: "Credits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_UserId",
                table: "Deposits",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
