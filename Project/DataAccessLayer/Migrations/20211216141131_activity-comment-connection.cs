using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class activitycommentconnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ActivityID",
                table: "Comments",
                column: "ActivityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Activities_ActivityID",
                table: "Comments",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "ActivityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Activities_ActivityID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ActivityID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ActivityID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "Comments");
        }
    }
}
