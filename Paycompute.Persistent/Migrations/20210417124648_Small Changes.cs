using Microsoft.EntityFrameworkCore.Migrations;

namespace Paycompute.Persistent.Migrations
{
    public partial class SmallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NiNo",
                table: "PaymentRecords");

            migrationBuilder.RenameColumn(
                name: "NIC",
                table: "PaymentRecords",
                newName: "PFC");

            migrationBuilder.AddColumn<decimal>(
                name: "OverTimeEarnings",
                table: "PaymentRecords",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UAN",
                table: "PaymentRecords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverTimeEarnings",
                table: "PaymentRecords");

            migrationBuilder.DropColumn(
                name: "UAN",
                table: "PaymentRecords");

            migrationBuilder.RenameColumn(
                name: "PFC",
                table: "PaymentRecords",
                newName: "NIC");

            migrationBuilder.AddColumn<string>(
                name: "NiNo",
                table: "PaymentRecords",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
