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
        private readonly double pricePerGram = 0.375;
        public async Task<double> GramsToConsume(QuestionnaireViewModel model, double caloriesPerGram)
        {
            double idealWeight = CalculateIdealWeight(model.BodyStatus, model.Weight);

            double RER = 70 * Math.Pow(idealWeight, 3.0 / 4.0);

            double DER = CalculateDER(model, RER);

            double gramsToConsume = (DER / caloriesPerGram) * 100;

            return gramsToConsume;
        }


        public async Task<double> PricePerDay(double gramsToConsume, SubscriptionType subscriptionType)
        {
            double pricePerDay = gramsToConsume * pricePerGram * subscriptionType.Discount;

            return pricePerDay;
        }

        public async Task<double> SubscriptionPricce(double pricePerDay, SubscriptionType subscriptionType)
        {
            double subPrice = pricePerDay * subscriptionType.DaysActive;

            return subPrice;
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
            double result = factor / 3;

            return result;
        }

    }
}
