using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections2
{
    // Extension-Methods
    // User comes from external library

    // Value-Type and Reference-Type

    //interface IBaseInterface
    //{
    //    string GetGreeting();
    //}

    //class Reception : IBaseInterface
    //{
    //    public string GetGreeting()
    //    {
    //        return "Nihao!";
    //    }
    //}
    class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string BornCity { get; set; }
        public string BornCountry { get; set; }
        public List<decimal> LastPurchases { get; set; }
        public bool IsVipCustomer { get; set; }
        public override string ToString()
        {
            return $"{Id} : {Email} : {BornCountry}";
        }
        public User(string email, string bornCity, string bornCountry, bool isVipCustomer, params decimal[] purchases)
        {
            LastPurchases = new List<decimal>();

            Id = Guid.NewGuid().ToString();
            Email = email;
            BornCity = BornCity;
            BornCountry = bornCountry;
            IsVipCustomer = isVipCustomer;
            foreach (var item in purchases)
            {
                LastPurchases.Add(item);
            }
        }
    }
    //static class ExtensionMethods
    //{
    //    public static string GetEncryptedId(this User user)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        foreach (var item in user.Id)
    //        {
    //            sb.Append((char)(item + 1));
    //        }
    //        return sb.ToString();
    //    }

    //    public static int AsciiCodeSum(this string input)
    //    {
    //        int sum = 0;
    //        foreach (var item in input)
    //        {
    //            sum += (int)(item);
    //        }
    //        return sum;
    //    }

    //    public static int GetFieldsCount(this LiteDatabase ld, string fieldName)
    //    {
    //        return 0;
    //    }
    //    public static int GetCollectionCount(this LiteDatabase ld)
    //    {
    //        return (ld.GetCollectionNames() as ICollection<string>).Count;
    //    }
    //    public static string GetFarewell(this IBaseInterface baseInterface)
    //    {
    //        return "Sayonara...";
    //    }
    //}
    class Program
    {
        static bool IsArmstrong(int input)
        {
            string inputString = input.ToString();
            int inputLength = inputString.Length;
            int output = 0;

            for (int i = 0; i < inputLength; i++)
            {
                output += (int)Math.Pow(int.Parse(inputString[i].ToString()), inputLength);
            }
            return input == output;
        }
        //decimal Sum(decimal[] purchases)
        //{
        //    decimal sum = 0;
        //    foreach (var item in purchases)
        //    {
        //        sum += item;
        //    }
        //    return sum;
        //}
        static void Main(string[] args)
        {
            // IEnumerable
            // ICollection
            // IList

            //IEnumerable<User> enumerable = new List<User>()
            //{
            //    new User("zero@company.com"),
            //    new User("grokking@company.com"),
            //    new User("ceo@company.com")
            //};

            //ICollection<User> collection =
            //    enumerable as ICollection<User>;

            //collection.Add(new User("cto@compnay.com"));

            //foreach (var item in collection)
            //{
            //    Console.WriteLine(item.GetEncryptedId());
            //}

            //IList<User> list = collection as IList<User>;

            //List<User> fullList = list as List<User>;

            //User u = new User("ceo@company.com");
            //Console.WriteLine(u.GetEncryptedId());

            //string password = "12345";
            //Console.WriteLine(password.AsciiCodeSum());

            //Reception r = new Reception();
            //IBaseInterface r1 = new Reception();


            ////LiteDatabase ld = new LiteDatabase("");
            ////Console.WriteLine(ld.GetFieldsCount("int"));
            //string x = null;
            //StringBuilder sb = null;
            //DateTime ? dt = default(DateTime);
            //Nullable<int> i = default(int);
            //i = null;
            //Console.WriteLine(dt.HasValue);

            List<User> users = new List<User>()
            {
                new User("kaisar@itstep.kz", "Almaty", "Kazakhstan", false, 100, 200, 100, 350, 250, 100, 200, 150, 500),
                new User("dias@itstep.kz", "Astana", "Kazakhstan", false, 100, 200, 100, 350, 250, 100, 200, 150, 500),
                new User("ekaterina@itstep.kz", "Taraz", "Kazakhstan", false, 100, 200, 100, 350, 250, 100, 200, 150, 500),
                new User("rasul@itstep.kz", "Shymkent", "Kazakhstan", false, 100, 200, 100, 350, 250, 100, 200, 150, 500),
                new User("alexander@itstep.kz", "Aktobe", "Kazakhstan", false, 1634),
                new User("lev@itstep.kz", "Moscow", "Russia", false, 200, 200, 200, 200, 200, 200, 200, 200, 600),
                new User("zahar@itstep.kz", "Siera-Del-Tore", "Mexico", false, 100, 200, 100, 350, 250, 100, 200, 150, 500),
                new User("eldar@itstep.kz", "Seoul", "South Korea", false, 100, 200, 100, 350, 250, 100, 200, 150, 500),
                new User("dana@itstep.kz", "Dushanbe", "Tazhikisitan", false, 100, 2000, 100, 350, 250, 100, 200, 150, 500),
                new User("daniyar@itstep.kz", "Sibir", "Russia", false, 100, 200, 100, 350, 250, 100, 200, 150, 500),
                new User("adilkhan@itstep.kz", "Tashkent", "Uzbekistan", false, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 10000),
            };

            List<int> integers = new List<int>() { 372, 408, 1635 };

            // Exists = is there any customer that ... => T / F
            // Find / FindAll = filter all customers that satisfy to condition N => Filtered

            bool isUserFromRussiaExists = users.Exists(p => p.BornCountry == "Russia");

            bool isUserMajorExists = users.Exists(p => p.LastPurchases.Average() >= 500);

            bool isSuspectedUserExists = users.Exists(p => ((p.LastPurchases.Max() - p.LastPurchases.Min()) >= 500));

            bool isExistArmstrong = integers.Exists(p => IsArmstrong(p) && p >= 0);
            var VipCustomers = users.FindAll(x => x.LastPurchases.Sum() >= 2000);
            VipCustomers.ForEach(p => { p.IsVipCustomer = true; });

            Dictionary<string, List<User>> usersByCountry = new Dictionary<string, List<User>>();
            //usersByCountry.Add(,users.FindAll(x=>x.BornCountry==()))

            users.ForEach(p => {
                p.BornCountry == usersByCountry.ContainsKey(p.BornCountry)
                usersByCountry.Add(p.BornCountry, p);
            });
            
             

            //var filtred = users.FindAll(p => p.BornCountry != "Kazakhstan");

            //decimal x = 0;
            //foreach (var item in users)
            //{
            //    x += item.LastPurchases.Average();
            //}
            //x /= users.Count;
            //var filtred = users.FindAll(p => p.LastPurchases.Average() >= x);

            //foreach (var item in filtred)
            //{
            //    Console.WriteLine(item);
            //}

            //users.ForEach(p =>
            //{
            //    Console.WriteLine(IsArmstrong((int)p.LastPurchases.Average()));
            //});

            //var result = users.Select(p => IsArmstrong((int) p.LastPurchases.Average()));

            var averagePurchaseSumForAll = users
                .FindAll(x => x.LastPurchases
                    .Average() >= users
                        .Select(p => p.LastPurchases
                        .Average())
                        .Average());



            Console.ReadLine();
        }
    }
}
