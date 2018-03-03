using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CashMachine.Models
{
    public class Account
    {
        [Required]
        [Key]
        [StringLength(19)]
        public string cardNumber { get; set; }
        public int? pin { get; set; }
        public double? balance { get; set; }
        public DateTime? lockedDate { get; set; }
    }
}