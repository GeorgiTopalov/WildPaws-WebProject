using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace WildPaws.Infrastructure.Migrations
{
    public partial class AddRecipeIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");


            migrationBuilder.Sql(@"
                CREATE PROCEDURE InsertRecipeIngredients
                AS
                BEGIN
                    DECLARE @Chickenid INT, @BeefId INT, @SalmonId INT, @TunaId INT, @CrocodileId INT, @DoryId INT, @ChickenLiverId INT, @BeefLiverId INT, @CarrotId INT, @BrownRiceId INT, @SweetPotatoId INT, @LentilsId INT, @FishCartilageId INT, @TomatoId INT, @CurcuminId INT, @SesameId INT,@BroccoliId INT, @CabbageId INT, @FislOilId INT, @BeefRecId INT, @ChickenDoryId INT, @SalmonTunaId INT, @CrocodileRecId INT, @ChickenRecId INT

            SELECT @BeefRecId = Id FROM Recipes WHERE RecipeName = 'Beef';
            SELECT @ChickenDoryId = Id FROM Recipes WHERE RecipeName = 'Chicken And Dory';
            SELECT @CrocodileRecId = Id FROM Recipes WHERE RecipeName = 'Crocodile Fillet';
            SELECT @ChickenRecId = Id FROM Recipes WHERE RecipeName = 'Chicken Breast';
            SELECT @SalmonTunaId = Id FROM Recipes WHERE RecipeName = 'Salmon And Tuna';

            SELECT @Chickenid = Id FROM Ingredients WHERE Name = 'Chicken Breast';
            SELECT @BeefId = Id FROM Ingredients WHERE Name = 'Beef';
            SELECT @SalmonId = Id FROM Ingredients WHERE Name = 'Salmon';
            SELECT @TunaId = Id FROM Ingredients WHERE Name = 'Tuna';
            SELECT @CrocodileId = Id FROM Ingredients WHERE Name = 'Crocodile Fillet';
            SELECT @DoryId = Id FROM Ingredients WHERE Name = 'Pangasius Dory';
            SELECT @ChickenLiverId = Id FROM Ingredients WHERE Name = 'Chicken Liver';
            SELECT @BroccoliId = Id FROM Ingredients WHERE Name = 'Broccoli';
            SELECT @BeefLiverId = Id FROM Ingredients WHERE Name = 'Beef Liver';
            SELECT @SesameId = Id FROM Ingredients WHERE Name = 'Sesame Seed';
            SELECT @CarrotId = Id FROM Ingredients WHERE Name = 'Carrot';
            SELECT @BrownRiceId = Id FROM Ingredients WHERE Name = 'Brown Rice';
            SELECT @BeefId = Id FROM Ingredients WHERE Name = 'Beef';
            SELECT @SweetPotatoId = Id FROM Ingredients WHERE Name = 'Sweet Potato';
            SELECT @LentilsId = Id FROM Ingredients WHERE Name = 'Lentils';
            SELECT @FishCartilageId = Id FROM Ingredients WHERE Name = 'Fish Cartilage';
            SELECT @TomatoId = Id FROM Ingredients WHERE Name = 'Tomato';
            SELECT @CurcuminId = Id FROM Ingredients WHERE Name = 'Curcumin';
            SELECT @CabbageId = Id FROM Ingredients WHERE Name = 'Chinese Cabbage';
            SELECT @FislOilId = Id FROM Ingredients WHERE Name = 'Fish Oil';

           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @ChickenId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @DoryId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @BroccoliId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @CabbageId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @FislOilId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @CarrotId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @CurcuminId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @TomatoId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @BrownRiceId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenDoryId, @FishCartilageId);

           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @BeefId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @SweetPotatoId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @CabbageId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @FislOilId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @CarrotId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @BeefLiverId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @BrownRiceId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@BeefRecId, @FishCartilageId);

           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @CrocodileId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @BroccoliId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @CabbageId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @FislOilId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @CarrotId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @LentilsId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @BrownRiceId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@CrocodileRecId, @FishCartilageId);

           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @ChickenId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @BroccoliId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @CabbageId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @FislOilId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @CarrotId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @ChickenLiverId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @TomatoId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @BrownRiceId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@ChickenRecId, @FishCartilageId);

           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @SalmonId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @TunaId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @BroccoliId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @CabbageId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @SesameId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @ChickenLiverId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @CarrotId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES (@SalmonTunaId, @BrownRiceId);
           INSERT INTO RecipeIngredients (RecipeId, IngredientId) VALUES(@SalmonTunaId, @FishCartilageId);

            
            END
            ");

            migrationBuilder.Sql("EXEC InsertRecipeIngredients;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");
        }
    }
}
