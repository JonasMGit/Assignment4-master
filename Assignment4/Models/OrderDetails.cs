using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{   [Table("orderdetails")]
    public class OrderDetails
    {

        [Column("orderid")]
        public int OrderId { get; set; }


        [Column("productid")]
        public int ProductId { get; set; }

        [Column("unitprice")]
        public double UnitPrice { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public double Discount { get; set; }

        //[Column("product")]
        public Product Product { get; set; }

        // [Column("order")]
        public Order Order { get; set; }

        


    }
}