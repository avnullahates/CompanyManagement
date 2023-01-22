using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		[DisplayFormat(DataFormatString = "{0:t}")]
		[Column(TypeName = "datetime2")]
        public DateTime OrderStartDate { get; set; }

		[DisplayFormat(DataFormatString = "{0:t}")]
		[Column(TypeName = "datetime2")]
        public DateTime OrderEndDate { get; set; } 






    }
}
