using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContingencyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContingencyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EHSItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gaskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsulationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MWOTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StructuralItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitaryBasePrizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    EquipmentTypeId = table.Column<int>(type: "int", nullable: false),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    MWOTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorCodeId = table.Column<int>(type: "int", nullable: true),
                    TaxCodeLDId = table.Column<int>(type: "int", nullable: true),
                    TaxCodeLPId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    GasketId = table.Column<int>(type: "int", nullable: true),
                    InnerMaterialId = table.Column<int>(type: "int", nullable: true),
                    OuterMaterialId = table.Column<int>(type: "int", nullable: true),
                    EquipmentTypeId = table.Column<int>(type: "int", nullable: true),
                    EquipmentTypeSubId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_EquipmentTypeSubs_EquipmentTypeSubId",
                        column: x => x.EquipmentTypeSubId,
                        principalTable: "EquipmentTypeSubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Gaskets_GasketId",
                        column: x => x.GasketId,
                        principalTable: "Gaskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Materials_InnerMaterialId",
                        column: x => x.InnerMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Materials_OuterMaterialId",
                        column: x => x.OuterMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItems_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MWOItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MWOId = table.Column<int>(type: "int", nullable: true),
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
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    UnitaryBasePrizeId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Nomenclatore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetPrize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RealPrize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitaryPrize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWOItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MWOItems_AlterationItems_AlterationItemId",
                        column: x => x.AlterationItemId,
                        principalTable: "AlterationItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MWOItems_ContingencyItems_ContingencyItemId",
                        column: x => x.ContingencyItemId,
                        principalTable: "ContingencyItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_EHSItems_EHSItemId",
                        column: x => x.EHSItemId,
                        principalTable: "EHSItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_ElectricalItems_ElectricalItemId",
                        column: x => x.ElectricalItemId,
                        principalTable: "ElectricalItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_EngineeringCostItems_EngineeringCostItemId",
                        column: x => x.EngineeringCostItemId,
                        principalTable: "EngineeringCostItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_EquipmentItems_EquipmentItemId",
                        column: x => x.EquipmentItemId,
                        principalTable: "EquipmentItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_FoundationItems_FoundationItemId",
                        column: x => x.FoundationItemId,
                        principalTable: "FoundationItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_InstrumentItems_InstrumentItemId",
                        column: x => x.InstrumentItemId,
                        principalTable: "InstrumentItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_InsulationItems_InsulationItemId",
                        column: x => x.InsulationItemId,
                        principalTable: "InsulationItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_MWOs_MWOId",
                        column: x => x.MWOId,
                        principalTable: "MWOs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_PaintingItems_PaintingItemId",
                        column: x => x.PaintingItemId,
                        principalTable: "PaintingItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_PipingItems_PipingItemId",
                        column: x => x.PipingItemId,
                        principalTable: "PipingItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_StructuralItems_StructuralItemId",
                        column: x => x.StructuralItemId,
                        principalTable: "StructuralItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_TaxesItems_TaxesItemId",
                        column: x => x.TaxesItemId,
                        principalTable: "TaxesItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_TestingItems_TestingItemId",
                        column: x => x.TestingItemId,
                        principalTable: "TestingItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MWOItems_UnitaryBasePrizes_UnitaryBasePrizeId",
                        column: x => x.UnitaryBasePrizeId,
                        principalTable: "UnitaryBasePrizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MWOId = table.Column<int>(type: "int", nullable: false),
                    MWOItemId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_MWOItems_MWOItemId",
                        column: x => x.MWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_MWOs_MWOId",
                        column: x => x.MWOId,
                        principalTable: "MWOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandSuppliers_SupplierId",
                table: "BrandSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_BrandId",
                table: "EquipmentItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_EquipmentTypeId",
                table: "EquipmentItems",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_EquipmentTypeSubId",
                table: "EquipmentItems",
                column: "EquipmentTypeSubId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_GasketId",
                table: "EquipmentItems",
                column: "GasketId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_InnerMaterialId",
                table: "EquipmentItems",
                column: "InnerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_OuterMaterialId",
                table: "EquipmentItems",
                column: "OuterMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_SupplierId",
                table: "EquipmentItems",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTypeSubs_EquipmentTypeId",
                table: "EquipmentTypeSubs",
                column: "EquipmentTypeId");

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
                name: "IX_PurchaseOrderItems_PurchaseOrderId",
                table: "PurchaseOrderItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_MWOId",
                table: "PurchaseOrders",
                column: "MWOId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_MWOItemId",
                table: "PurchaseOrders",
                column: "MWOItemId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandSuppliers");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

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
                name: "EquipmentItems");

            migrationBuilder.DropTable(
                name: "FoundationItems");

            migrationBuilder.DropTable(
                name: "InstrumentItems");

            migrationBuilder.DropTable(
                name: "InsulationItems");

            migrationBuilder.DropTable(
                name: "MWOs");

            migrationBuilder.DropTable(
                name: "PaintingItems");

            migrationBuilder.DropTable(
                name: "PipingItems");

            migrationBuilder.DropTable(
                name: "StructuralItems");

            migrationBuilder.DropTable(
                name: "TaxesItems");

            migrationBuilder.DropTable(
                name: "TestingItems");

            migrationBuilder.DropTable(
                name: "UnitaryBasePrizes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "EquipmentTypeSubs");

            migrationBuilder.DropTable(
                name: "Gaskets");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "MWOTypes");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "TaxCodeLDs");

            migrationBuilder.DropTable(
                name: "TaxCodeLPs");

            migrationBuilder.DropTable(
                name: "VendorCodes");
        }
    }
}
