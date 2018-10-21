using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4
{
    [Table("categories")]
    public class Category
    {
        [Column("categoryid")]
        public int Id { get; set; }
        [Column("categoryname")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
