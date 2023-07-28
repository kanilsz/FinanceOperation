using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceOperation.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropositionsEntityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Summary",
                table: "Deposits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Deposits",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "Summary",
                table: "Credits",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Credits",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PropositionNumber", "Summary" },
                values: new object[] { "cf4fdeff-c38f-4156-9073-36cfb3ff6cd3", 1000m });

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime", "Summary" },
                values: new object[] { new DateTime(2023, 7, 28, 17, 51, 0, 108, DateTimeKind.Utc).AddTicks(2954), "e5be29aa-2e38-464e-8769-492625c75ef4", new DateTime(2023, 7, 28, 17, 51, 0, 108, DateTimeKind.Utc).AddTicks(2950), 10001m });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime", "Summary" },
                values: new object[] { new DateTime(2023, 7, 28, 17, 51, 0, 108, DateTimeKind.Utc).AddTicks(3018), "e1505ce8-4a6b-4189-a216-59bca8e28280", new DateTime(2023, 7, 28, 17, 51, 0, 108, DateTimeKind.Utc).AddTicks(3017), 1000m });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PropositionNumber", "Summary" },
                values: new object[] { "ed62b47a-9651-4cbf-a728-1a7bd1847118", 10001m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Summary",
                table: "Deposits",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Deposits",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Summary",
                table: "Credits",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Credits",
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
                columns: new[] { "PropositionNumber", "Summary" },
                values: new object[] { "048dce4a-6fda-4c7b-a7d3-2e838c62b62a", 1000.0 });

            migrationBuilder.UpdateData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime", "Summary" },
                values: new object[] { new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3125), "1effffb5-209f-4523-be11-de814cb23e9e", new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3125), 10001.0 });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDateTime", "PropositionNumber", "StartDateTime", "Summary" },
                values: new object[] { new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3238), "148fa3d9-5bc4-4f0d-a0f1-634f745f7639", new DateTime(2023, 7, 28, 16, 41, 56, 907, DateTimeKind.Utc).AddTicks(3237), 1000.0 });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PropositionNumber", "Summary" },
                values: new object[] { "422f13f1-ea71-40cf-8f9c-6ec711e187a3", 10001.0 });
        }
    }
}
