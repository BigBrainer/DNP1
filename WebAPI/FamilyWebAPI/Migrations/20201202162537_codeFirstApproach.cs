using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyWebAPI.Migrations
{
    public partial class codeFirstApproach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildInterest_Interest_InterestId",
                table: "ChildInterest");

            migrationBuilder.DropTable(
                name: "Person");

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

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Child",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "Child",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Child",
                type: "TEXT",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "Child",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Child",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Child",
                type: "TEXT",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Child",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Child",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Adult",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "Adult",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Adult",
                type: "TEXT",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "Adult",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Adult",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Adult",
                type: "TEXT",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Adult",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Adult",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildInterest_Interest_InterestId",
                table: "ChildInterest");

            migrationBuilder.DropIndex(
                name: "IX_ChildInterest_ChildId",
                table: "ChildInterest");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "HairColor",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "HairColor",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Adult");

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

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    HairColor = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Adult_Id",
                        column: x => x.Id,
                        principalTable: "Adult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Child_Id",
                        column: x => x.Id,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ChildInterest_Interest_InterestId",
                table: "ChildInterest",
                column: "InterestId",
                principalTable: "Interest",
                principalColumn: "Type",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
