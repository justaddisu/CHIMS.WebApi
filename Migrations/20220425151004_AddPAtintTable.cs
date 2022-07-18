using Microsoft.EntityFrameworkCore.Migrations;

namespace CHIMS.WebApi.Migrations
{
    public partial class AddPAtintTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kebele_Weredas_WeredaId",
                table: "Kebele");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Kebele_KebeleId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Weredas_WeredaId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Kebele_KebeleId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Organization_OrganizationId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_ServiceTypes_ServiceTypeId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Weredas_WeredaId",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kebele",
                table: "Kebele");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "Kebele",
                newName: "Kebeles");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_WeredaId",
                table: "Patients",
                newName: "IX_Patients_WeredaId");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_ServiceTypeId",
                table: "Patients",
                newName: "IX_Patients_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_OrganizationId",
                table: "Patients",
                newName: "IX_Patients_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_KebeleId",
                table: "Patients",
                newName: "IX_Patients_KebeleId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_WeredaId",
                table: "Organizations",
                newName: "IX_Organizations_WeredaId");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_KebeleId",
                table: "Organizations",
                newName: "IX_Organizations_KebeleId");

            migrationBuilder.RenameIndex(
                name: "IX_Kebele_WeredaId",
                table: "Kebeles",
                newName: "IX_Kebeles_WeredaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kebeles",
                table: "Kebeles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Kebeles_Weredas_WeredaId",
                table: "Kebeles",
                column: "WeredaId",
                principalTable: "Weredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Kebeles_KebeleId",
                table: "Organizations",
                column: "KebeleId",
                principalTable: "Kebeles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Weredas_WeredaId",
                table: "Organizations",
                column: "WeredaId",
                principalTable: "Weredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Kebeles_KebeleId",
                table: "Patients",
                column: "KebeleId",
                principalTable: "Kebeles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Organizations_OrganizationId",
                table: "Patients",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ServiceTypes_ServiceTypeId",
                table: "Patients",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Weredas_WeredaId",
                table: "Patients",
                column: "WeredaId",
                principalTable: "Weredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kebeles_Weredas_WeredaId",
                table: "Kebeles");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Kebeles_KebeleId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Weredas_WeredaId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Kebeles_KebeleId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Organizations_OrganizationId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ServiceTypes_ServiceTypeId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Weredas_WeredaId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kebeles",
                table: "Kebeles");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "Kebeles",
                newName: "Kebele");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_WeredaId",
                table: "Patient",
                newName: "IX_Patient_WeredaId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_ServiceTypeId",
                table: "Patient",
                newName: "IX_Patient_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_OrganizationId",
                table: "Patient",
                newName: "IX_Patient_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_KebeleId",
                table: "Patient",
                newName: "IX_Patient_KebeleId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_WeredaId",
                table: "Organization",
                newName: "IX_Organization_WeredaId");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_KebeleId",
                table: "Organization",
                newName: "IX_Organization_KebeleId");

            migrationBuilder.RenameIndex(
                name: "IX_Kebeles_WeredaId",
                table: "Kebele",
                newName: "IX_Kebele_WeredaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kebele",
                table: "Kebele",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kebele_Weredas_WeredaId",
                table: "Kebele",
                column: "WeredaId",
                principalTable: "Weredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Kebele_KebeleId",
                table: "Organization",
                column: "KebeleId",
                principalTable: "Kebele",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Weredas_WeredaId",
                table: "Organization",
                column: "WeredaId",
                principalTable: "Weredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Kebele_KebeleId",
                table: "Patient",
                column: "KebeleId",
                principalTable: "Kebele",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Organization_OrganizationId",
                table: "Patient",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_ServiceTypes_ServiceTypeId",
                table: "Patient",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Weredas_WeredaId",
                table: "Patient",
                column: "WeredaId",
                principalTable: "Weredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
