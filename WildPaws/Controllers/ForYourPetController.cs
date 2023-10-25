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
                ViewBag.AverageCalories =  service.CalculateAverageCalories(recommendedRecipes);
                ViewBag.GramsToConsume =  service.GramsToConsume(model, ViewBag.AverageCalories);
                ViewBag.PricePerDay =  service.PricePerDay(ViewBag.GramsToConsume);

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

        [HttpPost]
        public async Task<IActionResult> SubmitForm(QuestionnaireViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("index", model);
            }

            return RedirectToAction("Index", "FinalSteps", new { id = model.Id });

        }
    }
}
