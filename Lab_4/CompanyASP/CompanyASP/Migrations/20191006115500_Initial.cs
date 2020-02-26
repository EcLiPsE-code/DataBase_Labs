using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyASP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    CountEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    Profit = table.Column<decimal>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    UnitID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitValuationFacts",
                columns: table => new
                {
                    UnitValuationFactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Profit = table.Column<decimal>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    UnitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitValuationFacts", x => x.UnitValuationFactID);
                    table.ForeignKey(
                        name: "FK_UnitValuationFacts_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFacts",
                columns: table => new
                {
                    EmployeeFactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ProfitYear = table.Column<decimal>(nullable: false),
                    ProfitQuarter = table.Column<decimal>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFacts", x => x.EmployeeFactID);
                    table.ForeignKey(
                        name: "FK_EmployeeFacts_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressEmployees",
                columns: table => new
                {
                    ProgressEmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Progress = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressEmployees", x => x.ProgressEmployeeID);
                    table.ForeignKey(
                        name: "FK_ProgressEmployees_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitValuationPlans",
                columns: table => new
                {
                    UnitValuationPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Profit = table.Column<decimal>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    UnitValuationFactID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitValuationPlans", x => x.UnitValuationPlanID);
                    table.ForeignKey(
                        name: "FK_UnitValuationPlans_UnitValuationFacts_UnitValuationFactID",
                        column: x => x.UnitValuationFactID,
                        principalTable: "UnitValuationFacts",
                        principalColumn: "UnitValuationFactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePlans",
                columns: table => new
                {
                    EmployeePlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ProfitQuarter = table.Column<decimal>(nullable: false),
                    ProfitYear = table.Column<decimal>(nullable: false),
                    EmployeeFactID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePlans", x => x.EmployeePlanID);
                    table.ForeignKey(
                        name: "FK_EmployeePlans_EmployeeFacts_EmployeeFactID",
                        column: x => x.EmployeeFactID,
                        principalTable: "EmployeeFacts",
                        principalColumn: "EmployeeFactID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFacts_EmployeeID",
                table: "EmployeeFacts",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePlans_EmployeeFactID",
                table: "EmployeePlans",
                column: "EmployeeFactID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UnitID",
                table: "Employees",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressEmployees_EmployeeID",
                table: "ProgressEmployees",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitValuationFacts_UnitID",
                table: "UnitValuationFacts",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_UnitValuationPlans_UnitValuationFactID",
                table: "UnitValuationPlans",
                column: "UnitValuationFactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePlans");

            migrationBuilder.DropTable(
                name: "ProgressEmployees");

            migrationBuilder.DropTable(
                name: "UnitValuationPlans");

            migrationBuilder.DropTable(
                name: "EmployeeFacts");

            migrationBuilder.DropTable(
                name: "UnitValuationFacts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
