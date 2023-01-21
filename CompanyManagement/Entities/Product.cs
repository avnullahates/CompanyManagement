using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.ENTITIES.Entities
{
    public class Product :BaseEntitiy
    {

        public string ProductName { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("ProductsFirm")]
        public int FirmID { get; set; }

        public Firm ProductsFirm { get; set; }
    }
}
