using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    idCustomer = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthdayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RgNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.idCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    idAddress = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomeridCustomer = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.idAddress);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomeridCustomer",
                        column: x => x.CustomeridCustomer,
                        principalTable: "Customer",
                        principalColumn: "idCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Number",
                columns: table => new
                {
                    idNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomeridCustomer = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.idNumber);
                    table.ForeignKey(
                        name: "FK_Number_Customer_CustomeridCustomer",
                        column: x => x.CustomeridCustomer,
                        principalTable: "Customer",
                        principalColumn: "idCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    idSocialMedia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomeridCustomer = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.idSocialMedia);
                    table.ForeignKey(
                        name: "FK_SocialMedia_Customer_CustomeridCustomer",
                        column: x => x.CustomeridCustomer,
                        principalTable: "Customer",
                        principalColumn: "idCustomer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomeridCustomer",
                table: "Address",
                column: "CustomeridCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Number_CustomeridCustomer",
                table: "Number",
                column: "CustomeridCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_CustomeridCustomer",
                table: "SocialMedia",
                column: "CustomeridCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Number");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
