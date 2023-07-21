using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceOperation.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserIdentityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserIdentityId);
                });

            migrationBuilder.CreateTable(
                name: "CreditProposition",
                columns: table => new
                {
                    CreditPropositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdentityId = table.Column<int>(type: "int", nullable: false),
                    PropositionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditProposition", x => x.CreditPropositionId);
                    table.ForeignKey(
                        name: "FK_CreditProposition_Users_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "Users",
                        principalColumn: "UserIdentityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositProposition",
                columns: table => new
                {
                    DepositPropositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdentityId = table.Column<int>(type: "int", nullable: false),
                    PropositionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositProposition", x => x.DepositPropositionId);
                    table.ForeignKey(
                        name: "FK_DepositProposition_Users_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "Users",
                        principalColumn: "UserIdentityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditProposition_UserIdentityId",
                table: "CreditProposition",
                column: "UserIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositProposition_UserIdentityId",
                table: "DepositProposition",
                column: "UserIdentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditProposition");

            migrationBuilder.DropTable(
                name: "DepositProposition");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
