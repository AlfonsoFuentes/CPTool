using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class instrumentssignal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricalBoxs",
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
                    table.PrimaryKey("PK_ElectricalBoxs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldLocations",
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
                    table.PrimaryKey("PK_FieldLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignalTypes",
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
                    table.PrimaryKey("PK_SignalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wires",
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
                    table.PrimaryKey("PK_Wires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Signals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignalTypeId = table.Column<int>(type: "int", nullable: false),
                    IOType = table.Column<int>(type: "int", nullable: false),
                    WireId = table.Column<int>(type: "int", nullable: true),
                    FieldLocationId = table.Column<int>(type: "int", nullable: false),
                    ElectricalBoxId = table.Column<int>(type: "int", nullable: true),
                    MWOItemId = table.Column<int>(type: "int", nullable: true),
                    MWOId = table.Column<int>(type: "int", nullable: true),
                    Disconect = table.Column<bool>(type: "bit", nullable: false),
                    InstrumentAir = table.Column<bool>(type: "bit", nullable: false),
                    FrequencyInverter = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Signals_ElectricalBoxs_ElectricalBoxId",
                        column: x => x.ElectricalBoxId,
                        principalTable: "ElectricalBoxs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Signals_FieldLocations_FieldLocationId",
                        column: x => x.FieldLocationId,
                        principalTable: "FieldLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Signals_MWOItems_MWOItemId",
                        column: x => x.MWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Signals_MWOs_MWOId",
                        column: x => x.MWOId,
                        principalTable: "MWOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Signals_SignalTypes_SignalTypeId",
                        column: x => x.SignalTypeId,
                        principalTable: "SignalTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Signals_Wires_WireId",
                        column: x => x.WireId,
                        principalTable: "Wires",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Signals_ElectricalBoxId",
                table: "Signals",
                column: "ElectricalBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Signals_FieldLocationId",
                table: "Signals",
                column: "FieldLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Signals_MWOId",
                table: "Signals",
                column: "MWOId");

            migrationBuilder.CreateIndex(
                name: "IX_Signals_MWOItemId",
                table: "Signals",
                column: "MWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Signals_SignalTypeId",
                table: "Signals",
                column: "SignalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Signals_WireId",
                table: "Signals",
                column: "WireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signals");

            migrationBuilder.DropTable(
                name: "ElectricalBoxs");

            migrationBuilder.DropTable(
                name: "FieldLocations");

            migrationBuilder.DropTable(
                name: "SignalTypes");

            migrationBuilder.DropTable(
                name: "Wires");
        }
    }
}
