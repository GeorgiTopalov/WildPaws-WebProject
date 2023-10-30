using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<WildPawsUser>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<UserPet>()
                .HasKey(up => new { up.PetId, up.WildpawsUserId });

            builder.Entity<Recipe>()
        .HasMany(r => r.Ingredients)
        .WithMany(i => i.Recipes)
        .UsingEntity<RecipeIngredient>(
            j => j
                .HasOne(ri => ri.Ingredient)
                .WithMany()
                .HasForeignKey(ri => ri.IngredientId),
            j => j
                .HasOne(ri => ri.Recipe)
                .WithMany()
                .HasForeignKey(ri => ri.RecipeId)
        );

            builder.Entity<RecipeIngredient>()
                .HasKey(up => new { up.IngredientId, up.RecipeId });

            builder.Entity<Pet>()
               .HasOne(p => p.WildPawsUser)
               .WithMany(c => c.Pets)
               .HasForeignKey(p => p.WildPawsUserId)
               .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<UserPet> CustomerPets { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    }
}