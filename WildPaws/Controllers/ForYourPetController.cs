using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;

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

            // if (Request.Cookies.TryGetValue("QuestionnaireData", out var questionnaireData))
            var questionnaireData = TempData["QuestionnaireData"] as string;

            if (!string.IsNullOrEmpty(questionnaireData))
            {
                var model = JsonConvert.DeserializeObject<QuestionnaireViewModel>(questionnaireData);
                var recommendedRecipes = await service.RecommendedRecipes(model);

                ViewBag.Recipes = recommendedRecipes;
                ViewBag.RecipeNamesString =  GetRecipeNamesString(recommendedRecipes);
                ViewBag.IngredientNamesList =  GetIngredientNamesList(recommendedRecipes);
                ViewBag.AverageCalories = await service.CalculateAverageCalories(recommendedRecipes);
                ViewBag.GramsToConsume = await service.GramsToConsume(model, ViewBag.AverageCalories);
                ViewBag.PricePerDay = await service.PricePerDay(ViewBag.GramsToConsume);

                return View(model);
            }

            return View(new QuestionnaireViewModel());
        }

        private string GetRecipeNamesString(List<Recipe> recipes)
        {
            return string.Join(", ", recipes.Select(recipe => recipe.RecipeName));
        }

        private List<string> GetIngredientNamesList(List<Recipe> recipes)
        {
            return recipes.Select(recipe => string.Join(", ", recipe.Ingredients.Select(ingredient => ingredient.Name))).ToList();
        }


    }
}
