using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Application.Responses
{
    public class UserDoorAccessResponse
    {
        public int AccessId
        {
            get;
            set;
        }
        public DateTime AccessDate
        {
            get;
            set;
        }

        public bool AccessAtemptSuccess
        {
            get;
            set;
        }

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

    }
}
