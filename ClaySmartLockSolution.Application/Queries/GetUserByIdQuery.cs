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
  
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public int Id { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
        {
            private readonly IUserRepository _userRepository;
            public GetUserByIdQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<UserResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByIdAsync(query.Id);
                if (user == null) return null;
                var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
                return userResponse;
            }
        }
    }
}
