using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaySmartLockSolution.Core.Entities
{
    public class Door
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 DoorId
        {
            get;
            set;
        }
        public string DoorLocation
        {
            get;
            set;
        }
        public virtual List<UserDoorAccess> UserDoorAccesses { get; set; }
    }
}
