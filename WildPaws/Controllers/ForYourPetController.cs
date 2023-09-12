using Microsoft.AspNetCore.Mvc;
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

                return View(model);
            }

            return View(new QuestionnaireViewModel());

        }
    }
}
