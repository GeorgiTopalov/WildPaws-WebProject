using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();
        Task<UserEditViewModel> GetUserForEdit(string id);
        Task<bool> UpdateUser(UserEditViewModel model);
        Task<WildPawsUser> GetUserById(string id);
    }
}
