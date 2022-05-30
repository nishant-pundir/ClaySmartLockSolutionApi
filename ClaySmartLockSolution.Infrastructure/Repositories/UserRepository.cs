using ClaySmartLockSolution.Core.Dto;
using ClaySmartLockSolution.Core.Repositories;
using ClaySmartLockSolution.Infrastructure.Data;
using ClaySmartLockSolution.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Infrastructure.Repositories
{
    public class UserRepository : Repository<Core.Entities.User>, IUserRepository
    {
        public UserRepository(UserContext userContext) : base(userContext)
        {
        }
   

        public async Task<Core.Entities.User> GetUser(LoginModel user)
        {
            var any = _userContext.Users.Any(x => x.Email == user.Email);
            if (any)
                return await _userContext.Users.Where(x => x.Email == user.Email).SingleAsync();
            else
                return null;

        }
    }
}
