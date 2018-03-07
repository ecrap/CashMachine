using System;
using System.Linq;
using System.Web.Mvc;
using CashMachine.Dal;
using CashMachine.Models;

namespace CashMachine.Controllers
{
    public class AccountController : Controller
    {
        private CashMachineDal Dal { get; set; }

        public AccountController()
        {
            Dal = new CashMachineDal();
        }

        // GET: Movement
        public ActionResult Account(AccountVm account)
        {
            return View(account);
        }

        public ActionResult Validate(AccountVm account)
        {
            
            var view = "pin";
            object vm;
            var acc = Dal.Accounts.FirstOrDefault(x => x.cardNumber == account.Account.cardNumber);
            if (acc == null)
            {
                var err = new ErrorVm
                {
                    ErrorId = -1,
                    ErrorMessage = "Ivalid Card Number"
                };
                view = "Error";
                vm = err;
            }
            else
            {
                vm = account;
            }
            return View(view, vm);
        }

        public ActionResult Pin(AccountVm mov)
        {
            //mov.Movements = dal.Movements.ToList().Where(x => x.cardNumber == mov.Movement.cardNumber).ToList();
            return View( mov);
        }
    }
}