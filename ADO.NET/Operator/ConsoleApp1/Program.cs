using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelEntity db = new ModelEntity();
            //db.Database.Log = Console.Write;

            Operator oper = new Operator
            {
                CreateDate = DateTime.Now,
                OperatorAdditional = new OperatorAdditional
                {
                    Logo = "",
                    Name = "Kcell",
                    floatTax = 2.5,
                    IsActive = true,
                    Address = new Address
                    {
                        Contry = "Kazakhstan",
                        City = "Almaty",
                        House = "256/56",
                        AddressTypeId = 1
                    }
                }
            };

            db.Operator.Add(oper);
            db.SaveChanges();

            foreach (Operator oper2 in db.Operator.ToList())
            {
                Console.WriteLine(oper2.OperatorId + " - " + oper2.CreateDate);
            }

            //Attach
            //1
            //using (ModelEntity db1 = new ModelEntity())
            //{
            //    Operator op = db1.Operator
            //        .Find(Guid.Parse("BD76E21D-83EC-E811-80D0-D050998DB6A8"));
            //    //UpdateOperator(op);
            //}
            Console.WriteLine("OK");




            //var oper = db.Address.Find(Guid.Parse("BD76E21D-83EC-E811-80D0-D050998DB6A8"));
            //db.Address.Remove(oper);
            //db.SaveChanges();

            //Operator oper = new Operator
            //{
            //    CreateDate = DateTime.Now,
            //    Logo = "",
            //    Name = "Kcell",
            //    floatTax = 2.5,
            //    IsActive = true,
            //    Address = new Address
            //    {
            //        Contry = "Kazakhstan",
            //        City = "Almaty",
            //        House = "256/56",
            //        AddressType = new AddressType
            //        {
            //            Name = "Legasy address"
            //        }
            //    }
            //};

            //db.Operator.Add(oper);
            //db.SaveChanges();
            //OperatorId - УЖЕ ЕСТЬ !!!

            Console.ReadKey();
        }


        static void UpdateOperator(Operator op)
        {
            using (ModelEntity db = new ModelEntity())
            {
                if (op != null)
                {
                    db.Operator.Attach(op);
                    op.CreateDate = DateTime.Now.AddDays(23);
                    db.SaveChanges();
                }
            }
        }
    }
}
