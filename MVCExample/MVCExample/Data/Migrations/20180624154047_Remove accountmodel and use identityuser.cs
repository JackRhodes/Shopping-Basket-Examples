using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCExample.Data.Migrations
{
    public partial class Removeaccountmodelanduseidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_AspNetUsers_AccountId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Basket",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_AccountId",
                table: "Basket",
                newName: "IX_Basket_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_AspNetUsers_IdentityUserId",
                table: "Basket",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_AspNetUsers_IdentityUserId",
                table: "Basket");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Basket",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_IdentityUserId",
                table: "Basket",
                newName: "IX_Basket_AccountId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_AspNetUsers_AccountId",
                table: "Basket",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
