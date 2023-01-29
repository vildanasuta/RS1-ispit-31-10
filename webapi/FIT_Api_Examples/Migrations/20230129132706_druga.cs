using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AkGodines_AkademskaGodina_akademskaGodina_id",
                table: "AkGodines");

            migrationBuilder.DropForeignKey(
                name: "FK_AkGodines_KorisnickiNalog_evidentiraoKorisnikID",
                table: "AkGodines");

            migrationBuilder.DropForeignKey(
                name: "FK_AkGodines_Student_student_id",
                table: "AkGodines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AkGodines",
                table: "AkGodines");

            migrationBuilder.DropColumn(
                name: "datumUpisZimski",
                table: "AkGodines");

            migrationBuilder.RenameTable(
                name: "AkGodines",
                newName: "UpisAkGodine");

            migrationBuilder.RenameColumn(
                name: "evidentiraoKorisnikID",
                table: "UpisAkGodine",
                newName: "evidentiraoKorisnikId");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "UpisAkGodine",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "jelObnova",
                table: "UpisAkGodine",
                newName: "obnovaGodine");

            migrationBuilder.RenameColumn(
                name: "godinastudina",
                table: "UpisAkGodine",
                newName: "godinaStudija");

            migrationBuilder.RenameColumn(
                name: "datumOvjeraZimski",
                table: "UpisAkGodine",
                newName: "datum2_ZimskiOvjera");

            migrationBuilder.RenameColumn(
                name: "akademskaGodina_id",
                table: "UpisAkGodine",
                newName: "akademskaGodinaId");

            migrationBuilder.RenameIndex(
                name: "IX_AkGodines_student_id",
                table: "UpisAkGodine",
                newName: "IX_UpisAkGodine_studentId");

            migrationBuilder.RenameIndex(
                name: "IX_AkGodines_evidentiraoKorisnikID",
                table: "UpisAkGodine",
                newName: "IX_UpisAkGodine_evidentiraoKorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_AkGodines_akademskaGodina_id",
                table: "UpisAkGodine",
                newName: "IX_UpisAkGodine_akademskaGodinaId");

            migrationBuilder.AlterColumn<float>(
                name: "cijenaSkolarine",
                table: "UpisAkGodine",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<DateTime>(
                name: "datum1_ZimskiUpis",
                table: "UpisAkGodine",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpisAkGodine",
                table: "UpisAkGodine",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisAkGodine_AkademskaGodina_akademskaGodinaId",
                table: "UpisAkGodine",
                column: "akademskaGodinaId",
                principalTable: "AkademskaGodina",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpisAkGodine_KorisnickiNalog_evidentiraoKorisnikId",
                table: "UpisAkGodine",
                column: "evidentiraoKorisnikId",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpisAkGodine_Student_studentId",
                table: "UpisAkGodine",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisAkGodine_AkademskaGodina_akademskaGodinaId",
                table: "UpisAkGodine");

            migrationBuilder.DropForeignKey(
                name: "FK_UpisAkGodine_KorisnickiNalog_evidentiraoKorisnikId",
                table: "UpisAkGodine");

            migrationBuilder.DropForeignKey(
                name: "FK_UpisAkGodine_Student_studentId",
                table: "UpisAkGodine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UpisAkGodine",
                table: "UpisAkGodine");

            migrationBuilder.DropColumn(
                name: "datum1_ZimskiUpis",
                table: "UpisAkGodine");

            migrationBuilder.RenameTable(
                name: "UpisAkGodine",
                newName: "AkGodines");

            migrationBuilder.RenameColumn(
                name: "evidentiraoKorisnikId",
                table: "AkGodines",
                newName: "evidentiraoKorisnikID");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "AkGodines",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "obnovaGodine",
                table: "AkGodines",
                newName: "jelObnova");

            migrationBuilder.RenameColumn(
                name: "godinaStudija",
                table: "AkGodines",
                newName: "godinastudina");

            migrationBuilder.RenameColumn(
                name: "datum2_ZimskiOvjera",
                table: "AkGodines",
                newName: "datumOvjeraZimski");

            migrationBuilder.RenameColumn(
                name: "akademskaGodinaId",
                table: "AkGodines",
                newName: "akademskaGodina_id");

            migrationBuilder.RenameIndex(
                name: "IX_UpisAkGodine_studentId",
                table: "AkGodines",
                newName: "IX_AkGodines_student_id");

            migrationBuilder.RenameIndex(
                name: "IX_UpisAkGodine_evidentiraoKorisnikId",
                table: "AkGodines",
                newName: "IX_AkGodines_evidentiraoKorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_UpisAkGodine_akademskaGodinaId",
                table: "AkGodines",
                newName: "IX_AkGodines_akademskaGodina_id");

            migrationBuilder.AlterColumn<float>(
                name: "cijenaSkolarine",
                table: "AkGodines",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "datumUpisZimski",
                table: "AkGodines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AkGodines",
                table: "AkGodines",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AkGodines_AkademskaGodina_akademskaGodina_id",
                table: "AkGodines",
                column: "akademskaGodina_id",
                principalTable: "AkademskaGodina",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AkGodines_KorisnickiNalog_evidentiraoKorisnikID",
                table: "AkGodines",
                column: "evidentiraoKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AkGodines_Student_student_id",
                table: "AkGodines",
                column: "student_id",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
