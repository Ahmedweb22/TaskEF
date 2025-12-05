using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P02_SalesDatabase.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(50)]
        [Unicode(true)]
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; } 
        public decimal Price { get; set; }
        [MaxLength(250)]
        [Unicode(true)]
        [Required]
        [DefaultValue("No description")]
        public string Description { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
