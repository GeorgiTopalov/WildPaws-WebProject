using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WildPaws.Core.Models;

namespace WildPaws.Controllers
{
    public class ForYourPet : BaseController
    {
        public IActionResult Index()
        {
            if (Request.Cookies.TryGetValue("QuestionnaireData", out var questionnaireData))
            {
                var model = JsonConvert.DeserializeObject<QuestionnaireViewModel>(questionnaireData);
                return View(model);
            }

            return View(new QuestionnaireViewModel());

        }
    }
}
