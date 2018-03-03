using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CashMachine.Models
{
    public class AccountVm
    {
        public AccountVm()
        {
            Account = new Account();
        }
        public Account Account { get; set; }
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
    }
}