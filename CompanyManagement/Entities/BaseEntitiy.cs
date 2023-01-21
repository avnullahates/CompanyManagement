using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.ENTITIES.Entities
{
    public class BaseEntitiy
    {
        [Key]
        public int ID { get; set; }

    }
}
