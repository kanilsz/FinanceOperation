using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceOperation.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropositionsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 1,
                column: "PropositionNumber",
                value: "048dce4a-6fda-4c7b-a7d3-2e838c62b62a");

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime" },
                values: new object[] { new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3125), "1effffb5-209f-4523-be11-de814cb23e9e", new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3125) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime" },
                values: new object[] { new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3238), "148fa3d9-5bc4-4f0d-a0f1-634f745f7639", new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3237) });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2,
                column: "PropositionNumber",
                value: "422f13f1-ea71-40cf-8f9c-6ec711e187a3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);
        }
    }
}
