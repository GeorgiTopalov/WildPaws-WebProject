﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;

namespace WildPaws.Controllers
{
    public class ForYourPetController : BaseController
    {
        private readonly IFormulaCalculationService service;


        public ForYourPetController(IFormulaCalculationService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {

            if (Request.Cookies.TryGetValue("QuestionnaireData", out var questionnaireData))
            {
                var model = JsonConvert.DeserializeObject<QuestionnaireViewModel>(questionnaireData);

                var recommendedRecipes = await service.RecommendedRecipes(model);
                ViewBag.Recipes = recommendedRecipes;

                var recipeNamesString = string.Join(", ", recommendedRecipes.Select(recipe => recipe.RecipeName));
                ViewBag.RecipeNamesString = recipeNamesString;

                var ingredientNamesList = new List<string>();
                foreach (var recipe in recommendedRecipes)
                {
                    ingredientNamesList.Add(string.Join(", ", recipe.Ingredients.Select(ingredient => ingredient.Name)));
                }
                ViewBag.IngredientNamesList = ingredientNamesList;


                var averageCalories = await service.CalculateAverageCalories(recommendedRecipes);
                ViewBag.AverageCalories = averageCalories;

                var gramsToConsume = await service.GramsToConsume(model, averageCalories);
                ViewBag.GramsToConsume = gramsToConsume;

                var pricePerDay = await service.PricePerDay(gramsToConsume);
                ViewBag.PricePerDay = pricePerDay;

                return View(model);
            }

            return View(new QuestionnaireViewModel());

        }
    }
}
