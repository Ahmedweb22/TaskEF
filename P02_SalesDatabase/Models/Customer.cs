using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P02_SalesDatabase.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        [Unicode(false)]
        public string Email { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
