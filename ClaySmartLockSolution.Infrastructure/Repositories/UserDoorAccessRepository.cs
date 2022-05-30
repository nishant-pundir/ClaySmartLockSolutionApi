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
    public class UserDoorAccessRepository : Repository<Core.Entities.UserDoorAccess>, IUserDoorAccessRepository
    {
        public UserDoorAccessRepository(UserContext userContext) : base(userContext)
        {
        }
   

        
    }
}
