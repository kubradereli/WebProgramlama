using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class commentduzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Activities_ActivityID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Activities_ActivityID",
                table: "Comments",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Activities_ActivityID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityID",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Activities_ActivityID",
                table: "Comments",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
