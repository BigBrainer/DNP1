using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyWebAPI.Migrations
{
    public partial class RestoredChildInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildInterest_Interest_InterestId",
                table: "ChildInterest");

            migrationBuilder.DropIndex(
                name: "IX_ChildInterest_ChildId",
                table: "ChildInterest");

            migrationBuilder.AlterColumn<string>(
                name: "InterestId",
                table: "ChildInterest",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildInterest",
                table: "ChildInterest",
                columns: new[] { "ChildId", "InterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChildInterest_Interest_InterestId",
                table: "ChildInterest",
                column: "InterestId",
                principalTable: "Interest",
                principalColumn: "Type",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildInterest_Interest_InterestId",
                table: "ChildInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildInterest",
                table: "ChildInterest");

            migrationBuilder.AlterColumn<string>(
                name: "InterestId",
                table: "ChildInterest",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterest_ChildId",
                table: "ChildInterest",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildInterest_Interest_InterestId",
                table: "ChildInterest",
                column: "InterestId",
                principalTable: "Interest",
                principalColumn: "Type",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
