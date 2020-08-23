using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalPad.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rental_owners",
                columns: table => new
                {
                    National_id = table.Column<int>(nullable: false),
                    Full_names = table.Column<int>(maxLength: 50, nullable: false),
                    Phone_number = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Paybill_number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental_owners", x => x.National_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental_owners");
        }
    }
}
