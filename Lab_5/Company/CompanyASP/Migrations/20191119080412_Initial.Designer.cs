﻿// <auto-generated />
using System;
using Company.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyASP.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20191119080412_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Company.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Profit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Solution")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Company.Models.EmployeeFact", b =>
                {
                    b.Property<int>("EmployeeFactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ProfitQuarter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProfitYear")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quarter")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("EmployeeFactId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeFact");
                });

            modelBuilder.Entity("Company.Models.EmployeePlan", b =>
                {
                    b.Property<int>("EmployeePlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeFactId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ProfitQuarter")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ProfitYear")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quarter")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("EmployeePlanId");

                    b.HasIndex("EmployeeFactId");

                    b.ToTable("EmployeePlans");
                });

            modelBuilder.Entity("Company.Models.ProgressEmployee", b =>
                {
                    b.Property<int>("ProgressEmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Progress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgressEmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProgressEmployees");
                });

            modelBuilder.Entity("Company.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountEmployees")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Company.Models.UnitsValuationFact", b =>
                {
                    b.Property<int>("UnitValuationFactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("UnitValuationFactId");

                    b.HasIndex("UnitId");

                    b.ToTable("UnitsValuationFact");
                });

            modelBuilder.Entity("Company.Models.UnitsValuationPlan", b =>
                {
                    b.Property<int>("UnitValuationPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UnitValuationFactId")
                        .HasColumnType("int");

                    b.HasKey("UnitValuationPlanId");

                    b.HasIndex("UnitValuationFactId");

                    b.ToTable("UnitsValuationPlans");
                });

            modelBuilder.Entity("Company.Models.Employee", b =>
                {
                    b.HasOne("Company.Models.Unit", "Unit")
                        .WithMany("Employees")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("Company.Models.EmployeeFact", b =>
                {
                    b.HasOne("Company.Models.Employee", "Employee")
                        .WithMany("EmployeeFact")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Company.Models.EmployeePlan", b =>
                {
                    b.HasOne("Company.Models.EmployeeFact", "EmployeeFact")
                        .WithMany("EmployeePlans")
                        .HasForeignKey("EmployeeFactId");
                });

            modelBuilder.Entity("Company.Models.ProgressEmployee", b =>
                {
                    b.HasOne("Company.Models.Employee", "Employee")
                        .WithMany("ProgressEmployees")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Company.Models.UnitsValuationFact", b =>
                {
                    b.HasOne("Company.Models.Unit", "Unit")
                        .WithMany("UnitsValuationFact")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("Company.Models.UnitsValuationPlan", b =>
                {
                    b.HasOne("Company.Models.UnitsValuationFact", "UnitValuationFact")
                        .WithMany("UnitsValuationPlans")
                        .HasForeignKey("UnitValuationFactId");
                });
#pragma warning restore 612, 618
        }
    }
}
