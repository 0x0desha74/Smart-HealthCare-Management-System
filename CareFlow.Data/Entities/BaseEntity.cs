using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
    public class BaseEntity
    {
     
        public Guid Id { get; set; } = Guid.NewGuid(); 
    }
}
