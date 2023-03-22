using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildPaws.Core.Contracts;
using WildPaws.Core.Models;
using WildPaws.Infrastructure.Data.Identity;
using WildPaws.Infrastructure.Data.Repositories;

namespace WildPaws.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        public UserService(IApplicationDbRepository repo)
        {
            this.repo = repo;
        }

        public async Task<WildPawsUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<WildPawsUser>(id);
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<WildPawsUser>(id);

            return new UserEditViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<WildPawsUser>()
                .Select(u => new UserListViewModel()
                {
                    Email = u.Email,
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<WildPawsUser>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await repo.SaveChangesAsync();
                result = true;
            }
           
            return result;
        }
    }
}
