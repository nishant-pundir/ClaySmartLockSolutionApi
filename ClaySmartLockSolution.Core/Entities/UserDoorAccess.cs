using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Core.Entities
{
    public class UserDoorAccess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 AccessId
        {
            get;
            set;
        }

        public Int64 UserId
        {
            get;
            set;
        }

        public Int64 DoorId
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

        public virtual User User { get; set; }
        public virtual Door Door { get; set; }
    }
}
