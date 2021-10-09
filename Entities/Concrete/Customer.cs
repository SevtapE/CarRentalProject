using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   // [NotMapped]
    public class Customer:User,IEntity
    {
     
        public string CompanyName { get; set; }
    }
}
