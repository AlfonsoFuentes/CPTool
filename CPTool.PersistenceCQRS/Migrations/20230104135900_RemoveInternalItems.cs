using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInternalItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Brands_eBrandId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_EquipmentTypeSubs_eEquipmentTypeSubId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_EquipmentTypes_eEquipmentTypeId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Gaskets_eGasketId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Materials_eInnerMaterialId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Materials_eOuterMaterialId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessFluids_eProcessFluidId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Suppliers_eSupplierId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Brands_iBrandId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_DeviceFunctionModifiers_DeviceFunctionModifierId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_DeviceFunctions_DeviceFunctionId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Gaskets_iGasketId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Materials_iInnerMaterialId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Materials_iOuterMaterialId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_MeasuredVariableModifiers_MeasuredVariableModifierId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_MeasuredVariables_MeasuredVariableId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_ProcessConditions_iProcessConditionId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_ProcessFluids_iProcessFluidId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Readouts_ReadoutId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItems_Suppliers_iSupplierId",
                table: "InstrumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_ContingencyItems_ContingencyItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_EHSItems_EHSItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_ElectricalItems_ElectricalItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_EngineeringCostItems_EngineeringCostItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_EquipmentItems_EquipmentItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_FoundationItems_FoundationItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_InstrumentItems_InstrumentItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_InsulationItems_InsulationItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_PaintingItems_PaintingItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_PipingItems_PipingItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_StructuralItems_StructuralItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_TaxesItems_TaxesItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_TestingItems_TestingItemId",
                table: "MWOItems");

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

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_MWOItems_FinishMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_MWOItems_StartMWOItemId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_Materials_pMaterialId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_Nozzles_NozzleFinishId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_Nozzles_NozzleStartId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_PipeClasss_pPipeClassId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_PipeDiameters_pDiameterId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_ProcessConditions_pProcessConditionId",
                table: "PipingItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_ProcessFluids_pProcessFluidId",
                table: "PipingItems");

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
                name: "PaintingItems");

            migrationBuilder.DropTable(
                name: "StructuralItems");

            migrationBuilder.DropTable(
                name: "TaxesItems");

            migrationBuilder.DropTable(
                name: "TestingItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_ContingencyItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_EHSItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_ElectricalItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_EngineeringCostItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_FoundationItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_InsulationItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_PaintingItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_StructuralItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_TaxesItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_TestingItemId",
                table: "MWOItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PipingItems",
                table: "PipingItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentItems",
                table: "InstrumentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentItems",
                table: "EquipmentItems");

            migrationBuilder.DropColumn(
                name: "ContingencyItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "EHSItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "ElectricalItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "EngineeringCostItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "FoundationItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "InsulationItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "PaintingItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "StructuralItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "TaxesItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "TestingItemId",
                table: "MWOItems");

            migrationBuilder.RenameTable(
                name: "PipingItems",
                newName: "PipingItem");

            migrationBuilder.RenameTable(
                name: "InstrumentItems",
                newName: "InstrumentItem");

            migrationBuilder.RenameTable(
                name: "EquipmentItems",
                newName: "EquipmentItem");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_StartMWOItemId",
                table: "PipingItem",
                newName: "IX_PipingItem_StartMWOItemId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_pProcessFluidId",
                table: "PipingItem",
                newName: "IX_PipingItem_pProcessFluidId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_pProcessConditionId",
                table: "PipingItem",
                newName: "IX_PipingItem_pProcessConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_pPipeClassId",
                table: "PipingItem",
                newName: "IX_PipingItem_pPipeClassId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_pMaterialId",
                table: "PipingItem",
                newName: "IX_PipingItem_pMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_pDiameterId",
                table: "PipingItem",
                newName: "IX_PipingItem_pDiameterId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_NozzleStartId",
                table: "PipingItem",
                newName: "IX_PipingItem_NozzleStartId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_NozzleFinishId",
                table: "PipingItem",
                newName: "IX_PipingItem_NozzleFinishId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItems_FinishMWOItemId",
                table: "PipingItem",
                newName: "IX_PipingItem_FinishMWOItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_ReadoutId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_ReadoutId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_MeasuredVariableModifierId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_MeasuredVariableModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_MeasuredVariableId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_MeasuredVariableId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_iSupplierId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_iSupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_iProcessFluidId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_iProcessFluidId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_iProcessConditionId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_iProcessConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_iOuterMaterialId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_iOuterMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_iInnerMaterialId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_iInnerMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_iGasketId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_iGasketId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_iBrandId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_iBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_DeviceFunctionModifierId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_DeviceFunctionModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItems_DeviceFunctionId",
                table: "InstrumentItem",
                newName: "IX_InstrumentItem_DeviceFunctionId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eSupplierId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eSupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eProcessFluidId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eProcessFluidId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eProcessConditionId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eProcessConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eOuterMaterialId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eOuterMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eInnerMaterialId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eInnerMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eGasketId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eGasketId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eEquipmentTypeSubId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eEquipmentTypeSubId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eEquipmentTypeId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eEquipmentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_eBrandId",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_eBrandId");

            migrationBuilder.AddColumn<string>(
                name: "CostCenter",
                table: "MWOItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PipingItem",
                table: "PipingItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentItem",
                table: "InstrumentItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentItem",
                table: "EquipmentItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_Brands_eBrandId",
                table: "EquipmentItem",
                column: "eBrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_EquipmentTypeSubs_eEquipmentTypeSubId",
                table: "EquipmentItem",
                column: "eEquipmentTypeSubId",
                principalTable: "EquipmentTypeSubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_EquipmentTypes_eEquipmentTypeId",
                table: "EquipmentItem",
                column: "eEquipmentTypeId",
                principalTable: "EquipmentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_Gaskets_eGasketId",
                table: "EquipmentItem",
                column: "eGasketId",
                principalTable: "Gaskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_Materials_eInnerMaterialId",
                table: "EquipmentItem",
                column: "eInnerMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_Materials_eOuterMaterialId",
                table: "EquipmentItem",
                column: "eOuterMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_ProcessConditions_eProcessConditionId",
                table: "EquipmentItem",
                column: "eProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_ProcessFluids_eProcessFluidId",
                table: "EquipmentItem",
                column: "eProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_Suppliers_eSupplierId",
                table: "EquipmentItem",
                column: "eSupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_Brands_iBrandId",
                table: "InstrumentItem",
                column: "iBrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_DeviceFunctionModifiers_DeviceFunctionModifierId",
                table: "InstrumentItem",
                column: "DeviceFunctionModifierId",
                principalTable: "DeviceFunctionModifiers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_DeviceFunctions_DeviceFunctionId",
                table: "InstrumentItem",
                column: "DeviceFunctionId",
                principalTable: "DeviceFunctions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_Gaskets_iGasketId",
                table: "InstrumentItem",
                column: "iGasketId",
                principalTable: "Gaskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_Materials_iInnerMaterialId",
                table: "InstrumentItem",
                column: "iInnerMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_Materials_iOuterMaterialId",
                table: "InstrumentItem",
                column: "iOuterMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_MeasuredVariableModifiers_MeasuredVariableModifierId",
                table: "InstrumentItem",
                column: "MeasuredVariableModifierId",
                principalTable: "MeasuredVariableModifiers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_MeasuredVariables_MeasuredVariableId",
                table: "InstrumentItem",
                column: "MeasuredVariableId",
                principalTable: "MeasuredVariables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_ProcessConditions_iProcessConditionId",
                table: "InstrumentItem",
                column: "iProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_ProcessFluids_iProcessFluidId",
                table: "InstrumentItem",
                column: "iProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_Readouts_ReadoutId",
                table: "InstrumentItem",
                column: "ReadoutId",
                principalTable: "Readouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItem_Suppliers_iSupplierId",
                table: "InstrumentItem",
                column: "iSupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_EquipmentItem_EquipmentItemId",
                table: "MWOItems",
                column: "EquipmentItemId",
                principalTable: "EquipmentItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_InstrumentItem_InstrumentItemId",
                table: "MWOItems",
                column: "InstrumentItemId",
                principalTable: "InstrumentItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_PipingItem_PipingItemId",
                table: "MWOItems",
                column: "PipingItemId",
                principalTable: "PipingItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_EquipmentItem_EquipmentItemId",
                table: "Nozzles",
                column: "EquipmentItemId",
                principalTable: "EquipmentItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_InstrumentItem_InstrumentItemId",
                table: "Nozzles",
                column: "InstrumentItemId",
                principalTable: "InstrumentItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_PipingItem_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId",
                principalTable: "PipingItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PipeAccesorys_PipingItem_pPipingItemId",
                table: "PipeAccesorys",
                column: "pPipingItemId",
                principalTable: "PipingItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_MWOItems_FinishMWOItemId",
                table: "PipingItem",
                column: "FinishMWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_MWOItems_StartMWOItemId",
                table: "PipingItem",
                column: "StartMWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_Materials_pMaterialId",
                table: "PipingItem",
                column: "pMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_Nozzles_NozzleFinishId",
                table: "PipingItem",
                column: "NozzleFinishId",
                principalTable: "Nozzles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_Nozzles_NozzleStartId",
                table: "PipingItem",
                column: "NozzleStartId",
                principalTable: "Nozzles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_PipeClasss_pPipeClassId",
                table: "PipingItem",
                column: "pPipeClassId",
                principalTable: "PipeClasss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_PipeDiameters_pDiameterId",
                table: "PipingItem",
                column: "pDiameterId",
                principalTable: "PipeDiameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_ProcessConditions_pProcessConditionId",
                table: "PipingItem",
                column: "pProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItem_ProcessFluids_pProcessFluidId",
                table: "PipingItem",
                column: "pProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_Brands_eBrandId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_EquipmentTypeSubs_eEquipmentTypeSubId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_EquipmentTypes_eEquipmentTypeId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_Gaskets_eGasketId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_Materials_eInnerMaterialId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_Materials_eOuterMaterialId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_ProcessConditions_eProcessConditionId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_ProcessFluids_eProcessFluidId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_Suppliers_eSupplierId",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_Brands_iBrandId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_DeviceFunctionModifiers_DeviceFunctionModifierId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_DeviceFunctions_DeviceFunctionId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_Gaskets_iGasketId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_Materials_iInnerMaterialId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_Materials_iOuterMaterialId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_MeasuredVariableModifiers_MeasuredVariableModifierId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_MeasuredVariables_MeasuredVariableId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_ProcessConditions_iProcessConditionId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_ProcessFluids_iProcessFluidId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_Readouts_ReadoutId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentItem_Suppliers_iSupplierId",
                table: "InstrumentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_EquipmentItem_EquipmentItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_InstrumentItem_InstrumentItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_PipingItem_PipingItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_EquipmentItem_EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_InstrumentItem_InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_PipingItem_PipingItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_PipeAccesorys_PipingItem_pPipingItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_MWOItems_FinishMWOItemId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_MWOItems_StartMWOItemId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_Materials_pMaterialId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_Nozzles_NozzleFinishId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_Nozzles_NozzleStartId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_PipeClasss_pPipeClassId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_PipeDiameters_pDiameterId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_ProcessConditions_pProcessConditionId",
                table: "PipingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PipingItem_ProcessFluids_pProcessFluidId",
                table: "PipingItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PipingItem",
                table: "PipingItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentItem",
                table: "InstrumentItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentItem",
                table: "EquipmentItem");

            migrationBuilder.DropColumn(
                name: "CostCenter",
                table: "MWOItems");

            migrationBuilder.RenameTable(
                name: "PipingItem",
                newName: "PipingItems");

            migrationBuilder.RenameTable(
                name: "InstrumentItem",
                newName: "InstrumentItems");

            migrationBuilder.RenameTable(
                name: "EquipmentItem",
                newName: "EquipmentItems");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_StartMWOItemId",
                table: "PipingItems",
                newName: "IX_PipingItems_StartMWOItemId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_pProcessFluidId",
                table: "PipingItems",
                newName: "IX_PipingItems_pProcessFluidId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_pProcessConditionId",
                table: "PipingItems",
                newName: "IX_PipingItems_pProcessConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_pPipeClassId",
                table: "PipingItems",
                newName: "IX_PipingItems_pPipeClassId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_pMaterialId",
                table: "PipingItems",
                newName: "IX_PipingItems_pMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_pDiameterId",
                table: "PipingItems",
                newName: "IX_PipingItems_pDiameterId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_NozzleStartId",
                table: "PipingItems",
                newName: "IX_PipingItems_NozzleStartId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_NozzleFinishId",
                table: "PipingItems",
                newName: "IX_PipingItems_NozzleFinishId");

            migrationBuilder.RenameIndex(
                name: "IX_PipingItem_FinishMWOItemId",
                table: "PipingItems",
                newName: "IX_PipingItems_FinishMWOItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_ReadoutId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_ReadoutId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_MeasuredVariableModifierId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_MeasuredVariableModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_MeasuredVariableId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_MeasuredVariableId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_iSupplierId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_iSupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_iProcessFluidId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_iProcessFluidId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_iProcessConditionId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_iProcessConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_iOuterMaterialId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_iOuterMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_iInnerMaterialId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_iInnerMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_iGasketId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_iGasketId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_iBrandId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_iBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_DeviceFunctionModifierId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_DeviceFunctionModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_InstrumentItem_DeviceFunctionId",
                table: "InstrumentItems",
                newName: "IX_InstrumentItems_DeviceFunctionId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eSupplierId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eSupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eProcessFluidId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eProcessFluidId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eProcessConditionId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eProcessConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eOuterMaterialId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eOuterMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eInnerMaterialId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eInnerMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eGasketId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eGasketId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eEquipmentTypeSubId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eEquipmentTypeSubId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eEquipmentTypeId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eEquipmentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_eBrandId",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_eBrandId");

            migrationBuilder.AddColumn<int>(
                name: "ContingencyItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EHSItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElectricalItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EngineeringCostItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoundationItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsulationItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaintingItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StructuralItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxesItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestingItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PipingItems",
                table: "PipingItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentItems",
                table: "InstrumentItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentItems",
                table: "EquipmentItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContingencyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineeringCostItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoundationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsulationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsulationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaintingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StructuralItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructuralItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingItems", x => x.Id);
                });

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
                name: "IX_MWOItems_FoundationItemId",
                table: "MWOItems",
                column: "FoundationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_InsulationItemId",
                table: "MWOItems",
                column: "InsulationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_PaintingItemId",
                table: "MWOItems",
                column: "PaintingItemId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_Brands_eBrandId",
                table: "EquipmentItems",
                column: "eBrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_EquipmentTypeSubs_eEquipmentTypeSubId",
                table: "EquipmentItems",
                column: "eEquipmentTypeSubId",
                principalTable: "EquipmentTypeSubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_EquipmentTypes_eEquipmentTypeId",
                table: "EquipmentItems",
                column: "eEquipmentTypeId",
                principalTable: "EquipmentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_Gaskets_eGasketId",
                table: "EquipmentItems",
                column: "eGasketId",
                principalTable: "Gaskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_Materials_eInnerMaterialId",
                table: "EquipmentItems",
                column: "eInnerMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_Materials_eOuterMaterialId",
                table: "EquipmentItems",
                column: "eOuterMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems",
                column: "eProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessFluids_eProcessFluidId",
                table: "EquipmentItems",
                column: "eProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_Suppliers_eSupplierId",
                table: "EquipmentItems",
                column: "eSupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_Brands_iBrandId",
                table: "InstrumentItems",
                column: "iBrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_DeviceFunctionModifiers_DeviceFunctionModifierId",
                table: "InstrumentItems",
                column: "DeviceFunctionModifierId",
                principalTable: "DeviceFunctionModifiers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_DeviceFunctions_DeviceFunctionId",
                table: "InstrumentItems",
                column: "DeviceFunctionId",
                principalTable: "DeviceFunctions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_Gaskets_iGasketId",
                table: "InstrumentItems",
                column: "iGasketId",
                principalTable: "Gaskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_Materials_iInnerMaterialId",
                table: "InstrumentItems",
                column: "iInnerMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_Materials_iOuterMaterialId",
                table: "InstrumentItems",
                column: "iOuterMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_MeasuredVariableModifiers_MeasuredVariableModifierId",
                table: "InstrumentItems",
                column: "MeasuredVariableModifierId",
                principalTable: "MeasuredVariableModifiers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_MeasuredVariables_MeasuredVariableId",
                table: "InstrumentItems",
                column: "MeasuredVariableId",
                principalTable: "MeasuredVariables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_ProcessConditions_iProcessConditionId",
                table: "InstrumentItems",
                column: "iProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_ProcessFluids_iProcessFluidId",
                table: "InstrumentItems",
                column: "iProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_Readouts_ReadoutId",
                table: "InstrumentItems",
                column: "ReadoutId",
                principalTable: "Readouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentItems_Suppliers_iSupplierId",
                table: "InstrumentItems",
                column: "iSupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_ContingencyItems_ContingencyItemId",
                table: "MWOItems",
                column: "ContingencyItemId",
                principalTable: "ContingencyItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_EHSItems_EHSItemId",
                table: "MWOItems",
                column: "EHSItemId",
                principalTable: "EHSItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_ElectricalItems_ElectricalItemId",
                table: "MWOItems",
                column: "ElectricalItemId",
                principalTable: "ElectricalItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_EngineeringCostItems_EngineeringCostItemId",
                table: "MWOItems",
                column: "EngineeringCostItemId",
                principalTable: "EngineeringCostItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_EquipmentItems_EquipmentItemId",
                table: "MWOItems",
                column: "EquipmentItemId",
                principalTable: "EquipmentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_FoundationItems_FoundationItemId",
                table: "MWOItems",
                column: "FoundationItemId",
                principalTable: "FoundationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_InstrumentItems_InstrumentItemId",
                table: "MWOItems",
                column: "InstrumentItemId",
                principalTable: "InstrumentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_InsulationItems_InsulationItemId",
                table: "MWOItems",
                column: "InsulationItemId",
                principalTable: "InsulationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_PaintingItems_PaintingItemId",
                table: "MWOItems",
                column: "PaintingItemId",
                principalTable: "PaintingItems",
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
                name: "FK_MWOItems_StructuralItems_StructuralItemId",
                table: "MWOItems",
                column: "StructuralItemId",
                principalTable: "StructuralItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_TaxesItems_TaxesItemId",
                table: "MWOItems",
                column: "TaxesItemId",
                principalTable: "TaxesItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_TestingItems_TestingItemId",
                table: "MWOItems",
                column: "TestingItemId",
                principalTable: "TestingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_EquipmentItems_EquipmentItemId",
                table: "Nozzles",
                column: "EquipmentItemId",
                principalTable: "EquipmentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_InstrumentItems_InstrumentItemId",
                table: "Nozzles",
                column: "InstrumentItemId",
                principalTable: "InstrumentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_PipingItems_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId",
                principalTable: "PipingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PipeAccesorys_PipingItems_pPipingItemId",
                table: "PipeAccesorys",
                column: "pPipingItemId",
                principalTable: "PipingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_PipingItems_Materials_pMaterialId",
                table: "PipingItems",
                column: "pMaterialId",
                principalTable: "Materials",
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
                name: "FK_PipingItems_PipeClasss_pPipeClassId",
                table: "PipingItems",
                column: "pPipeClassId",
                principalTable: "PipeClasss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_PipeDiameters_pDiameterId",
                table: "PipingItems",
                column: "pDiameterId",
                principalTable: "PipeDiameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_ProcessConditions_pProcessConditionId",
                table: "PipingItems",
                column: "pProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_ProcessFluids_pProcessFluidId",
                table: "PipingItems",
                column: "pProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");
        }
    }
}
