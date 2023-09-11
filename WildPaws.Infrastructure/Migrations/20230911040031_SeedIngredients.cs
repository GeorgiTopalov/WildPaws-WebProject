using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildPaws.Infrastructure.Migrations
{
    public partial class SeedIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Breed",
                table: "Pets",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Chicken Breast')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Beef')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Pangasius Dory')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Crocodile Fillet')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Salmon')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Tuna')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Chicken Liver')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Broccoli')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Chinese Cabbage')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Fish Oil')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Brown Rice')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Carrot')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Tomato')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Fish Cartilage')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Carrot')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Sesame Seed')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Lentils')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Beef Liver')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Sweet Potato')");
            migrationBuilder.Sql("INSERT INTO Ingredients (Name) VALUES ('Curcumin')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Breed",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
