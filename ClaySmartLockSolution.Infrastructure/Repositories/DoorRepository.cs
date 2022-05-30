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
    public class DoorRepository : Repository<Core.Entities.Door>, IDoorRepository
    {
        public DoorRepository(UserContext userContext) : base(userContext)
        {
        }
   

    
    }
}
