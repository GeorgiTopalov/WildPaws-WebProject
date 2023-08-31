using Microsoft.AspNetCore.Mvc;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Core.Constants;
using Microsoft.AspNetCore.Identity;
using WildPaws.Infrastructure.Data.Identity;

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
                return View(model);
            }

            var userId = userManager.GetUserId(User);

            if (await service.AddPet(model, userId))
            {
                ViewData[MessageConstant.SuccessMessage] = "Successfully added Pet to data!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occured!";
            }


            return RedirectToAction("Index", "ForYourPet", new { id = model.Id });
        }


    }
}
