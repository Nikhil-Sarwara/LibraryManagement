using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Enums
{
    public enum BookStatus
    {
        Available = 0,
        CheckedOut = 1,
        Reserved = 2,
        Maintenance = 3,
        Lost = 4,
        Damaged = 5
    }
}
