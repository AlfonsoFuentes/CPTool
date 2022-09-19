using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class PipingItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiameterId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinishMWOItemId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Insulation",
                table: "PipingItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NozzleFinishId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NozzleStartId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PipeClassId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessFluidId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartMWOItemId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessConditionId",
                table: "InstrumentItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessFluidId",
                table: "InstrumentItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessConditionId",
                table: "EquipmentItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessFluidId",
                table: "EquipmentItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConnectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipeClasss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeClasss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessFluids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessFluids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipeDiameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ODId = table.Column<int>(type: "int", nullable: true),
                    IDId = table.Column<int>(type: "int", nullable: true),
                    ThicknessId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeDiameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeDiameters_Units_IDId",
                        column: x => x.IDId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeDiameters_Units_ODId",
                        column: x => x.ODId,
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
                    ProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessConditions_ProcessFluids_ProcessFluidId",
                        column: x => x.ProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
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
                name: "PipeAccesorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PipingItemId = table.Column<int>(type: "int", nullable: true),
                    ProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    FrictionId = table.Column<int>(type: "int", nullable: true),
                    ReynoldId = table.Column<int>(type: "int", nullable: true),
                    LevelInletId = table.Column<int>(type: "int", nullable: true),
                    LevelOutletId = table.Column<int>(type: "int", nullable: true),
                    FrictionDropPressureId = table.Column<int>(type: "int", nullable: true),
                    OverallDropPressureId = table.Column<int>(type: "int", nullable: true),
                    ElevationChangeId = table.Column<int>(type: "int", nullable: true),
                    FlowDirection = table.Column<int>(type: "int", nullable: false),
                    SectionType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeAccesorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_PipingItems_PipingItemId",
                        column: x => x.PipingItemId,
                        principalTable: "PipingItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipeAccesorys_ProcessConditions_ProcessConditionId",
                        column: x => x.ProcessConditionId,
                        principalTable: "ProcessConditions",
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

            migrationBuilder.CreateTable(
                name: "Nozzles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PipeClassId = table.Column<int>(type: "int", nullable: true),
                    PipeDiameterId = table.Column<int>(type: "int", nullable: true),
                    ConnectionTypeId = table.Column<int>(type: "int", nullable: true),
                    GasketId = table.Column<int>(type: "int", nullable: true),
                    MaterialID = table.Column<int>(type: "int", nullable: true),
                    StreamType = table.Column<int>(type: "int", nullable: false),
                    PipeAccesoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        name: "FK_Nozzles_Gaskets_GasketId",
                        column: x => x.GasketId,
                        principalTable: "Gaskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_Materials_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_PipeAccesorys_PipeAccesoryId",
                        column: x => x.PipeAccesoryId,
                        principalTable: "PipeAccesorys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_PipeClasss_PipeClassId",
                        column: x => x.PipeClassId,
                        principalTable: "PipeClasss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nozzles_PipeDiameters_PipeDiameterId",
                        column: x => x.PipeDiameterId,
                        principalTable: "PipeDiameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_DiameterId",
                table: "PipingItems",
                column: "DiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_FinishMWOItemId",
                table: "PipingItems",
                column: "FinishMWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_MaterialId",
                table: "PipingItems",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_NozzleFinishId",
                table: "PipingItems",
                column: "NozzleFinishId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_NozzleStartId",
                table: "PipingItems",
                column: "NozzleStartId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_PipeClassId",
                table: "PipingItems",
                column: "PipeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_ProcessFluidId",
                table: "PipingItems",
                column: "ProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_StartMWOItemId",
                table: "PipingItems",
                column: "StartMWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_ProcessConditionId",
                table: "InstrumentItems",
                column: "ProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItems_ProcessFluidId",
                table: "InstrumentItems",
                column: "ProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_ProcessConditionId",
                table: "EquipmentItems",
                column: "ProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_ProcessFluidId",
                table: "EquipmentItems",
                column: "ProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_ConnectionTypeId",
                table: "Nozzles",
                column: "ConnectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_GasketId",
                table: "Nozzles",
                column: "GasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_MaterialID",
                table: "Nozzles",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipeAccesoryId",
                table: "Nozzles",
                column: "PipeAccesoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipeClassId",
                table: "Nozzles",
                column: "PipeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipeDiameterId",
                table: "Nozzles",
                column: "PipeDiameterId");

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
                name: "IX_PipeAccesorys_PipingItemId",
                table: "PipeAccesorys",
                column: "PipingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_ProcessConditionId",
                table: "PipeAccesorys",
                column: "ProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_ReynoldId",
                table: "PipeAccesorys",
                column: "ReynoldId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeDiameters_IDId",
                table: "PipeDiameters",
                column: "IDId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeDiameters_ODId",
                table: "PipeDiameters",
                column: "ODId");

            migrationBuilder.CreateIndex(
                name: "IX_PipeDiameters_ThicknessId",
                table: "PipeDiameters",
                column: "ThicknessId");

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
                name: "IX_ProcessConditions_ProcessFluidId",
                table: "ProcessConditions",
                column: "ProcessFluidId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_ProcessConditionId",
                table: "EquipmentItems",
                column: "ProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessFluids_ProcessFluidId",
                table: "EquipmentItems",
                column: "ProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_ProcessConditions_ProcessConditionId",
                table: "InstrumentItems",
                column: "ProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_ProcessFluids_ProcessFluidId",
                table: "InstrumentItems",
                column: "ProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_Materials_MaterialId",
                table: "PipingItems",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_MWOItems_FinishMWOItemId",
                table: "PipingItems",
                column: "FinishMWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_MWOItems_StartMWOItemId",
                table: "PipingItems",
                column: "StartMWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_Nozzles_NozzleFinishId",
                table: "PipingItems",
                column: "NozzleFinishId",
                principalTable: "Nozzles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_Nozzles_NozzleStartId",
                table: "PipingItems",
                column: "NozzleStartId",
                principalTable: "Nozzles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_PipeClasss_PipeClassId",
                table: "PipingItems",
                column: "PipeClassId",
                principalTable: "PipeClasss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_PipeDiameters_DiameterId",
                table: "PipingItems",
                column: "DiameterId",
                principalTable: "PipeDiameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_ProcessFluids_ProcessFluidId",
                table: "PipingItems",
                column: "ProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_ProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessFluids_ProcessFluidId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_ProcessConditions_ProcessConditionId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_ProcessFluids_ProcessFluidId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_Materials_MaterialId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_MWOItems_FinishMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_MWOItems_StartMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_Nozzles_NozzleFinishId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_Nozzles_NozzleStartId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_PipeClasss_PipeClassId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_PipeDiameters_DiameterId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_ProcessFluids_ProcessFluidId",
                table: "PipingItems");

            migrationBuilder.DropTable(
                name: "Nozzles");

            migrationBuilder.DropTable(
                name: "ConnectionTypes");

            migrationBuilder.DropTable(
                name: "PipeAccesorys");

            migrationBuilder.DropTable(
                name: "PipeClasss");

            migrationBuilder.DropTable(
                name: "PipeDiameters");

            migrationBuilder.DropTable(
                name: "ProcessConditions");

            migrationBuilder.DropTable(
                name: "ProcessFluids");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_DiameterId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_FinishMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_MaterialId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_NozzleFinishId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_NozzleStartId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_PipeClassId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_ProcessFluidId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_StartMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentItems_ProcessConditionId",
                table: "InstrumentItems");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentItems_ProcessFluidId",
                table: "InstrumentItems");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentItems_ProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentItems_ProcessFluidId",
                table: "EquipmentItems");

            migrationBuilder.DropColumn(
                name: "DiameterId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "FinishMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "Insulation",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "NozzleFinishId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "NozzleStartId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "PipeClassId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "ProcessFluidId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "StartMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "ProcessConditionId",
                table: "InstrumentItems");

            migrationBuilder.DropColumn(
                name: "ProcessFluidId",
                table: "InstrumentItems");

            migrationBuilder.DropColumn(
                name: "ProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.DropColumn(
                name: "ProcessFluidId",
                table: "EquipmentItems");
        }
    }
}
