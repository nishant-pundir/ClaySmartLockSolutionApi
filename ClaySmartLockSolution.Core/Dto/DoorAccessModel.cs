using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Core.Dto
{
    public class DoorAccessModel
    {
        [Required]
        public int UserId
        {
            get;
            set;
        }
        [Required]
        public int DoorId
        {
            get;
            set;
        }
        [Required]
        public Guid DoorAccessTag
        {
            get;
            set;
        }


    }
}
