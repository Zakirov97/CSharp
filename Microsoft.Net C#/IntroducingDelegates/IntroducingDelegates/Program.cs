using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntroducingDelegates
{
    #region Part Two
    public enum GovernmentType
    {
        President, Parlament, Monarch
    }
    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DayOfIndependency { get; set; }
        public GovernmentType GovernmentType { get; set; }

    }
    public class Person
    {
        public string Name { get; set; }
        public bool Sex { get; set; }
        public int LevelOfEducation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public decimal Income { get; set; }
        public int MarriageCounter { get; set; }
        public Person CurrentSpouse { get; set; }
        public DateTime ? DateOfMarriage { get; set; }
        public Character Character { get; set; }
    }
    public class Character
    {
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    #endregion
    class UserData
    {
        public string Name;
        public double[] PurchaseRecords;
        public string Country;
        public bool Gender;

        public UserData(string name,
            string country,
            bool gender,
            params double[] purchases)
        {
            Name = name;
            PurchaseRecords = purchases;
            Country = country;
            Gender = gender;
        }
    }
    class OutputManager
    {
        public void OutputToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void OutputToDebug(string message)
        {
            Debug.WriteLine(message);
        }

        public void OutputToFile(string message)
        {
            File.AppendAllText(@"C:\Users\Game\Desktop\output.txt", message);
        }
    }
    class TransformOperation
    {
        public int MultiplyByTwo(int x)
        {
            //Thread.Sleep(5000);
            return x * 2;
        }
        public int MultiplyByFour(int x)
        {
            //Thread.Sleep(5000);
            return x * 4;
        }

        public int MultiplyByTwo(ref int x)
        {
            x = x * 2;
            return x;
        }
        public int MultiplyByFour(ref int x)
        {
            x = x * 4;
            return x;
        }
    }
    class Program
    {
        delegate void OutputMessage(string message);

        delegate int Transform(int x);

        delegate int TransformReferenced(ref int x);
        static void Main(string[] args)
        {
            #region dich
            /*
           TransformOperation operations = new TransformOperation();

           var integers = Enumerable.Range(0, 100);
           Transform pointerToFunction = operations.MultiplyByTwo;

           foreach (var item in integers)
           {
               if (item % 2 == 0)
               {
                   pointerToFunction = operations.MultiplyByTwo;
               }              
               else
               {
                   pointerToFunction = operations.MultiplyByFour;
               }
               Console.WriteLine(pointerToFunction(item));
           }
           */
            /*
            OutputManager manager = new OutputManager();
            OutputMessage messageOutputter = new OutputMessage(manager.OutputToConsole);

            Dictionary<string, bool> logOutputSettings = new Dictionary<string, bool>();
            logOutputSettings["Debug"] = false;
            logOutputSettings["File"] = true;

            if (logOutputSettings["Debug"])
                messageOutputter += manager.OutputToDebug;
            if (logOutputSettings["File"])
                messageOutputter += manager.OutputToFile;

            messageOutputter -= manager.OutputToConsole;

            messageOutputter.Invoke("Error occured in line # 23");
            */
            // TransformOperation operations = new TransformOperation();
            /*
            Transform transformer = operations.MultiplyByTwo;
            transformer += operations.MultiplyByFour;
            */
            /*
            int x = 10;
            TransformReferenced transform = operations.MultiplyByTwo;
            transform += operations.MultiplyByFour;

            Console.WriteLine(transform(ref x));
            Console.WriteLine(x);
            */
            #endregion

            /*
                1. 
             
             */
            #region Countries
            List<Country> countries = new List<Country>()
            {
                new Country()
                {
                    Name = "Kazakhstan",
                    Capital = "Astana",
                    DayOfIndependency = new DateTime(1991, 12, 16),
                    GovernmentType = GovernmentType.President,
                    Latitude = 45,
                    Longitude = 43
                },
                new Country()
                {
                    Name = "Russia",
                    Capital = "Dushanbe",
                    DayOfIndependency = new DateTime(1991, 03, 21),
                    GovernmentType = GovernmentType.Monarch,
                    Latitude = 46,
                    Longitude = 47
                },
                new Country()
                {
                    Name = "USA",
                    Capital = "Washington",
                    DayOfIndependency = new DateTime(1776, 04, 07),
                    GovernmentType = GovernmentType.President,
                    Latitude = 45,
                    Longitude = 43
                },
                new Country()
                {
                    Name = "Iran",
                    Capital = "Tegeran",
                    DayOfIndependency = new DateTime(1990, 03, 21),
                    GovernmentType = GovernmentType.President,
                    Latitude = 48,
                    Longitude = 21
                },
                new Country()
                {
                    Name = "Japan",
                    Capital = "Tokyo",
                    DayOfIndependency = new DateTime(1600, 12, 16),
                    GovernmentType = GovernmentType.Monarch,
                    Latitude = 45,
                    Longitude = 21
                }
            };

            List<Person> persons = new List<Person>()
            {
                new Person()
                {
                    Name = "Kaisar",
                    DateOfBirth = new DateTime(1991, 11, 11),
                    DateOfMarriage = new DateTime(1992, 11, 11),
                    DateOfDeath = null,
                    Income = 1000,
                    LevelOfEducation = -1,
                    MarriageCounter = 100,
                    Character = new Character()
                    {
                        Height = 200,
                        Weight = 121
                    },
                    Sex = true
                },
                new Person()
                {
                    Name = "Dias",
                    DateOfBirth = new DateTime(1891, 11, 11),
                    DateOfMarriage = new DateTime(1992, 11, 11),
                    DateOfDeath = null,
                    Income = 1000,
                    LevelOfEducation = -2,
                    MarriageCounter = 200,
                    Character = new Character()
                    {
                        Height = 211,
                        Weight = 43
                    },
                    Sex = true
                }
            };

            Person woman = new Person()
            {
                Name = "Aliya",
                DateOfBirth = new DateTime(2000, 11, 11),
                DateOfMarriage = null,
                DateOfDeath = null,
                Income = 500000,
                LevelOfEducation = 2,
                MarriageCounter = 0,
                Character = new Character()
                {
                    Height = 170,
                    Weight = 70
                },
                Sex = false
            };


            #endregion

            TransformOperation op = new TransformOperation();
            Func<int, int> multByTwo = (int x) =>
            {
                return x * 2;
            };
            // Разница между датами.
            Func<List<Country>, string> RaznicaDenNez = (List<Country> countrs) =>
                {
                    DateTime min = countrs.Min(p => p.DayOfIndependency);
                    DateTime max = countrs.Max(p => p.DayOfIndependency);
                    string s = "Прошло: " + ((max - min).Days / 365).ToString() + "лет";
                    return s;
                };

            //Console.WriteLine(RaznicaDenNez(countries));

            Func<List<Person>, List<Person>> MarriageAgencyCHELKA = (List<Person> per) =>
            {
                List<Person> people = new List<Person>();
                for (int i = 0; i < per.Count(); i++)
                {
                    //if (DateTime.Now.Year - per[i].DateOfBirth.Year >= 35)
                    //{
                    //    people.Add(per[i]);
                    //}.
                    if (per[i].Character.Height -110 < per[i].Character.Weight)
                    {
                        people.Add(per[i]);
                    }
                }
                return people;
            };
            var result = MarriageAgencyCHELKA(persons);
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

            /*
            Func<Tuple<int, int>, string, UserData> someDelegate =
                (Tuple<int, int> tuples, string requestIp) =>
                {
                    char firstChar = requestIp[tuples.Item1];
                    char secondChar = requestIp[tuples.Item2];

                    return new UserData();
                }; 
            */

            multByTwo = op.MultiplyByFour;

            //someDelegate(new Tuple<int, int>(1, 3), "192.23.33.21");

            /*
            Action<IEnumerable<int>> Multiply = (IEnumerable<int> numbers) =>
            {
                foreach (var item in numbers)
                {
                    Console.WriteLine(item * 2);
                }
            };
            */

            UserData[] userRecords = new UserData[]
            {
                new UserData("Kaisar", "Ukraina", true, 100, 200, 200, 300, 100),
                new UserData("Dias", "Polska Republic", true, 100, 500, 200),
                new UserData("Ekaterina", "Rech Pospolitnaya", false, 1000, 200),
                new UserData("Daniyar", "Imperia Tzin", true, 100, 100, 200),
                new UserData("Zahar", "Azerot", true, 200, 200, 100)
            };

            Action<List<Country>> makeRevolution = (List<Country> c) =>
            {
                for(int i = 0; i < c.Count; i++)
                {
                    if (c[i].GovernmentType == GovernmentType.Monarch)
                        c[i].GovernmentType = GovernmentType.President;
                }
            };

            makeRevolution(countries);

            foreach (var item in countries)
            {
                Console.WriteLine(item.Name + " " + item.GovernmentType);
            }


            /*
            Func<UserData, double> sumPerUser = 
                (UserData data) => data.PurchaseRecords.Sum();

            Func<UserData[], double> sumPerAllUsers =
                (UserData[] data) => data
                .Select(p => p.PurchaseRecords
                .Sum())
                .Sum();

            Predicate<int> isPositive = (int x) => x % 2 == 0;
            */
            //Func<UserData[], int> UsersFmale =
            //    (UserData[] data) =>data.Select(p=> p.Gender==0)


            //    Func < UserData[],int> UsersMale =
            //      (UserData[] data) =>

            /*
            Predicate<UserData[]> isBalance =
              (UserData[] all) =>
              {
                  return all.Where(p => p.Gender == true).Count() ==
                    all.Where(p => p.Gender == false).Count();
              };

              




            foreach (var item in userRecords)
            {
                double sumForUser = sumPerUser(item);
            }

            var total = sumPerAllUsers(userRecords);

            Console.WriteLine(total);
            */

            
            Console.ReadLine();
        }
    }
}
