using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities {
    [Table(nameof(Car))]
    public class Car {
        [Key]
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Course { get; set; }
        public string RegisterNumber { get; set; }
    }
}
