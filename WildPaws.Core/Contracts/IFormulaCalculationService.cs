using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;

namespace WildPaws.Core.Contracts
{
    public interface IFormulaCalculationService
    {
        public double GramsToConsume(QuestionnaireViewModel model, double caloriesPerGram);
        public double PricePerDay(double gramsToConsume);
        public double SubscriptionPricce(double pricePerDay, SubscriptionType subscriptionType);
        public Task<List<Recipe>> RecommendedRecipes(QuestionnaireViewModel model);

        public double CalculateAverageCalories(List<Recipe> recommendedRecipes);
    }
}
