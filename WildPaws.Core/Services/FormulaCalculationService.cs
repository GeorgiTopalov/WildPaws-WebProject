using Microsoft.EntityFrameworkCore;
using WildPaws.Core.Constants;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;
using WildPaws.Infrastructure.Data.Repositories;

namespace WildPaws.Core.Services
{
    public class FormulaCalculationService : IFormulaCalculationService
    {
        private readonly double pricePerGram = 0.375;
        private readonly IApplicationDbRepository repo;

        public FormulaCalculationService(IApplicationDbRepository repo)
        {
            this.repo = repo;
        }
        public async Task<List<Recipe>> RecommendedRecipes(QuestionnaireViewModel model)
        {
            var recommendedRecipes = await repo.All<Recipe>()
                .Include(r=>r.Ingredients)
                .ToListAsync();


            if (model.Age > 8)
            {
                recommendedRecipes.RemoveAll(recipe => recipe.RecipeName == RecipeNames.Beef);
            }
            else
            {
                recommendedRecipes.RemoveAll(recipe => recipe.RecipeName == RecipeNames.AdChicken);

            }
            if (model.BodyStatus == "Obese" || model.BodyStatus == "Overweight")
            {
                recommendedRecipes.RemoveAll(recipe => recipe.RecipeName == RecipeNames.SalmonTuna);
            }
            else
            {
                recommendedRecipes.RemoveAll(recipe => recipe.RecipeName == RecipeNames.Crocodile);
            }

            return recommendedRecipes;
        }
        public async Task<double> GramsToConsume(QuestionnaireViewModel model, double caloriesPerGram)
        {
            double idealWeight = CalculateIdealWeight(model.BodyStatus, model.Weight);

            double RER = 70 * Math.Pow(idealWeight, 3.0 / 4.0);

            double DER = CalculateDER(model, RER);

            double gramsToConsume = (DER / caloriesPerGram) * 100;

            return gramsToConsume;
        }


        public async Task<double> PricePerDay(double gramsToConsume)
        {
            double pricePerDay = gramsToConsume * pricePerGram;

            return Math.Round(pricePerDay, 2);
        }

        public async Task<double> SubscriptionPricce(double pricePerDay, SubscriptionType subscriptionType)
        {
            double subPrice = pricePerDay * subscriptionType.DaysActive * subscriptionType.Discount;

            return subPrice;
        }

        public async Task<double> CalculateAverageCalories(List<Recipe> recommendedRecipes)
        {
            double totalCalories = 0;

            foreach (var recipe in recommendedRecipes)
            {
                double recipeCalories = 0;

                    switch (recipe.RecipeName)
                    {
                        case "Chicken and Dory":
                            recipeCalories += FormulaCalories.ChickenDory;
                            break;
                        case "Salmon and Tuna":
                            recipeCalories += FormulaCalories.Salmon;
                            break;
                        case "Crocodile Fillet":
                            recipeCalories += FormulaCalories.Crocodile;
                            break;
                        case "Beef":
                            recipeCalories += FormulaCalories.Beef;
                            break;
                        case "Chicken Breast":
                            recipeCalories += FormulaCalories.Chicken;
                            break;
                    }
                

                totalCalories += recipeCalories;
            }

            // Calculate the average grams to consume
            double averageCalories = totalCalories / recommendedRecipes.Count;

            return Math.Round(averageCalories, 2);
        }
        private double CalculateIdealWeight(string bodyStatus, double weight)
        {


            switch (bodyStatus)
            {
                case "Underweight":
                    weight /= 0.9;
                    break;
                case "Normal":
                    weight = weight;
                    break;
                case "Overweight":
                    weight /= 1.1;
                    break;
                case "Obese":
                    weight /= 1.2;
                    break;
            }

            return weight;
        }

        private double CalculateDER(QuestionnaireViewModel model, double RER)
        {
            double factor = 0;

            switch (model.IsSpayed)
            {
                case true:
                    factor += 1.2;
                    break;
                case false:
                    factor += 1.4;
                    break;
            }

            switch (model.ActivityLevel)
            {
                case "Not very active (Primarily stays at home)":
                    factor += 1.1;
                    break;
                case "Active(Often taken for walkies and regular play time)":
                    factor += 1.3;
                    break;
                case "Very active (Dog lives outdoors where it runs all day or taken for long walks for few hours a day)":
                    factor += 1.6;
                    break;
            }

            switch (model.TreatsAndScraps)
            {
                case "Rarely":
                    factor += 1;
                    break;
                case "Some treats and/or scraps":
                    factor += 1.2;
                    break;
                case "A lot of treats and/or scraps":
                    factor += 1.4;
                    break;
            }
            double result = (factor / 3) * RER;

            return Math.Round(result, 2);
        }

   
    }
}
