using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharge_Users_UserId",
                table: "UserCharge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCharge",
                table: "UserCharge");

            migrationBuilder.RenameTable(
                name: "UserCharge",
                newName: "UserCharges");

            migrationBuilder.RenameIndex(
                name: "IX_UserCharge_UserId",
                table: "UserCharges",
                newName: "IX_UserCharges_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCharges",
                table: "UserCharges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharges_Users_UserId",
                table: "UserCharges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCharges_Users_UserId",
                table: "UserCharges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCharges",
                table: "UserCharges");

            migrationBuilder.RenameTable(
                name: "UserCharges",
                newName: "UserCharge");

            migrationBuilder.RenameIndex(
                name: "IX_UserCharges_UserId",
                table: "UserCharge",
                newName: "IX_UserCharge_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCharge",
                table: "UserCharge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharge_Users_UserId",
                table: "UserCharge",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
