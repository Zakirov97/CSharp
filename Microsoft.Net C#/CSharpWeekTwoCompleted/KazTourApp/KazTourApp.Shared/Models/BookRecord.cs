using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.Shared.Models
{
    public class BookRecord
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PersonCount { get; set; }
        public decimal TourTotalCost { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
