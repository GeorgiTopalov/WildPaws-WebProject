using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data;

namespace WildPaws.Core.Contracts
{
    public interface IQuestionnareService
    {
        Task<bool> AddPet(QuestionnaireViewModel model, string id);
        Task<Pet> GetPetById(string id);
    }
}
