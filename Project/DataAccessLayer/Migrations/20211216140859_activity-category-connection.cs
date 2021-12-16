using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class activitycategoryconnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryID",
                table: "Activities",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Categories_CategoryID",
                table: "Activities",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Categories_CategoryID",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CategoryID",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Activities");
        }
    }
}
