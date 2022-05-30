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
    public class CreateDoorAccessHandler : IRequestHandler<CreateDoorAccessCommand, List<UserDoorAccessResponse>>
    {
      
        private readonly IUserDoorAccessRepository _userDoorAccessRepository;
        public CreateDoorAccessHandler(IUserDoorAccessRepository userDoorAccessRepository)
        {
            _userDoorAccessRepository = userDoorAccessRepository;
        }
        public async Task<List<UserDoorAccessResponse>> Handle(CreateDoorAccessCommand request, CancellationToken cancellationToken)
        {
            var doorAccess = UserMapper.Mapper.Map<Core.Entities.UserDoorAccess>(request);
            if (doorAccess is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            await _userDoorAccessRepository.AddAsync(doorAccess);
            var lstHistorical = await _userDoorAccessRepository.GetAllAsync();

            var doorAccessResponse = UserMapper.Mapper.Map<List<UserDoorAccessResponse>>(lstHistorical.Where(x=>x.UserId== request.UserId&&x.DoorId==x.DoorId));
            return doorAccessResponse;
        }
    }
}
