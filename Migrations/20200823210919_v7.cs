using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalPad.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<int>(nullable: false),
                    Rent_Ammount = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms_reg",
                columns: table => new
                {
                    Room_number = table.Column<string>(nullable: false),
                    Rental_reg = table.Column<int>(nullable: false),
                    Room_category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms_reg", x => x.Room_number);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    National_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Full_names = table.Column<string>(maxLength: 50, nullable: false),
                    Phone_number = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Start_date = table.Column<string>(nullable: false),
                    End_date = table.Column<string>(nullable: true),
                    Rental_reg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.National_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room_Category");

            migrationBuilder.DropTable(
                name: "Rooms_reg");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
