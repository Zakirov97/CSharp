using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.Shared.Models
{
    public class TourRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime [] StartTimes { get; set; }
        public int [] DurationInDays { get; set; }
        public int [] PlacesLeft { get; set; }
        public int MaxPersonsAllowed { get; set; }
        public decimal BasePriceForPerson { get; set; }
        public TourRecord()
        {

        }
    }
}
