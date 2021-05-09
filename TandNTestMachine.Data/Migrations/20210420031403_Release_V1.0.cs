using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TandNTestMachine.Data.Migrations
{
    public partial class Release_V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataKey = table.Column<string>(type: "TEXT", nullable: false),
                    DataValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OpCodeName = table.Column<string>(type: "TEXT", nullable: true),
                    OpCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Param1 = table.Column<string>(type: "TEXT", nullable: true),
                    Param2 = table.Column<string>(type: "TEXT", nullable: true),
                    Param3 = table.Column<string>(type: "TEXT", nullable: true),
                    Param4 = table.Column<string>(type: "TEXT", nullable: true),
                    Param5 = table.Column<string>(type: "TEXT", nullable: true),
                    Param1Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param2Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param3Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param4Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param5Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data1Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data2Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data3Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data4Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data5Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagType = table.Column<int>(type: "INTEGER", nullable: false),
                    TagName = table.Column<string>(type: "TEXT", nullable: false),
                    PLCAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestProcedure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
                    Humidity = table.Column<double>(type: "REAL", nullable: false),
                    RunToCompletion = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProcedure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationRecipe",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OperationIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Param1 = table.Column<string>(type: "TEXT", nullable: true),
                    Param2 = table.Column<string>(type: "TEXT", nullable: true),
                    Param3 = table.Column<string>(type: "TEXT", nullable: true),
                    Param4 = table.Column<string>(type: "TEXT", nullable: true),
                    Param5 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationRecipe", x => new { x.OperationId, x.RecipeId, x.OperationIndex });
                    table.ForeignKey(
                        name: "FK_OperationRecipe_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestProcedureOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OpCodeName = table.Column<string>(type: "TEXT", nullable: true),
                    OpCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Param1 = table.Column<string>(type: "TEXT", nullable: true),
                    Param2 = table.Column<string>(type: "TEXT", nullable: true),
                    Param3 = table.Column<string>(type: "TEXT", nullable: true),
                    Param4 = table.Column<string>(type: "TEXT", nullable: true),
                    Param5 = table.Column<string>(type: "TEXT", nullable: true),
                    Param1Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param2Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param3Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param4Name = table.Column<string>(type: "TEXT", nullable: true),
                    Param5Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data1 = table.Column<string>(type: "TEXT", nullable: true),
                    Data2 = table.Column<string>(type: "TEXT", nullable: true),
                    Data3 = table.Column<string>(type: "TEXT", nullable: true),
                    Data4 = table.Column<string>(type: "TEXT", nullable: true),
                    Data5 = table.Column<string>(type: "TEXT", nullable: true),
                    Data1Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data2Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data3Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data4Name = table.Column<string>(type: "TEXT", nullable: true),
                    Data5Name = table.Column<string>(type: "TEXT", nullable: true),
                    TestProcedureId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProcedureOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestProcedureOperation_TestProcedure_TestProcedureId",
                        column: x => x.TestProcedureId,
                        principalTable: "TestProcedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestProcedureSensorLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlateForce = table.Column<float>(type: "REAL", nullable: false),
                    PlateHeight = table.Column<float>(type: "REAL", nullable: false),
                    VacuumPressure = table.Column<float>(type: "REAL", nullable: false),
                    VacuumFlow = table.Column<float>(type: "REAL", nullable: false),
                    ElapsedTime = table.Column<int>(type: "INTEGER", nullable: false),
                    TestProcedureId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProcedureSensorLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestProcedureSensorLog_TestProcedure_TestProcedureId",
                        column: x => x.TestProcedureId,
                        principalTable: "TestProcedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecipe_RecipeId",
                table: "OperationRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestProcedureOperation_TestProcedureId",
                table: "TestProcedureOperation",
                column: "TestProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_TestProcedureSensorLog_TestProcedureId",
                table: "TestProcedureSensorLog",
                column: "TestProcedureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppData");

            migrationBuilder.DropTable(
                name: "OperationRecipe");

            migrationBuilder.DropTable(
                name: "TagAddress");

            migrationBuilder.DropTable(
                name: "TestProcedureOperation");

            migrationBuilder.DropTable(
                name: "TestProcedureSensorLog");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "TestProcedure");
        }
    }
}
