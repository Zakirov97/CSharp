using KazTourApp.DAL;
using KazTourApp.Shared.Models;
using KazTourApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.BLL
{
    public class TourService
    {
        private TourStorage _tourStorage;
        private BookStorage _bookStorage;
        private ClientStorage _clientStorage;

        public List<TourRecord> FilterByCriteria(TourSearchRequest request)
        {
            var allTours = _tourStorage.ReadAll()
              .Where(x => x.Country == request.ToCountry &&
                          x.MaxPersonsAllowed >= request.PersonCount);

            List<TourRecord> filteredTourRecords = new List<TourRecord>();

            foreach (var item in allTours)
            {
                foreach (var date in item.StartTimes)
                {
                    for (int i = -request.DepartureDateOffset; i <= request.DepartureDateOffset; i++)
                    {
                        if (request.DepartureDate.AddDays(i) == date)
                        {
                            filteredTourRecords.Add(item);
                        }
                    }
                }
            }
            return filteredTourRecords;
        }
        public TourService()
        {
            _tourStorage = new TourStorage();
        }
    }
}
