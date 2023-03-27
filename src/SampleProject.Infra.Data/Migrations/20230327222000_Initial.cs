using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleProject.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ADDRESS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    City = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADDRESS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PHONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PHONE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_COMPANY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FantasyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMPANY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_COMPANY_TB_ADDRESS_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TB_ADDRESS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EMPLOYEE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sex = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TelephoneId = table.Column<int>(type: "int", nullable: true),
                    CellphoneId = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EMPLOYEE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_EMPLOYEE_TB_ADDRESS_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TB_ADDRESS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_EMPLOYEE_TB_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "TB_COMPANY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_EMPLOYEE_TB_PHONE_CellphoneId",
                        column: x => x.CellphoneId,
                        principalTable: "TB_PHONE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_EMPLOYEE_TB_PHONE_TelephoneId",
                        column: x => x.TelephoneId,
                        principalTable: "TB_PHONE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMPANY_AddressId",
                table: "TB_COMPANY",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EMPLOYEE_AddressId",
                table: "TB_EMPLOYEE",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EMPLOYEE_CellphoneId",
                table: "TB_EMPLOYEE",
                column: "CellphoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EMPLOYEE_CompanyId",
                table: "TB_EMPLOYEE",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EMPLOYEE_TelephoneId",
                table: "TB_EMPLOYEE",
                column: "TelephoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_EMPLOYEE");

            migrationBuilder.DropTable(
                name: "TB_COMPANY");

            migrationBuilder.DropTable(
                name: "TB_PHONE");

            migrationBuilder.DropTable(
                name: "TB_ADDRESS");
        }
    }
}
