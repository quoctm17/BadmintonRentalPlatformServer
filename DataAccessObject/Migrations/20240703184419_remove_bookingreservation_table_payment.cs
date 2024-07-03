using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class remove_bookingreservation_table_payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingReservations_Payments_PaymentEntityId",
                table: "BookingReservations");

            migrationBuilder.DropIndex(
                name: "IX_BookingReservations_PaymentEntityId",
                table: "BookingReservations");

            migrationBuilder.DropColumn(
                name: "PaymentEntityId",
                table: "BookingReservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentEntityId",
                table: "BookingReservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingReservations_PaymentEntityId",
                table: "BookingReservations",
                column: "PaymentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingReservations_Payments_PaymentEntityId",
                table: "BookingReservations",
                column: "PaymentEntityId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
