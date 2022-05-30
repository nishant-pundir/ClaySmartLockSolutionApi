using ClaySmartLockSolution.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Application.Commands
{
  
    public class CreateDoorAccessCommand : IRequest<List<UserDoorAccessResponse>>
    {

        public int UserId
        {
            get;
            set;
        }

        public int DoorId
        {
            get;
            set;
        }

      

        public bool AccessAtemptSuccess
        {
            get;
            set;
        }


    }
}
