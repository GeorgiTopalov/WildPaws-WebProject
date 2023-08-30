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


        public async Task<bool> AddPet(QuestionnaireViewModel model)
        {
            bool result = false;
            await repo.AddAsync(model);

            var newPet = await repo.GetByIdAsync<Pet>(model.Id);
            await repo.SaveChangesAsync();

            if (newPet != null)
            {
                result = true;
            }

            return result;
        }

        public async Task<Pet> GetPetById(string id)
        {
            return await repo.GetByIdAsync<Pet>(id);
        }
    }
}
