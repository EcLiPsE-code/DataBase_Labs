using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    CountEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentValuationFacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PerfomanceYear = table.Column<double>(nullable: false),
                    PerfomanceQuarter = table.Column<double>(nullable: false),
                    DepartamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentValuationFacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartamentValuationFacts_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentValuationPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PerfomanceQuarter = table.Column<double>(nullable: false),
                    PerfomanceYear = table.Column<double>(nullable: false),
                    DepartamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentValuationPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartamentValuationPlans_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Raiting = table.Column<double>(nullable: false),
                    DepartamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListDepartamentMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    MarkYear = table.Column<int>(nullable: false),
                    MarkQuarter = table.Column<int>(nullable: false),
                    DepartamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListDepartamentMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListDepartamentMetrics_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PerfomanceQuarter = table.Column<double>(nullable: false),
                    PerfomanceYear = table.Column<double>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PerfomanceQuarter = table.Column<double>(nullable: false),
                    PerfomanceYear = table.Column<double>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePlans_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListEmployeesMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    MarkQuarter = table.Column<int>(nullable: false),
                    MarkYear = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListEmployeesMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListEmployeesMetrics_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Progress = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressEmployees_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentValuationFacts_DepartamentId",
                table: "DepartamentValuationFacts",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentValuationPlans_DepartamentId",
                table: "DepartamentValuationPlans",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFacts_EmployeeId",
                table: "EmployeeFacts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePlans_EmployeeId",
                table: "EmployeePlans",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartamentId",
                table: "Employees",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_ListDepartamentMetrics_DepartamentId",
                table: "ListDepartamentMetrics",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_ListEmployeesMetrics_EmployeeId",
                table: "ListEmployeesMetrics",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressEmployees_EmployeeID",
                table: "ProgressEmployees",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentValuationFacts");

            migrationBuilder.DropTable(
                name: "DepartamentValuationPlans");

            migrationBuilder.DropTable(
                name: "EmployeeFacts");

            migrationBuilder.DropTable(
                name: "EmployeePlans");

            migrationBuilder.DropTable(
                name: "ListDepartamentMetrics");

            migrationBuilder.DropTable(
                name: "ListEmployeesMetrics");

            migrationBuilder.DropTable(
                name: "ProgressEmployees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departaments");
        }
    }
}
