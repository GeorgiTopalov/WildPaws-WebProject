using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;
using WildPaws.Infrastructure.Data.Repositories;

namespace WildPaws.Core.Services
{
    public class QuestionnaireService : IQuestionnareService
    {

        private readonly IApplicationDbRepository repo;
        public QuestionnaireService(IApplicationDbRepository repo)
        {
            this.repo = repo;
        }


        public async Task<bool> AddPet(QuestionnaireViewModel model, string id)
        {
            bool result = false;
            var newPet = new Pet()
            {
                Id = model.Id,
                Name = model.Name,
                Breed = model.Breed,
                Weight = model.Weight,
                Age = model.Age,
                Gender = model.Gender,
                IsSpayed = model.IsSpayed,
                BodyStatus = model.BodyStatus,
                ActivityLevel = model.ActivityLevel,
                CurrentFoodType = model.CurrentFoodType,
                TreatsAndScraps = model.TreatsAndScraps,
                HasHealthIssues = model.HasHealthIssues,
                Comment = model.Comment,
                WildPawsUserId = id
            };

            try
            {
                await repo.AddAsync(newPet);
                await repo.SaveChangesAsync();
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return result;
            
        }

        public async Task<Pet> GetPetById(string id)
        {
            return await repo.GetByIdAsync<Pet>(id);
        }
    }
}
