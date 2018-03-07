using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashMachine.Models
{
    public enum Error
    {
        Invalid_Card_Number = -3,
        Invalid_Password,
        Internal_Application_Error
    }
    
}