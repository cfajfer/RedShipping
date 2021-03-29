using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedShipping.Models
{
    public class DBShipment
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int endLocation { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int startLocation { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string freightName { get; set; }

        public int quantity { get; set; }

        public int weight { get; set; }

    }
}