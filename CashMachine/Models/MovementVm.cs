using System.Collections.Generic;

namespace CashMachine.Models
{
    public class MovementVm
    {
        public MovementVm()
        {
            Movement = new Movement {ammount = 0};
        }
        public Movement Movement { get; set; }
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public IList<Movement> Movements { get; set; }
    }
}