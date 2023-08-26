using Microsoft.AspNetCore.Mvc;
using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;

namespace WildPaws.Controllers
{
    public class QuestionnaireController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public QuestionnaireController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(Pet pet)
        {
            // Assuming you have a _dbContext instance as shown in the previous example
            dbContext.Pets.Add(pet);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
