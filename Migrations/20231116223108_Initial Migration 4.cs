using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendForNbaProject.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_UserID",
                table: "Team");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Team",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_UserID",
                table: "Team",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_UserID",
                table: "Team");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_UserID",
                table: "Team",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
