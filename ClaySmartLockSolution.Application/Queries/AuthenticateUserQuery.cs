using ClaySmartLockSolution.Application.Mappers;
using ClaySmartLockSolution.Application.Responses;
using ClaySmartLockSolution.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Application.Queries
{
    public class AuthenticateUserQuery : IRequest<UserResponse>
    {
        public Core.Dto.LoginModel user { get; set; }
        public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, UserResponse>
        {

            private readonly IUserRepository _userRepository;
            public AuthenticateUserQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<UserResponse> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
            {
                var authenticatedUser = await _userRepository.GetUser(request.user);
                if (authenticatedUser != null && BCrypt.Net.BCrypt.Verify(request.user.Password, authenticatedUser.Password))
                {
                    var usersListResponse = UserMapper.Mapper.Map<UserResponse>(authenticatedUser);
                    return usersListResponse;
                }
                return null;
            }
        }


    }
}
