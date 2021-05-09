using Microsoft.EntityFrameworkCore.Migrations;

namespace TandNTestMachine.Data.Migrations
{
    public partial class Release_V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationIndex",
                table: "TestProcedureOperation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationIndex",
                table: "TestProcedureOperation");
        }
    }
}
