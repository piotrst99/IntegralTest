using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities {
    [Table(nameof(CarRepair))]
    public class CarRepair {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RepairDate { get; set; }
        public int Cost { get; set; }
        public bool IsRepair { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
    }
}
