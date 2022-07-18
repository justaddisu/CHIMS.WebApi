using Microsoft.EntityFrameworkCore.Migrations;

namespace CHIMS.WebApi.Migrations
{
    public partial class addDrugExpensesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrouId",
                table: "DrugExpenses",
                newName: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugExpenses_DrugId",
                table: "DrugExpenses",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugExpenses_PatientId",
                table: "DrugExpenses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugExpenses_Drugs_DrugId",
                table: "DrugExpenses",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrugExpenses_Patients_PatientId",
                table: "DrugExpenses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugExpenses_Drugs_DrugId",
                table: "DrugExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_DrugExpenses_Patients_PatientId",
                table: "DrugExpenses");

            migrationBuilder.DropIndex(
                name: "IX_DrugExpenses_DrugId",
                table: "DrugExpenses");

            migrationBuilder.DropIndex(
                name: "IX_DrugExpenses_PatientId",
                table: "DrugExpenses");

            migrationBuilder.RenameColumn(
                name: "DrugId",
                table: "DrugExpenses",
                newName: "DrouId");
        }
    }
}
