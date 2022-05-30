using ClaySmartLockSolution.Application.Mappers;
using ClaySmartLockSolution.Application.Responses;
using ClaySmartLockSolution.Core.Entities;
using ClaySmartLockSolution.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Application.Queries
{
    public class GetAllUserQuery : IRequest<List<UserResponse>>
    {
        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserResponse>>
        {
            private readonly IUserRepository _userRepository;
            public GetAllUserQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<List<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var allUser = await _userRepository.GetAllAsync();
                var usersListResponse = UserMapper.Mapper.Map<List<UserResponse>>(allUser);
                return usersListResponse;
            }
        }


    }
}
