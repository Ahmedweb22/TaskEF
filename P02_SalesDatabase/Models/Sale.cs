using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime Date { get; set; } 
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey(nameof(StoreId))]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
