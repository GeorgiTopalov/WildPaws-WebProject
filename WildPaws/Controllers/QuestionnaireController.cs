using Microsoft.AspNetCore.Mvc;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Core.Constants;

namespace WildPaws.Controllers
{
    public class QuestionnaireController : BaseController
    {
        private readonly IQuestionnareService service;
        public QuestionnaireController(
            IQuestionnareService service)
        {
            this.service = service;
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
                return View(model);
            }

            if (await service.AddPet(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Successfully added Pet to data!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occured!";
            }


            return RedirectToAction("Index");
        }

    }
}
