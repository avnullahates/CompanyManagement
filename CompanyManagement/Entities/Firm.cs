using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.ENTITIES.Entities
{
    public class Firm : BaseEntitiy
    {
        public string FirmName { get; set; }

        public bool ApprovalStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderStartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderEndDate { get; set; }






    }
}
