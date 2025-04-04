using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingRoomScheduling.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPeopleQuantityBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeopleQuantity",
                table: "Booking",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeopleQuantity",
                table: "Booking");
        }
    }
}
