using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TransactionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Transactions",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_UserId",
                table: "TransactionTypes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTypes_Users_UserId",
                table: "TransactionTypes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTypes_Users_UserId",
                table: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_TransactionTypes_UserId",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TransactionTypes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
