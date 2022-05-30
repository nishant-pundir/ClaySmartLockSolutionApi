using ClaySmartLockSolution.Application.Commands;
using ClaySmartLockSolution.Application.Mappers;
using ClaySmartLockSolution.Application.Responses;
using ClaySmartLockSolution.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClaySmartLockSolution.Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepo;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var userEntitiy = UserMapper.Mapper.Map<Core.Entities.User>(request);

            var existingUser = await _userRepo.GetUser(new Core.Dto.LoginModel { Email = userEntitiy.Email });
            if (existingUser == null)
            {
                userEntitiy.Password = BCrypt.Net.BCrypt.HashPassword(userEntitiy.Password);//hash password
                var newUser = await _userRepo.AddAsync(userEntitiy);
                var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
                return userResponse;
            }

            return null;// duplicate


        }
    }
}
