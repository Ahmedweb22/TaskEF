using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P02_SalesDatabase.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [MaxLength(50)]
        [Unicode(true)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
