using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceOperation.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepositId",
                table: "Deposits",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreditId",
                table: "Credits",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 1,
                column: "PropositionNumber",
                value: "afe1cf32-43da-48b1-9fcf-6b3e4365c0fa");

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime" },
                values: new object[] { new DateTime(2023, 7, 27, 18, 21, 0, 223, DateTimeKind.Utc).AddTicks(5023), "39c16a3e-a7e2-4efb-9cd7-47dbbef4fd17", new DateTime(2023, 7, 27, 18, 21, 0, 223, DateTimeKind.Utc).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime" },
                values: new object[] { new DateTime(2023, 7, 27, 18, 21, 0, 223, DateTimeKind.Utc).AddTicks(5093), "01a8a114-bbfc-4ab1-8589-b2fd60ac7094", new DateTime(2023, 7, 27, 18, 21, 0, 223, DateTimeKind.Utc).AddTicks(5093) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2,
                column: "PropositionNumber",
                value: "981ee068-a2c2-4fdb-8a2e-8d51dd8b0254");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Deposits",
                newName: "DepositId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Credits",
                newName: "CreditId");

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "CreditId",
                keyValue: 1,
                column: "PropositionNumber",
                value: "5e639614-36ca-4f99-bff5-42dc131e0407");

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "CreditId",
                keyValue: 2,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime" },
                values: new object[] { new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3954), "5d98ac45-6899-4b93-8291-04d82814b318", new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 1,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime" },
                values: new object[] { new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3990), "698fef24-d466-441c-8712-3ca222e20c27", new DateTime(2023, 7, 22, 12, 8, 2, 479, DateTimeKind.Utc).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "DepositId",
                keyValue: 2,
                column: "PropositionNumber",
                value: "3becfec9-9dbb-4f78-b789-8a6ec0edb30b");
        }
    }
}
