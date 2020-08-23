using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalPad.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rentals_reg",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    National_id = table.Column<int>(nullable: false),
                    Rental_OwnersNational_id = table.Column<int>(nullable: true),
                    R_name = table.Column<string>(nullable: false),
                    R_location = table.Column<string>(nullable: false),
                    No_rooms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals_reg", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rentals_reg_Rental_owners_Rental_OwnersNational_id",
                        column: x => x.Rental_OwnersNational_id,
                        principalTable: "Rental_owners",
                        principalColumn: "National_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_reg_Rental_OwnersNational_id",
                table: "Rentals_reg",
                column: "Rental_OwnersNational_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals_reg");
        }
    }
}
