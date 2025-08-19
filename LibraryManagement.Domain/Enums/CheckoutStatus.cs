using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Enums
{
    public enum CheckoutStatus
    {
        Active = 0,
        Returned = 1,
        Overdue = 2,
        Lost = 3,
        Renewed = 4
    }
}
