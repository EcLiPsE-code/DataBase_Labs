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
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    CountEmployees = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Solution = table.Column<decimal>(nullable: true),
                    Profit = table.Column<decimal>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitsValuationFact",
                columns: table => new
                {
                    UnitValuationFactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Income = table.Column<decimal>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    UnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsValuationFact", x => x.UnitValuationFactId);
                    table.ForeignKey(
                        name: "FK_UnitsValuationFact_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFact",
                columns: table => new
                {
                    EmployeeFactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Quarter = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    ProfitYear = table.Column<decimal>(nullable: true),
                    ProfitQuarter = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFact", x => x.EmployeeFactId);
                    table.ForeignKey(
                        name: "FK_EmployeeFact_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgressEmployees",
                columns: table => new
                {
                    ProgressEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Progress = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressEmployees", x => x.ProgressEmployeeId);
                    table.ForeignKey(
                        name: "FK_ProgressEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitsValuationPlans",
                columns: table => new
                {
                    UnitValuationPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Income = table.Column<decimal>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    UnitValuationFactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsValuationPlans", x => x.UnitValuationPlanId);
                    table.ForeignKey(
                        name: "FK_UnitsValuationPlans_UnitsValuationFact_UnitValuationFactId",
                        column: x => x.UnitValuationFactId,
                        principalTable: "UnitsValuationFact",
                        principalColumn: "UnitValuationFactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePlans",
                columns: table => new
                {
                    EmployeePlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Quarter = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    EmployeeFactId = table.Column<int>(nullable: true),
                    ProfitQuarter = table.Column<decimal>(nullable: true),
                    ProfitYear = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePlans", x => x.EmployeePlanId);
                    table.ForeignKey(
                        name: "FK_EmployeePlans_EmployeeFact_EmployeeFactId",
                        column: x => x.EmployeeFactId,
                        principalTable: "EmployeeFact",
                        principalColumn: "EmployeeFactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFact_EmployeeId",
                table: "EmployeeFact",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePlans_EmployeeFactId",
                table: "EmployeePlans",
                column: "EmployeeFactId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UnitId",
                table: "Employees",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressEmployees_EmployeeId",
                table: "ProgressEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitsValuationFact_UnitId",
                table: "UnitsValuationFact",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitsValuationPlans_UnitValuationFactId",
                table: "UnitsValuationPlans",
                column: "UnitValuationFactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePlans");

            migrationBuilder.DropTable(
                name: "ProgressEmployees");

            migrationBuilder.DropTable(
                name: "UnitsValuationPlans");

            migrationBuilder.DropTable(
                name: "EmployeeFact");

            migrationBuilder.DropTable(
                name: "UnitsValuationFact");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
