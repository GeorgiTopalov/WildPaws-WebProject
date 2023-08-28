using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildPaws.Infrastructure.Migrations
{
    public partial class ExpandedUserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPets_Customers_CustomerId",
                table: "CustomerPets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Customers_CustomerId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPets",
                table: "CustomerPets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPets_CustomerId",
                table: "CustomerPets");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerPets");

            migrationBuilder.AddColumn<string>(
                name: "WildPawsUserId",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WildpawsUserId",
                table: "CustomerPets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPets",
                table: "CustomerPets",
                columns: new[] { "PetId", "WildpawsUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_WildPawsUserId",
                table: "Pets",
                column: "WildPawsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPets_WildpawsUserId",
                table: "CustomerPets",
                column: "WildpawsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Subscriptions_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPets_AspNetUsers_WildpawsUserId",
                table: "CustomerPets",
                column: "WildpawsUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_WildPawsUserId",
                table: "Pets",
                column: "WildPawsUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Subscriptions_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPets_AspNetUsers_WildpawsUserId",
                table: "CustomerPets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_WildPawsUserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_WildPawsUserId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPets",
                table: "CustomerPets");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPets_WildpawsUserId",
                table: "CustomerPets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WildPawsUserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "WildpawsUserId",
                table: "CustomerPets");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomerPets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPets",
                table: "CustomerPets",
                columns: new[] { "PetId", "CustomerId" });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPets_CustomerId",
                table: "CustomerPets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SubscriptionId",
                table: "Customers",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPets_Customers_CustomerId",
                table: "CustomerPets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Customers_CustomerId",
                table: "Pets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
