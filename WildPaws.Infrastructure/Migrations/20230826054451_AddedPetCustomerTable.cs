using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildPaws.Infrastructure.Migrations
{
    public partial class AddedPetCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Customers_CustomerId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<string>(
                name: "ActivityLevel",
                table: "Pets",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BodyStatus",
                table: "Pets",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Pets",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentFoodType",
                table: "Pets",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Pets",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasHealthIssues",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpayed",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TreatsAndScraps",
                table: "Pets",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CustomerPets",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPets", x => new { x.PetId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerPets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPets_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPets_CustomerId",
                table: "CustomerPets",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Customers_CustomerId",
                table: "Pets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Customers_CustomerId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "CustomerPets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BodyStatus",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CurrentFoodType",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "HasHealthIssues",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsSpayed",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "TreatsAndScraps",
                table: "Pets");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Customers_CustomerId",
                table: "Subscriptions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
