using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class General : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlterationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlterationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContingencyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContingencyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFunctionModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFunctionModifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EHSItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EHSItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngineeringCostItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineeringCostItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoundationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gaskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsulationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsulationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuredVariableModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuredVariableModifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuredVariables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuredVariables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MWOTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWOTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaintingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipeClasss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeClasss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StructuralItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructuralItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCodeLDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCodeLDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCodeLPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCodeLPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxesItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitaryBasePrizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitaryBasePrizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypeSubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeId = table.Column<int>(type: "int", nullable: true),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypeSubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentTypeSubs_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MWOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ProjectLeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CEBName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CECName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MWOTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MWOs_MWOTypes_MWOTypeId",
                        column: x => x.MWOTypeId,
                        principalTable: "MWOTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessFluids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyPackageId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessFluids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessFluids_PropertyPackages_PropertyPackageId",
                        column: x => x.PropertyPackageId,
                        principalTable: "PropertyPackages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipeDiameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dPipeClassId = table.Column<int>(type: "int", nullable: true),
                    OuterDiameterId = table.Column<int>(type: "int", nullable: true),
                    InternalDiameterId = table.Column<int>(type: "int", nullable: true),
                    ThicknessId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeDiameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeDiameters_PipeClasss_dPipeClassId",
                        column: x => x.dPipeClassId,
                        principalTable: "PipeClasss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeDiameters_Units_InternalDiameterId",
                        column: x => x.InternalDiameterId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeDiameters_Units_OuterDiameterId",
                        column: x => x.OuterDiameterId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeDiameters_Units_ThicknessId",
                        column: x => x.ThicknessId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcessConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PressureId = table.Column<int>(type: "int", nullable: true),
                    TemperatureId = table.Column<int>(type: "int", nullable: true),
                    MassFlowId = table.Column<int>(type: "int", nullable: true),
                    VolumetricFlowId = table.Column<int>(type: "int", nullable: true),
                    DensityId = table.Column<int>(type: "int", nullable: true),
                    ViscosityId = table.Column<int>(type: "int", nullable: true),
                    EnthalpyFlowId = table.Column<int>(type: "int", nullable: true),
                    SpecificEnthalpyId = table.Column<int>(type: "int", nullable: true),
                    ThermalConductivityId = table.Column<int>(type: "int", nullable: true),
                    SpecificCpId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_DensityId",
                        column: x => x.DensityId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_EnthalpyFlowId",
                        column: x => x.EnthalpyFlowId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_MassFlowId",
                        column: x => x.MassFlowId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_PressureId",
                        column: x => x.PressureId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_SpecificCpId",
                        column: x => x.SpecificCpId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_SpecificEnthalpyId",
                        column: x => x.SpecificEnthalpyId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_ThermalConductivityId",
                        column: x => x.ThermalConductivityId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_ViscosityId",
                        column: x => x.ViscosityId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessConditions_Units_VolumetricFlowId",
                        column: x => x.VolumetricFlowId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxCodeLPId = table.Column<int>(type: "int", nullable: true),
                    VendorCodeId = table.Column<int>(type: "int", nullable: true),
                    TaxCodeLDId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_TaxCodeLDs_TaxCodeLDId",
                        column: x => x.TaxCodeLDId,
                        principalTable: "TaxCodeLDs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_TaxCodeLPs_TaxCodeLPId",
                        column: x => x.TaxCodeLPId,
                        principalTable: "TaxCodeLPs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suppliers_VendorCodes_VendorCodeId",
                        column: x => x.VendorCodeId,
                        principalTable: "VendorCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandSuppliers",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandSuppliers", x => new { x.BrandId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_BrandSuppliers_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    eProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    eGasketId = table.Column<int>(type: "int", nullable: true),
                    eInnerMaterialId = table.Column<int>(type: "int", nullable: true),
                    eOuterMaterialId = table.Column<int>(type: "int", nullable: true),
                    eEquipmentTypeId = table.Column<int>(type: "int", nullable: true),
                    eEquipmentTypeSubId = table.Column<int>(type: "int", nullable: true),
                    eBrandId = table.Column<int>(type: "int", nullable: true),
                    eSupplierId = table.Column<int>(type: "int", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Brands_eBrandId",
                        column: x => x.eBrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_EquipmentTypes_eEquipmentTypeId",
                        column: x => x.eEquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_EquipmentTypeSubs_eEquipmentTypeSubId",
                        column: x => x.eEquipmentTypeSubId,
                        principalTable: "EquipmentTypeSubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Gaskets_eGasketId",
                        column: x => x.eGasketId,
                        principalTable: "Gaskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Materials_eInnerMaterialId",
                        column: x => x.eInnerMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Materials_eOuterMaterialId",
                        column: x => x.eOuterMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                        column: x => x.eProcessConditionId,
                        principalTable: "ProcessConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_ProcessFluids_eProcessFluidId",
                        column: x => x.eProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Suppliers_eSupplierId",
                        column: x => x.eSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstrumentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    iProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    iGasketId = table.Column<int>(type: "int", nullable: true),
                    iInnerMaterialId = table.Column<int>(type: "int", nullable: true),
                    iOuterMaterialId = table.Column<int>(type: "int", nullable: true),
                    MeasuredVariableId = table.Column<int>(type: "int", nullable: true),
                    MeasuredVariableModifierId = table.Column<int>(type: "int", nullable: true),
                    DeviceFunctionId = table.Column<int>(type: "int", nullable: true),
                    DeviceFunctionModifierId = table.Column<int>(type: "int", nullable: true),
                    ReadoutId = table.Column<int>(type: "int", nullable: true),
                    iBrandId = table.Column<int>(type: "int", nullable: true),
                    iSupplierId = table.Column<int>(type: "int", nullable: true),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentItems_Brands_iBrandId",
                        column: x => x.iBrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_DeviceFunctionModifiers_DeviceFunctionModifierId",
                        column: x => x.DeviceFunctionModifierId,
                        principalTable: "DeviceFunctionModifiers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_DeviceFunctions_DeviceFunctionId",
                        column: x => x.DeviceFunctionId,
                        principalTable: "DeviceFunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_Gaskets_iGasketId",
                        column: x => x.iGasketId,
                        principalTable: "Gaskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_Materials_iInnerMaterialId",
                        column: x => x.iInnerMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_Materials_iOuterMaterialId",
                        column: x => x.iOuterMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_MeasuredVariableModifiers_MeasuredVariableModifierId",
                        column: x => x.MeasuredVariableModifierId,
                        principalTable: "MeasuredVariableModifiers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_MeasuredVariables_MeasuredVariableId",
                        column: x => x.MeasuredVariableId,
                        principalTable: "MeasuredVariables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_ProcessConditions_iProcessConditionId",
                        column: x => x.iProcessConditionId,
                        principalTable: "ProcessConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_ProcessFluids_iProcessFluidId",
                        column: x => x.iProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_Readouts_ReadoutId",
                        column: x => x.ReadoutId,
                        principalTable: "Readouts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItems_Suppliers_iSupplierId",
                        column: x => x.iSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MWOId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderStatus = table.Column<int>(type: "int", nullable: false),
                    pBrandId = table.Column<int>(type: "int", nullable: true),
                    pSupplierId = table.Column<int>(type: "int", nullable: true),
                    PurchaseRequisition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    POReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    POInstalledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    POEstimatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    POOrderingdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SPL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Brands_pBrandId",
                        column: x => x.pBrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_MWOs_MWOId",
                        column: x => x.MWOId,
                        principalTable: "MWOs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_pSupplierId",
                        column: x => x.pSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DownPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBSRequesText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBSRequesNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProformaInvoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownpaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Payterms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownPaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RealDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    DownPaymentAmount = table.Column<double>(type: "float", nullable: false),
                    DownpaymentDescrption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Incotherm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DownpaymentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownPayments_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MWOItemCurrencyValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    MWOItemId = table.Column<int>(type: "int", nullable: true),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    PrizeCurrency = table.Column<double>(type: "float", nullable: false),
                    PrizeUSD = table.Column<double>(type: "float", nullable: false),
                    USDCOP = table.Column<double>(type: "float", nullable: false),
                    USDEUR = table.Column<double>(type: "float", nullable: false),
                    CurrencyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    PrizeCurrencyTax = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWOItemCurrencyValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MWOItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterId = table.Column<int>(type: "int", nullable: true),
                    MWOId = table.Column<int>(type: "int", nullable: true),
                    UnitaryBasePrizeId = table.Column<int>(type: "int", nullable: true),
                    AlterationItemId = table.Column<int>(type: "int", nullable: true),
                    FoundationItemId = table.Column<int>(type: "int", nullable: true),
                    StructuralItemId = table.Column<int>(type: "int", nullable: true),
                    EquipmentItemId = table.Column<int>(type: "int", nullable: true),
                    ElectricalItemId = table.Column<int>(type: "int", nullable: true),
                    PipingItemId = table.Column<int>(type: "int", nullable: true),
                    InstrumentItemId = table.Column<int>(type: "int", nullable: true),
                    InsulationItemId = table.Column<int>(type: "int", nullable: true),
                    PaintingItemId = table.Column<int>(type: "int", nullable: true),
                    EHSItemId = table.Column<int>(type: "int", nullable: true),
                    TaxesItemId = table.Column<int>(type: "int", nullable: true),
                    TestingItemId = table.Column<int>(type: "int", nullable: true),
                    EngineeringCostItemId = table.Column<int>(type: "int", nullable: true),
                    ContingencyItemId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Nomenclatore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetPrize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWOItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MWOItems_AlterationItems_AlterationItemId",
                        column: x => x.AlterationItemId,
                        principalTable: "AlterationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_ContingencyItems_ContingencyItemId",
                        column: x => x.ContingencyItemId,
                        principalTable: "ContingencyItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_EHSItems_EHSItemId",
                        column: x => x.EHSItemId,
                        principalTable: "EHSItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_ElectricalItems_ElectricalItemId",
                        column: x => x.ElectricalItemId,
                        principalTable: "ElectricalItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_EngineeringCostItems_EngineeringCostItemId",
                        column: x => x.EngineeringCostItemId,
                        principalTable: "EngineeringCostItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_EquipmentItems_EquipmentItemId",
                        column: x => x.EquipmentItemId,
                        principalTable: "EquipmentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_FoundationItems_FoundationItemId",
                        column: x => x.FoundationItemId,
                        principalTable: "FoundationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_InstrumentItems_InstrumentItemId",
                        column: x => x.InstrumentItemId,
                        principalTable: "InstrumentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_InsulationItems_InsulationItemId",
                        column: x => x.InsulationItemId,
                        principalTable: "InsulationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_MWOs_MWOId",
                        column: x => x.MWOId,
                        principalTable: "MWOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_PaintingItems_PaintingItemId",
                        column: x => x.PaintingItemId,
                        principalTable: "PaintingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_StructuralItems_StructuralItemId",
                        column: x => x.StructuralItemId,
                        principalTable: "StructuralItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_TaxesItems_TaxesItemId",
                        column: x => x.TaxesItemId,
                        principalTable: "TaxesItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_TestingItems_TestingItemId",
                        column: x => x.TestingItemId,
                        principalTable: "TestingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_UnitaryBasePrizes_UnitaryBasePrizeId",
                        column: x => x.UnitaryBasePrizeId,
                        principalTable: "UnitaryBasePrizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderMWOItems",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    MWOItemId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderMWOItems", x => new { x.PurchaseOrderId, x.MWOItemId });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMWOItems_MWOItems_MWOItemId",
                        column: x => x.MWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nozzles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectedToId = table.Column<int>(type: "int", nullable: true),
                    nPipeClassId = table.Column<int>(type: "int", nullable: true),
                    PipeDiameterId = table.Column<int>(type: "int", nullable: true),
                    ConnectionTypeId = table.Column<int>(type: "int", nullable: true),
                    nGasketId = table.Column<int>(type: "int", nullable: true),
                    nMaterialId = table.Column<int>(type: "int", nullable: true),
                    StreamType = table.Column<int>(type: "int", nullable: false),
                    PipeAccesoryId = table.Column<int>(type: "int", nullable: true),
                    EquipmentItemId = table.Column<int>(type: "int", nullable: true),
                    InstrumentItemId = table.Column<int>(type: "int", nullable: true),
                    PipingItemId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nozzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nozzles_ConnectionTypes_ConnectionTypeId",
                        column: x => x.ConnectionTypeId,
                        principalTable: "ConnectionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_EquipmentItems_EquipmentItemId",
                        column: x => x.EquipmentItemId,
                        principalTable: "EquipmentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nozzles_Gaskets_nGasketId",
                        column: x => x.nGasketId,
                        principalTable: "Gaskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_InstrumentItems_InstrumentItemId",
                        column: x => x.InstrumentItemId,
                        principalTable: "InstrumentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nozzles_Materials_nMaterialId",
                        column: x => x.nMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_MWOItems_ConnectedToId",
                        column: x => x.ConnectedToId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_PipeClasss_nPipeClassId",
                        column: x => x.nPipeClassId,
                        principalTable: "PipeClasss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_PipeDiameters_PipeDiameterId",
                        column: x => x.PipeDiameterId,
                        principalTable: "PipeDiameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    pMaterialId = table.Column<int>(type: "int", nullable: true),
                    pProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    pDiameterId = table.Column<int>(type: "int", nullable: true),
                    NozzleStartId = table.Column<int>(type: "int", nullable: true),
                    NozzleFinishId = table.Column<int>(type: "int", nullable: true),
                    StartMWOItemId = table.Column<int>(type: "int", nullable: true),
                    FinishMWOItemId = table.Column<int>(type: "int", nullable: true),
                    pPipeClassId = table.Column<int>(type: "int", nullable: true),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insulation = table.Column<bool>(type: "bit", nullable: false),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipingItems_Materials_pMaterialId",
                        column: x => x.pMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_MWOItems_FinishMWOItemId",
                        column: x => x.FinishMWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_MWOItems_StartMWOItemId",
                        column: x => x.StartMWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_Nozzles_NozzleFinishId",
                        column: x => x.NozzleFinishId,
                        principalTable: "Nozzles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_Nozzles_NozzleStartId",
                        column: x => x.NozzleStartId,
                        principalTable: "Nozzles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_PipeClasss_pPipeClassId",
                        column: x => x.pPipeClassId,
                        principalTable: "PipeClasss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_PipeDiameters_pDiameterId",
                        column: x => x.pDiameterId,
                        principalTable: "PipeDiameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_ProcessConditions_pProcessConditionId",
                        column: x => x.pProcessConditionId,
                        principalTable: "ProcessConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItems_ProcessFluids_pProcessFluidId",
                        column: x => x.pProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipeAccesorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pPipingItemId = table.Column<int>(type: "int", nullable: true),
                    pProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    paProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    FrictionId = table.Column<int>(type: "int", nullable: true),
                    ReynoldId = table.Column<int>(type: "int", nullable: true),
                    LevelInletId = table.Column<int>(type: "int", nullable: true),
                    LevelOutletId = table.Column<int>(type: "int", nullable: true),
                    FrictionDropPressureId = table.Column<int>(type: "int", nullable: true),
                    OverallDropPressureId = table.Column<int>(type: "int", nullable: true),
                    ElevationChangeId = table.Column<int>(type: "int", nullable: true),
                    FlowDirection = table.Column<int>(type: "int", nullable: false),
                    SectionType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeAccesorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_PipingItems_pPipingItemId",
                        column: x => x.pPipingItemId,
                        principalTable: "PipingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_ProcessConditions_pProcessConditionId",
                        column: x => x.pProcessConditionId,
                        principalTable: "ProcessConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_ProcessFluids_paProcessFluidId",
                        column: x => x.paProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_Units_ElevationChangeId",
                        column: x => x.ElevationChangeId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_Units_FrictionDropPressureId",
                        column: x => x.FrictionDropPressureId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_Units_FrictionId",
                        column: x => x.FrictionId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_Units_LevelInletId",
                        column: x => x.LevelInletId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_Units_LevelOutletId",
                        column: x => x.LevelOutletId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_Units_OverallDropPressureId",
                        column: x => x.OverallDropPressureId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_Units_ReynoldId",
                        column: x => x.ReynoldId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandSuppliers_SupplierId",
                table: "BrandSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DownPayments_PurchaseOrderId",
                table: "DownPayments",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eBrandId",
                table: "EquipmentItems",
                column: "eBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eEquipmentTypeId",
                table: "EquipmentItems",
                column: "eEquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eEquipmentTypeSubId",
                table: "EquipmentItems",
                column: "eEquipmentTypeSubId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eGasketId",
                table: "EquipmentItems",
                column: "eGasketId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eInnerMaterialId",
                table: "EquipmentItems",
                column: "eInnerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eOuterMaterialId",
                table: "EquipmentItems",
                column: "eOuterMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eProcessConditionId",
                table: "EquipmentItems",
                column: "eProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eProcessFluidId",
                table: "EquipmentItems",
                column: "eProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_eSupplierId",
                table: "EquipmentItems",
                column: "eSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypeSubs_EquipmentTypeId",
                table: "EquipmentTypeSubs",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_DeviceFunctionId",
                table: "InstrumentItems",
                column: "DeviceFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_DeviceFunctionModifierId",
                table: "InstrumentItems",
                column: "DeviceFunctionModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_iBrandId",
                table: "InstrumentItems",
                column: "iBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_iGasketId",
                table: "InstrumentItems",
                column: "iGasketId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_iInnerMaterialId",
                table: "InstrumentItems",
                column: "iInnerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_iOuterMaterialId",
                table: "InstrumentItems",
                column: "iOuterMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_iProcessConditionId",
                table: "InstrumentItems",
                column: "iProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_iProcessFluidId",
                table: "InstrumentItems",
                column: "iProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_iSupplierId",
                table: "InstrumentItems",
                column: "iSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_MeasuredVariableId",
                table: "InstrumentItems",
                column: "MeasuredVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_MeasuredVariableModifierId",
                table: "InstrumentItems",
                column: "MeasuredVariableModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_ReadoutId",
                table: "InstrumentItems",
                column: "ReadoutId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItemCurrencyValues_MWOItemId",
                table: "MWOItemCurrencyValues",
                column: "MWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_AlterationItemId",
                table: "MWOItems",
                column: "AlterationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_ChapterId",
                table: "MWOItems",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_ContingencyItemId",
                table: "MWOItems",
                column: "ContingencyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_EHSItemId",
                table: "MWOItems",
                column: "EHSItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_ElectricalItemId",
                table: "MWOItems",
                column: "ElectricalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_EngineeringCostItemId",
                table: "MWOItems",
                column: "EngineeringCostItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_EquipmentItemId",
                table: "MWOItems",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_FoundationItemId",
                table: "MWOItems",
                column: "FoundationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_InstrumentItemId",
                table: "MWOItems",
                column: "InstrumentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_InsulationItemId",
                table: "MWOItems",
                column: "InsulationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_MWOId",
                table: "MWOItems",
                column: "MWOId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_PaintingItemId",
                table: "MWOItems",
                column: "PaintingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_PipingItemId",
                table: "MWOItems",
                column: "PipingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_StructuralItemId",
                table: "MWOItems",
                column: "StructuralItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_TaxesItemId",
                table: "MWOItems",
                column: "TaxesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_TestingItemId",
                table: "MWOItems",
                column: "TestingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_UnitaryBasePrizeId",
                table: "MWOItems",
                column: "UnitaryBasePrizeId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOs_MWOTypeId",
                table: "MWOs",
                column: "MWOTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_ConnectedToId",
                table: "Nozzles",
                column: "ConnectedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_ConnectionTypeId",
                table: "Nozzles",
                column: "ConnectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_EquipmentItemId",
                table: "Nozzles",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_InstrumentItemId",
                table: "Nozzles",
                column: "InstrumentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_nGasketId",
                table: "Nozzles",
                column: "nGasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_nMaterialId",
                table: "Nozzles",
                column: "nMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_nPipeClassId",
                table: "Nozzles",
                column: "nPipeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipeAccesoryId",
                table: "Nozzles",
                column: "PipeAccesoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipeDiameterId",
                table: "Nozzles",
                column: "PipeDiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_ElevationChangeId",
                table: "PipeAccesorys",
                column: "ElevationChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_FrictionDropPressureId",
                table: "PipeAccesorys",
                column: "FrictionDropPressureId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_FrictionId",
                table: "PipeAccesorys",
                column: "FrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_LevelInletId",
                table: "PipeAccesorys",
                column: "LevelInletId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_LevelOutletId",
                table: "PipeAccesorys",
                column: "LevelOutletId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_OverallDropPressureId",
                table: "PipeAccesorys",
                column: "OverallDropPressureId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_paProcessFluidId",
                table: "PipeAccesorys",
                column: "paProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_pPipingItemId",
                table: "PipeAccesorys",
                column: "pPipingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_pProcessConditionId",
                table: "PipeAccesorys",
                column: "pProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_ReynoldId",
                table: "PipeAccesorys",
                column: "ReynoldId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeDiameters_dPipeClassId",
                table: "PipeDiameters",
                column: "dPipeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeDiameters_InternalDiameterId",
                table: "PipeDiameters",
                column: "InternalDiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeDiameters_OuterDiameterId",
                table: "PipeDiameters",
                column: "OuterDiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeDiameters_ThicknessId",
                table: "PipeDiameters",
                column: "ThicknessId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_FinishMWOItemId",
                table: "PipingItems",
                column: "FinishMWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_NozzleFinishId",
                table: "PipingItems",
                column: "NozzleFinishId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_NozzleStartId",
                table: "PipingItems",
                column: "NozzleStartId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_pDiameterId",
                table: "PipingItems",
                column: "pDiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_pMaterialId",
                table: "PipingItems",
                column: "pMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_pPipeClassId",
                table: "PipingItems",
                column: "pPipeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_pProcessConditionId",
                table: "PipingItems",
                column: "pProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_pProcessFluidId",
                table: "PipingItems",
                column: "pProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_StartMWOItemId",
                table: "PipingItems",
                column: "StartMWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_DensityId",
                table: "ProcessConditions",
                column: "DensityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_EnthalpyFlowId",
                table: "ProcessConditions",
                column: "EnthalpyFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_MassFlowId",
                table: "ProcessConditions",
                column: "MassFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_PressureId",
                table: "ProcessConditions",
                column: "PressureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_SpecificCpId",
                table: "ProcessConditions",
                column: "SpecificCpId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_SpecificEnthalpyId",
                table: "ProcessConditions",
                column: "SpecificEnthalpyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_TemperatureId",
                table: "ProcessConditions",
                column: "TemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_ThermalConductivityId",
                table: "ProcessConditions",
                column: "ThermalConductivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_ViscosityId",
                table: "ProcessConditions",
                column: "ViscosityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_VolumetricFlowId",
                table: "ProcessConditions",
                column: "VolumetricFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessFluids_PropertyPackageId",
                table: "ProcessFluids",
                column: "PropertyPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMWOItems_MWOItemId",
                table: "PurchaseOrderMWOItems",
                column: "MWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_MWOId",
                table: "PurchaseOrders",
                column: "MWOId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_pBrandId",
                table: "PurchaseOrders",
                column: "pBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_pSupplierId",
                table: "PurchaseOrders",
                column: "pSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TaxCodeLDId",
                table: "Suppliers",
                column: "TaxCodeLDId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TaxCodeLPId",
                table: "Suppliers",
                column: "TaxCodeLPId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_VendorCodeId",
                table: "Suppliers",
                column: "VendorCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItemCurrencyValues_MWOItems_MWOItemId",
                table: "MWOItemCurrencyValues",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_PipingItems_PipingItemId",
                table: "MWOItems",
                column: "PipingItemId",
                principalTable: "PipingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_PipeAccesorys_PipeAccesoryId",
                table: "Nozzles",
                column: "PipeAccesoryId",
                principalTable: "PipeAccesorys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_PipingItems_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId",
                principalTable: "PipingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Brands_eBrandId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Brands_iBrandId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Suppliers_eSupplierId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Suppliers_iSupplierId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_EquipmentTypes_eEquipmentTypeId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentTypeSubs_EquipmentTypes_EquipmentTypeId",
                table: "EquipmentTypeSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_EquipmentTypeSubs_eEquipmentTypeSubId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Gaskets_eGasketId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Gaskets_iGasketId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_Gaskets_nGasketId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Materials_eInnerMaterialId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Materials_eOuterMaterialId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Materials_iInnerMaterialId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Materials_iOuterMaterialId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_Materials_nMaterialId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_Materials_pMaterialId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_ProcessConditions_iProcessConditionId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipeAccesorys_ProcessConditions_pProcessConditionId",
                table: "PipeAccesorys");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_ProcessConditions_pProcessConditionId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessFluids_eProcessFluidId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_ProcessFluids_iProcessFluidId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipeAccesorys_ProcessFluids_paProcessFluidId",
                table: "PipeAccesorys");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_ProcessFluids_pProcessFluidId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_DeviceFunctionModifiers_DeviceFunctionModifierId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_DeviceFunctions_DeviceFunctionId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_MeasuredVariableModifiers_MeasuredVariableModifierId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_MeasuredVariables_MeasuredVariableId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Readouts_ReadoutId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_MWOItems_ConnectedToId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_MWOItems_FinishMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_MWOItems_StartMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_EquipmentItems_EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_InstrumentItems_InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_PipingItems_PipingItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_PipeAccesorys_PipingItems_pPipingItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropTable(
                name: "BrandSuppliers");

            migrationBuilder.DropTable(
                name: "DownPayments");

            migrationBuilder.DropTable(
                name: "MWOItemCurrencyValues");

            migrationBuilder.DropTable(
                name: "PurchaseOrderMWOItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TaxCodeLDs");

            migrationBuilder.DropTable(
                name: "TaxCodeLPs");

            migrationBuilder.DropTable(
                name: "VendorCodes");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "EquipmentTypeSubs");

            migrationBuilder.DropTable(
                name: "Gaskets");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ProcessConditions");

            migrationBuilder.DropTable(
                name: "ProcessFluids");

            migrationBuilder.DropTable(
                name: "PropertyPackages");

            migrationBuilder.DropTable(
                name: "DeviceFunctionModifiers");

            migrationBuilder.DropTable(
                name: "DeviceFunctions");

            migrationBuilder.DropTable(
                name: "MeasuredVariableModifiers");

            migrationBuilder.DropTable(
                name: "MeasuredVariables");

            migrationBuilder.DropTable(
                name: "Readouts");

            migrationBuilder.DropTable(
                name: "MWOItems");

            migrationBuilder.DropTable(
                name: "AlterationItems");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "ContingencyItems");

            migrationBuilder.DropTable(
                name: "EHSItems");

            migrationBuilder.DropTable(
                name: "ElectricalItems");

            migrationBuilder.DropTable(
                name: "EngineeringCostItems");

            migrationBuilder.DropTable(
                name: "FoundationItems");

            migrationBuilder.DropTable(
                name: "InsulationItems");

            migrationBuilder.DropTable(
                name: "MWOs");

            migrationBuilder.DropTable(
                name: "PaintingItems");

            migrationBuilder.DropTable(
                name: "StructuralItems");

            migrationBuilder.DropTable(
                name: "TaxesItems");

            migrationBuilder.DropTable(
                name: "TestingItems");

            migrationBuilder.DropTable(
                name: "UnitaryBasePrizes");

            migrationBuilder.DropTable(
                name: "MWOTypes");

            migrationBuilder.DropTable(
                name: "EquipmentItems");

            migrationBuilder.DropTable(
                name: "InstrumentItems");

            migrationBuilder.DropTable(
                name: "PipingItems");

            migrationBuilder.DropTable(
                name: "Nozzles");

            migrationBuilder.DropTable(
                name: "ConnectionTypes");

            migrationBuilder.DropTable(
                name: "PipeAccesorys");

            migrationBuilder.DropTable(
                name: "PipeDiameters");

            migrationBuilder.DropTable(
                name: "PipeClasss");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
