using ConsoleApp2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static ModelEntity db = new ModelEntity();
        static void Main(string[] args)
        {
            //a
            //var mas = db.Area.Where(w => w.WorkingPeople > 2).Select(s =>s.Name);
            //b
            //var mas = db.Area.Where(w => w.AssemblyArea == true).Select(s => s.Name);
            //c
            //var mas = db.Area.Take(10);
            //e
            //var mas = db.Area.SkipWhile(p => p.OrderExecution == null);
            //f
            //var mas = db.Area.SkipWhile(p => p.OrderExecution != null);
            //g
            //var mas = db.Area.Where(p => db.Area.Where(w => w.IP == p.IP).Count() == 1);
            //h
            //int[] nums = { 22, 23, 24, 25, 26, 27, 28 };
            //var mas = db.Timer.Where(w => w.AreaId != null && nums.ToList().Contains((int)w.AreaId));

            //i
            //List<int> nums = new List<int> () { 38, 39, 102 };
            //var mas = db.Timer
            //    .Where(w => w.AreaId != null && nums.Contains((int)w.AreaId))
            //    .Where(w => w.DateStart != DateTime.MinValue)
            //    .Where(w => w.DateStart >= new DateTime(2017, 08, 30) && w.DateFinish <= new DateTime(2017, 08, 30));

            foreach (var item in mas)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
