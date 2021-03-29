using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedShipping.Models
{
    public class DBShipper
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string name { get; set; }

    }
}
