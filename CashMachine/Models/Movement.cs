using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CashMachine.Models
{
    public class Movement
    {
        [Key]
        public int Id { get; set; }
        public string cardNumber { get; set; }
        public DateTime? movementDate { get; set; }
        public int? operation { get; set; }
        public double? ammount { get; set; }
        public double? previousBalance { get; set; }
    }
}