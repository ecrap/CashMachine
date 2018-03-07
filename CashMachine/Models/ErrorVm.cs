using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CashMachine.Models
{
    public class ErrorVm
    {
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public string CardNumber { get; set; }
    }
}