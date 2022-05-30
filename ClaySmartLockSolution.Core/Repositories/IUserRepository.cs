using ClaySmartLockSolution.Core.Dto;
using ClaySmartLockSolution.Core.Entities;
using ClaySmartLockSolution.Core.Repositories.Base;


namespace ClaySmartLockSolution.Core.Repositories
{
 
    public interface IUserRepository : IRepository<User>
    {
        
        Task<User> GetUser(LoginModel user);
    }
}
