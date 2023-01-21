using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.ENTITIES.Entities
{
    public class Order : BaseEntitiy
    {
        public string CustomerName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        [ForeignKey("OrdersFirm")]
        public int FirmID { get; set; }

        public Firm OrdersFirm { get; set; }


        [ForeignKey("OrdersProdcut")]
        public int ProductID { get; set; }

        public Product OrdersProdcut { get; set; }



    }
}
