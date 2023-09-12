using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;

namespace WildPaws.Controllers
{
    public class ForYourPetController : BaseController
    {
        private readonly IQuestionnareService service;


        public ForYourPetController(IQuestionnareService service)
        {
            this.service = service;
        }
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
