using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DelmarApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    OfficePhone = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    FaxPhone = table.Column<string>(nullable: true),
                    OtherPhoneType = table.Column<string>(nullable: true),
                    OtherPhone = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertySubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertySubTypes_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ForLease = table.Column<bool>(nullable: false),
                    ForSale = table.Column<bool>(nullable: false),
                    PurchasePrice = table.Column<decimal>(nullable: false),
                    RentalPrice = table.Column<decimal>(nullable: false),
                    BuildingSize = table.Column<int>(nullable: false),
                    OfficeSize = table.Column<int>(nullable: false),
                    MinUnits = table.Column<int>(nullable: false),
                    MaxUnits = table.Column<int>(nullable: false),
                    Floors = table.Column<int>(nullable: false),
                    YearBuilt = table.Column<int>(nullable: false),
                    LotSize = table.Column<decimal>(nullable: false),
                    ParkingSpaces = table.Column<int>(nullable: false),
                    ApnParcelId = table.Column<string>(nullable: true),
                    DockHighDoors = table.Column<int>(nullable: false),
                    GroundLevelDoors = table.Column<int>(nullable: false),
                    ForSaleSince = table.Column<DateTime>(nullable: false),
                    AvailForLease = table.Column<DateTime>(nullable: false),
                    LeaseEnd = table.Column<DateTime>(nullable: false),
                    LeaseAreaSize = table.Column<int>(nullable: false),
                    LeaseFloor = table.Column<int>(nullable: false),
                    LeaseUnitNumber = table.Column<string>(nullable: true),
                    BrochureFileName = table.Column<string>(nullable: true),
                    PropertyTypeId = table.Column<int>(nullable: false),
                    PropertySubTypeId = table.Column<int>(nullable: false),
                    SaleTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertySubTypes_PropertySubTypeId",
                        column: x => x.PropertySubTypeId,
                        principalTable: "PropertySubTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_SaleTypes_SaleTypeId",
                        column: x => x.SaleTypeId,
                        principalTable: "SaleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAndUserLinks",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAndUserLinks", x => new { x.PropertyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PropertyAndUserLinks_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAndUserLinks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyPictures_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertySubTypeId",
                table: "Properties",
                column: "PropertySubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SaleTypeId",
                table: "Properties",
                column: "SaleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAndUserLinks_UserId",
                table: "PropertyAndUserLinks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPictures_PropertyId",
                table: "PropertyPictures",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySubTypes_PropertyTypeId",
                table: "PropertySubTypes",
                column: "PropertyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingClasses");

            migrationBuilder.DropTable(
                name: "PropertyAndUserLinks");

            migrationBuilder.DropTable(
                name: "PropertyPictures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertySubTypes");

            migrationBuilder.DropTable(
                name: "SaleTypes");

            migrationBuilder.DropTable(
                name: "PropertyTypes");
        }
    }
}
