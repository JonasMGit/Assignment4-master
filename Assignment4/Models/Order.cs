using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{   [Table("orders")]
    public class Order
    {
        [Column("orderid")]
        public int Id { get; set; }

        [Column("orderdate")]
        public DateTime Date { get; set; }

        [Column("requireddate")]
        public DateTime Required { get; set; }

        [Column("shipname")]
        public String ShipName { get; set; }

        [Column("shipcity")]
        public String ShipCity { get; set; }

       //public Product Product { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        
    }
}