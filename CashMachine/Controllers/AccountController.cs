using System;
using System.Linq;
using System.Web.Mvc;
using CashMachine.Bl;
using CashMachine.Dal;
using CashMachine.Models;

namespace CashMachine.Controllers
{
    public class AccountController : Controller
    {
        private CashMachineDal Dal { get; set; }
        private ErrorVm ErrorVm { get; set; }
        private Log Log { get; set; }
        public AccountController()
        {
            Dal = new CashMachineDal();
            ErrorVm = new ErrorVm();
            Log = new Log();
        }
        private void UnControlledException(string cardNumber, Exception ex)
        {
            ErrorVm.CardNumber = cardNumber;
            ErrorVm.ErrorId = ex.HResult;
            ErrorVm.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            Log.LogEntry(ErrorVm);
            ErrorVm.ErrorId = (int)Error.Internal_Application_Error;
            ErrorVm.ErrorMessage = Error.Internal_Application_Error.ToString().Replace("_", " ");
        }
        public ActionResult Account(AccountVm aVm)
        {
            return View(aVm);
        }
        public ActionResult Validate(AccountVm aVm)
        {
            var view = "pin";
            object vm;
            try
            {
                var acc = Dal.Accounts.FirstOrDefault(x => x.cardNumber == aVm.Account.cardNumber);
                if(acc != null)
                    vm= aVm;
                else
                {
                    throw new Exception(Error.Invalid_Card_Number.ToString());
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == Error.Invalid_Card_Number.ToString())
                {
                    ErrorVm.ErrorId = (int) Error.Invalid_Card_Number;
                    ErrorVm.ErrorMessage = Error.Invalid_Card_Number.ToString().Replace("_", " ");
                }
                else
                {
                    UnControlledException(aVm.Account.cardNumber, ex);
                }
                view = "Error";
                vm = ErrorVm;
            }
            return View(view, vm);  
        }

        public ActionResult Pin(AccountVm account)
        {
            //mov.Movements = dal.Movements.ToList().Where(x => x.cardNumber == mov.Movement.cardNumber).ToList();
            return View(account);
        }
    }
}