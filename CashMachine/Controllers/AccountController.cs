using System;
using System.Linq;
using System.Web.Mvc;
using CashMachine.Dal;
using CashMachine.Models;

namespace CashMachine.Controllers
{
    public class AccountController : Controller
    {
        // GET: Movement
        public ActionResult Account(AccountVm mov)
        {
            return View(mov);
        }

        public ActionResult Validate(AccountVm mov)
        {
            //var dal = new CashMachineDal();
            //mov.Movements = dal.Movements.ToList().Where(x => x.cardNumber == mov.Movement.cardNumber).ToList();
            return View("pin",mov);
        }

        public ActionResult Pin(AccountVm mov)
        {
            //var dal = new CashMachineDal();
            //mov.Movements = dal.Movements.ToList().Where(x => x.cardNumber == mov.Movement.cardNumber).ToList();
            return View("pin", mov);
        }
    }
}