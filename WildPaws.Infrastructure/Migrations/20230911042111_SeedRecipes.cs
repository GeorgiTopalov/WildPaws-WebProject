using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildPaws.Infrastructure.Migrations
{
    public partial class SeedRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Recipes (RecipeName) VALUES ('Beef')");
            migrationBuilder.Sql("INSERT INTO Recipes (RecipeName) VALUES ('Chicken and Dory')");
            migrationBuilder.Sql("INSERT INTO Recipes (RecipeName) VALUES ('Salmon and Tuna')");
            migrationBuilder.Sql("INSERT INTO Recipes (RecipeName) VALUES ('Crocodile Fillet')");
            migrationBuilder.Sql("INSERT INTO Recipes (RecipeName) VALUES ('Chicken Breast')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
