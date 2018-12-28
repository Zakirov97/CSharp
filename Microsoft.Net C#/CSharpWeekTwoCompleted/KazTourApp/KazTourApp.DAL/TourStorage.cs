using KazTourApp.Shared.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.DAL
{
    public class TourStorage
    {
        public void AddTour(TourRecord record)
        {
            using (var db = new LiteDatabase(@"C:\Users\РаимбаевИ\Databases\LiteDb.db"))
            {
                var tours = db.GetCollection<TourRecord>("tours");
                tours.Insert(record);
            }
        }

        public List<TourRecord> ReadAll()
        {
            using (var db = new LiteDatabase(@"C:\Users\РаимбаевИ\Databases\LiteDb.db"))
            {
                var tours = db.GetCollection<TourRecord>("tours");
                return tours.FindAll().ToList();
            }
        }
    }
}
