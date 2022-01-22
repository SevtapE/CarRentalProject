using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarRentDetailDto :IDto
    {
        public int CarId { get; set; }
        public Nullable<int> RentalId { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
