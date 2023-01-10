using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_MWOItems_ConnectedToId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_ConnectedToId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "ConnectedToId",
                table: "Nozzles");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceFunctionId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceFunctionModifierId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiameterId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinishMWOItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InnerMaterialId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Insulation",
                table: "MWOItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MeasuredVariableId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasuredVariableModifierId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "MWOItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NozzleFinishId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NozzleStartId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OuterMaterialId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PipeClassId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessConditionId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessFluidId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReadoutId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "MWOItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "MWOItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartMWOItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagId",
                table: "MWOItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TagLetter",
                table: "MWOItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagNumber",
                table: "MWOItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_BrandId",
                table: "MWOItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_DeviceFunctionId",
                table: "MWOItems",
                column: "DeviceFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_DeviceFunctionModifierId",
                table: "MWOItems",
                column: "DeviceFunctionModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_DiameterId",
                table: "MWOItems",
                column: "DiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_FinishMWOItemId",
                table: "MWOItems",
                column: "FinishMWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_InnerMaterialId",
                table: "MWOItems",
                column: "InnerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_MeasuredVariableId",
                table: "MWOItems",
                column: "MeasuredVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_MeasuredVariableModifierId",
                table: "MWOItems",
                column: "MeasuredVariableModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_NozzleFinishId",
                table: "MWOItems",
                column: "NozzleFinishId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_NozzleStartId",
                table: "MWOItems",
                column: "NozzleStartId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_OuterMaterialId",
                table: "MWOItems",
                column: "OuterMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_PipeClassId",
                table: "MWOItems",
                column: "PipeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_ProcessConditionId",
                table: "MWOItems",
                column: "ProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_ProcessFluidId",
                table: "MWOItems",
                column: "ProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_ReadoutId",
                table: "MWOItems",
                column: "ReadoutId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_StartMWOItemId",
                table: "MWOItems",
                column: "StartMWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_SupplierId",
                table: "MWOItems",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Brands_BrandId",
                table: "MWOItems",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_DeviceFunctionModifiers_DeviceFunctionModifierId",
                table: "MWOItems",
                column: "DeviceFunctionModifierId",
                principalTable: "DeviceFunctionModifiers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_DeviceFunctions_DeviceFunctionId",
                table: "MWOItems",
                column: "DeviceFunctionId",
                principalTable: "DeviceFunctions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_MWOItems_FinishMWOItemId",
                table: "MWOItems",
                column: "FinishMWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_MWOItems_StartMWOItemId",
                table: "MWOItems",
                column: "StartMWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Materials_InnerMaterialId",
                table: "MWOItems",
                column: "InnerMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Materials_OuterMaterialId",
                table: "MWOItems",
                column: "OuterMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_MeasuredVariableModifiers_MeasuredVariableModifierId",
                table: "MWOItems",
                column: "MeasuredVariableModifierId",
                principalTable: "MeasuredVariableModifiers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_MeasuredVariables_MeasuredVariableId",
                table: "MWOItems",
                column: "MeasuredVariableId",
                principalTable: "MeasuredVariables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Nozzles_NozzleFinishId",
                table: "MWOItems",
                column: "NozzleFinishId",
                principalTable: "Nozzles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Nozzles_NozzleStartId",
                table: "MWOItems",
                column: "NozzleStartId",
                principalTable: "Nozzles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_PipeClasss_PipeClassId",
                table: "MWOItems",
                column: "PipeClassId",
                principalTable: "PipeClasss",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_PipeDiameters_DiameterId",
                table: "MWOItems",
                column: "DiameterId",
                principalTable: "PipeDiameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_ProcessConditions_ProcessConditionId",
                table: "MWOItems",
                column: "ProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_ProcessFluids_ProcessFluidId",
                table: "MWOItems",
                column: "ProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Readouts_ReadoutId",
                table: "MWOItems",
                column: "ReadoutId",
                principalTable: "Readouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Suppliers_SupplierId",
                table: "MWOItems",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Brands_BrandId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_DeviceFunctionModifiers_DeviceFunctionModifierId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_DeviceFunctions_DeviceFunctionId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_MWOItems_FinishMWOItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_MWOItems_StartMWOItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Materials_InnerMaterialId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Materials_OuterMaterialId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_MeasuredVariableModifiers_MeasuredVariableModifierId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_MeasuredVariables_MeasuredVariableId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Nozzles_NozzleFinishId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Nozzles_NozzleStartId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_PipeClasss_PipeClassId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_PipeDiameters_DiameterId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_ProcessConditions_ProcessConditionId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_ProcessFluids_ProcessFluidId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Readouts_ReadoutId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Suppliers_SupplierId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_BrandId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_DeviceFunctionId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_DeviceFunctionModifierId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_DiameterId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_FinishMWOItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_InnerMaterialId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_MeasuredVariableId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_MeasuredVariableModifierId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_NozzleFinishId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_NozzleStartId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_OuterMaterialId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_PipeClassId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_ProcessConditionId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_ProcessFluidId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_ReadoutId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_StartMWOItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_SupplierId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "DeviceFunctionId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "DeviceFunctionModifierId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "DiameterId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "FinishMWOItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "InnerMaterialId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "Insulation",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "MeasuredVariableId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "MeasuredVariableModifierId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "NozzleFinishId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "NozzleStartId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "OuterMaterialId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "PipeClassId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "ProcessConditionId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "ProcessFluidId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "ReadoutId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "StartMWOItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "TagLetter",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "TagNumber",
                table: "MWOItems");

            migrationBuilder.AddColumn<int>(
                name: "ConnectedToId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_ConnectedToId",
                table: "Nozzles",
                column: "ConnectedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_MWOItems_ConnectedToId",
                table: "Nozzles",
                column: "ConnectedToId",
                principalTable: "MWOItems",
                principalColumn: "Id");
        }
    }
}
