using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorsOffice.Migrations
{
    public partial class Join : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Doctors",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpecialtyPatient",
                columns: table => new
                {
                    SpecialtyPatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyPatient", x => x.SpecialtyPatientId);
                    table.ForeignKey(
                        name: "FK_SpecialtyPatient_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialtyPatient_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyPatient_PatientId",
                table: "SpecialtyPatient",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyPatient_SpecialtyId",
                table: "SpecialtyPatient",
                column: "SpecialtyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialtyPatient");

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Doctors");
        }
    }
}
