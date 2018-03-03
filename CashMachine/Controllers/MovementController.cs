using System;
using System.Linq;
using System.Web.Mvc;
using CashMachine.Dal;
using CashMachine.Models;

namespace CashMachine.Controllers
{
    public class MovementController : Controller
    {
        // GET: Movement
        public ActionResult Balance(MovementVm mov)
        {
            var dal = new CashMachineDal();
            mov.Movements = dal.Movements.ToList().Where(x => x.cardNumber == mov.Movement.cardNumber && x.operation == (int)Operations.Withdrawall).ToList();
            RecordOperation(mov.Movement, Operations.BalanceCheck);
            return View(mov);
        }

        public ActionResult Report(MovementVm mov)
        {
            var dal = new CashMachineDal();
            mov.Movements = dal.Movements.ToList().Where(x => x.cardNumber == mov.Movement.cardNumber).ToList();
            return View(mov);
        }
        private void RecordOperation(Movement movement, Operations op)
        {
            var dal = new CashMachineDal();
            var acc = dal.Accounts.FirstOrDefault(x => x.cardNumber == movement.cardNumber);
            movement.operation = (int)op;
            movement.movementDate = DateTime.Now;
            if (acc != null) movement.previousBalance = acc.balance;
            dal.Movements.Add(movement);
            dal.SaveChanges();
        }

        public ActionResult Withdrawal(MovementVm mov)
        {
            var dal = new CashMachineDal();
            mov.Movements = dal.Movements.ToList().Where(x => x.cardNumber == mov.Movement.cardNumber).ToList();
            mov.Movement.ammount = null;
            return View(mov);
        }

        public ActionResult Extraction(MovementVm mov)
        {

            var dal = new CashMachineDal();
            var acc = dal.Accounts.FirstOrDefault(x => x.cardNumber == mov.Movement.cardNumber);
            if (Validate(mov, acc))
            {
                RecordOperation(mov.Movement, Operations.Withdrawall);
                acc.balance -= mov.Movement.ammount;
                dal.SaveChanges();
                mov.ErrorId = 1;
            }
            return View("Withdrawal", mov);

        }

        private static bool Validate(MovementVm mov, Account acc)
        {
            var retValue = true;
            if (acc == null)
            {
                mov.ErrorId = -1;
                mov.ErrorMessage = "Error getting Balance information";
                retValue = false;
            }
            else
            {
                if (acc.balance < mov.Movement.ammount)
                {
                    mov.ErrorId = -1;
                    mov.ErrorMessage = "Insufficient funds";
                    retValue = false;
                }
            }
            return retValue;
        }

    }
}