using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;

namespace WildPaws.Core.Contracts
{
    public interface IFormulaCalculationService
    {
        public Task<double> GramsToConsume(QuestionnaireViewModel model, double caloriesPerGram);
        public Task<double> PricePerDay(double gramsToConsume, SubscriptionType subscriptionType);
        public Task<double> SubscriptionPricce(double pricePerDay, SubscriptionType subscriptionType);
        public Task<List<Recipe>> RecommendedRecipes(QuestionnaireViewModel model);
    }
}
