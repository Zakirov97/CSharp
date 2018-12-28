using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.Shared.ViewModels
{
    public class TourSearchRequest
    {
        public string ToCountry;
        public DateTime DepartureDate;
        public int DepartureDateOffset;
        public int PersonCount;

        public TourSearchRequest(string toCountry, DateTime departureDate, int departureOffset, int personCount)
        {
            ToCountry = toCountry;
            DepartureDate = departureDate;
            DepartureDateOffset = departureOffset;
            PersonCount = personCount;
        }
    }
}
