using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketing.Client.Migrations
{
    public partial class TicketRequestorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Requestor",
                table: "Tickets",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requestor",
                table: "Tickets");
        }
    }
}
