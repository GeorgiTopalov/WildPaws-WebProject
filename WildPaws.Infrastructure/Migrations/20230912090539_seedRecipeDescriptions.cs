using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildPaws.Infrastructure.Migrations
{
    public partial class seedRecipeDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
    name: "Description",
    table: "Recipes",
    maxLength: 400, // Adjust the length as needed
    nullable: true,
    oldMaxLength: 250);

            migrationBuilder.Sql("BEGIN TRANSACTION;");
            migrationBuilder.Sql("UPDATE Recipes SET Description = 'Our Beef recipe uses high-quality low-fat meat from the Rump or the Chunk of the cow. The recipe itself is quite low in fat and very high in protein. It is great for older dogs that don''''t have issues with digesting red meat.' WHERE RecipeName = 'Beef'");
            migrationBuilder.Sql("UPDATE Recipes SET Description = 'Chicken and Pangasius make for a great protein, and your pup will love this tasty recipe. It has the perfect amount of fatty acids, proteins, and vitamins to satisfy your dog''''s needs.' WHERE RecipeName = 'Chicken and Dory'");
            migrationBuilder.Sql("UPDATE Recipes SET Description = 'The Salmon and Tuna recipe is high in fatty acids, which are good for the dog''''s skin as well as their general well-being. We use local fish bought straight from the fisherman. It''''s a great fresh mix that is easy to digest.' WHERE RecipeName = 'Salmon and Tuna'");
            migrationBuilder.Sql("UPDATE Recipes SET Description = 'Crocodile Fillets might be the last thing you have ever thought of feeding your dog, but it is some of the leanest meat you can find out there. The recipe is very low in fat and high in protein. Perfect for dogs with digestive problems or dogs on diet control.' WHERE RecipeName = 'Crocodile Fillet'");
            migrationBuilder.Sql("UPDATE Recipes SET Description = 'You can never go wrong with chicken breasts; they are just as healthy for your dog as they are for you. In this recipe, we''''ve added turmeric powder which helps promote better skin.' WHERE RecipeName = 'Chicken Breast'");
            migrationBuilder.Sql("COMMIT;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
