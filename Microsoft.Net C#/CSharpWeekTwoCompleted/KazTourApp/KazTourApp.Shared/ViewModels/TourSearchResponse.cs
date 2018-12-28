using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.Shared.ViewModels
{
    public class TourSearchResponse
    {
        public int Id;
        public string TourName;
        public string City;
        public int Popularity;
        public decimal FinalPrice;

        public TourSearchResponse(string tourName, string city, int popularity, decimal finalPrice)
        {
            TourName = tourName;
            City = city;
            Popularity = popularity;
            FinalPrice = finalPrice;
        }
    }
}
