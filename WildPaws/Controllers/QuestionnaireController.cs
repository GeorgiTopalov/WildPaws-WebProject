using Microsoft.AspNetCore.Mvc;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Core.Constants;
using Microsoft.AspNetCore.Identity;
using WildPaws.Infrastructure.Data.Identity;
using Newtonsoft.Json;

namespace WildPaws.Controllers
{
    public class QuestionnaireController : BaseController
    {
        private readonly IQuestionnareService service;
        private readonly UserManager<WildPawsUser> userManager;
        public QuestionnaireController(
            IQuestionnareService service,
            UserManager<WildPawsUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(QuestionnaireViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("index", model);
            }

            var questionnaireData = JsonConvert.SerializeObject(model);
            Response.Cookies.Append("QuestionnaireData", questionnaireData);


            return RedirectToAction("Index", "ForYourPet", new { id = model.Id });
        }


    }
}
