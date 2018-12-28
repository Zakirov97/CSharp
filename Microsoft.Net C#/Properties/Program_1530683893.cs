using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationIntro
{

    public class Tour
    {
        // Any change allowed here...
        private string _toCountry;
        public string ToCountry
        {
            get { return _toCountry; }

            set
            {
                if (value.Length == 3)
                {
                    _toCountry = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }
        public DateTime[] StartDates { get; private set; }
        public int[] AvaiablePlacesPerDate { get; private set; }

        // public decimal PlaceBaseCost { get; set; }
        private decimal _placeBaseCost;

        public decimal PlaceBaseCost // Property
        {
            get { return _placeBaseCost; }
            set
            {
                Console.WriteLine("...");
                _placeBaseCost = value;
            }
        }

        public string GetToCountry()
        {
            TourStorage.PopularityStatisticsByCountry[ToCountry]++;
            return ToCountry;
        }
        public void SetToCountry(string newValue)
        {
            int currentPopularity = TourStorage.PopularityStatisticsByCountry[ToCountry];
            TourStorage.PopularityStatisticsByCountry.Remove(ToCountry);
            TourStorage.PopularityStatisticsByCountry.Add(newValue, currentPopularity);
            ToCountry = newValue;
            Console.WriteLine("Warning, country name modified...");
        }

        public Tour(string toCountry, DateTime[] startDates,
            int[] avaiablePlacesPerDate, decimal placeBaseCost)
        {
            ToCountry = toCountry;
            StartDates = startDates;
            AvaiablePlacesPerDate = avaiablePlacesPerDate;
            PlaceBaseCost = placeBaseCost;

            TourStorage.PopularityStatisticsByCountry.Add(toCountry, 0);
        }

    }

    public class RandDate
    {
        public DateTime d = DateTime.Today;

        public RandDate()
        {
            d = DateTime.Today;
        }
        public DateTime RandomDate()
        {
            Random rnd = new Random();
            d.AddDays(rnd.Next(1, 100));
            return d;
        }
    }

    public static class TourStorage
    {
        public static Dictionary<string, int> PopularityStatisticsByCountry =
            new Dictionary<string, int>()
            {
                {"USA", 0}, {"Thailand", 0},
            };


        static RandDate d = new RandDate();

        public static Tour[] Tours =
        {

            new Tour(
                "USA",
                new [] {
                    new DateTime(2018, 08, 20),
                    new DateTime(2018, 08, 25),
                    new DateTime(2018, 08, 27)
                },
                new [] {10, 10, 10},
                1000),

            new Tour(
                "Austria",
                new [] {
                    new DateTime(2018, 09, 20),
                    new DateTime(2018, 09, 25),
                    new DateTime(2018, 09, 27)
                },
                new [] {10, 10, 10},
                2500),

            new Tour(
                "France",
                new [] {
                    new DateTime(2018, 07, 20),
                    new DateTime(2018, 07, 25),
                    new DateTime(2018, 07, 27)
                },
                new [] {10, 10, 10},
                3500),

            new Tour(
                "Germany",
                new [] {
                    new DateTime(2018, 05, 20),
                    new DateTime(2018, 05, 25),
                    new DateTime(2018, 05, 27)
                },
                new [] {10, 10, 10},
                5000),

            new Tour(
                "Italy",
                new [] {
                    new DateTime(2018, 10, 20),
                    new DateTime(2018, 10, 25),
                    new DateTime(2018, 10, 27)
                },
                new [] {10, 10, 10},
                4000),
        };
    }

    class TicketPurchaseService
    {
        public TicketResponse[] FindByCriteria(TicketRequest request)
        {
            List<TicketResponse> result = new List<TicketResponse>();

            var filteredByCountry = TourStorage.Tours
                .Where(p => p.GetToCountry() == request.ToCountryCode);

            foreach (var item in filteredByCountry)
            {
                for (int i = 0; i < item.StartDates.Length; i++)
                    if (item.StartDates[i] > request.FromPeriod && item.StartDates[i] < request.ToPeriod)
                        if (item.AvaiablePlacesPerDate[i] >= request.TicketCount)
                            result.Add(new TicketResponse(item.StartDates[i], item.PlaceBaseCost));
            }
            return result.ToArray();
        }

    }
    class TicketRequest
    {
        public string ToCountryCode;
        public DateTime FromPeriod;
        public DateTime ToPeriod;
        public int TicketCount;
    }

    class TicketResponse
    {
        public DateTime DepartureTime;
        public decimal Cost;
        public TicketResponse(DateTime DepartureTime, decimal Cost)
        {
            this.DepartureTime = DepartureTime;
            this.Cost = Cost;
        }
    }

    class Buyer
    {
        string name;
        decimal money;
        List<Tour> tours = new List<Tour>();
    }
    class BuyTicket
    {
        Tour t = new Tour(asd, );
        
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
