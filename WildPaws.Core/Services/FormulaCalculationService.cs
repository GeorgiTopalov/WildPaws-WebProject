using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;

namespace WildPaws.Core.Services
{
    public class FormulaCalculationService : IFormulaCalculationService
    {
        public Task<double> GramsToConsume(QuestionnaireViewModel model, double caloriesPerGram)
        {
            throw new NotImplementedException();
        }

        public Task<double> PricePerDay(double gramsToConsume, SubscriptionType subscriptionType)
        {
            throw new NotImplementedException();
        }

        public Task<double> SubscriptionPricce(double pricePerDay, SubscriptionType subscriptionType)
        {
            throw new NotImplementedException();
        }
    }
}
