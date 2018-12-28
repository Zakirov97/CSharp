using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class User : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            if(obj is User)
            {
                User userToCompare = obj as User;
                if(this.Id == userToCompare.Id && this.Name == userToCompare.Name)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                throw new Exception("...");
            }
        }
    }
    class Program
    {
        // ArrayList
        // List
        // Stack
        // Queue
        // LinkedList
        // Hashtable
        // Dictionary
        // SortedSet
        // CircularQueue

        static void Main(string[] args)
        {
            #region ArrayList & List
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Kaisar");
            arrayList.Add(10);
            arrayList.Add(new DateTime(1999, 10, 10));
            arrayList.Add(new Uri("http://google.com"));
            arrayList.Add(true);

            List<string> listOfStrings = new List<string>();
            listOfStrings.Add("Kaisar");
            listOfStrings.Add("Kaisar");
            listOfStrings.Add("Kaisar");
            listOfStrings.Add(Guid.NewGuid().ToString());

            /*
            object objToDelete = null;
            foreach (var item in arrayList)
            {
                if(item is DateTime)
                    objToDelete = item;
            }
            arrayList.Remove(objToDelete);
            Console.WriteLine(arrayList.Count);
            */

            List<string> foundElement = listOfStrings.FindAll(p => p
                    .Length >= 4 && p
                    .Contains("Kai"));

            foreach (var item in foundElement)
                listOfStrings.Remove(item);

            bool result = listOfStrings
                .Exists(p => p
                    .Length >= 4 && p
                    .Contains("Kai"));

            #endregion

            #region Hashtable and Dictionary
            Hashtable hashtable = new Hashtable();
            hashtable.Add("nomiko", 23);
            hashtable.Add("okazaki", 122);
            hashtable.Add(155, new Uri("http://google.com"));
            hashtable.Add(122.2, false);

            Dictionary<string, int> students = new Dictionary<string, int>();
            students.Add("Kaisar", 20);
            students.Add("Zahar", 35);
            students.Add("Alexander", 54);
            #endregion

            #region UrlShortener

            //IUrlShortener urlShortener = new UrlShortener();
            //UrlManagement urlManagement = new UrlManagement(urlShortener);

            //string urlToShort = "https://www.google.kz/search?q=ascii+range&source=lnms&tbm=isch&sa=X&ved=0ahUKEwjW0L3K26LcAhVIjywKHRR9DE0Q_AUICigB&biw=1536&bih=779#imgrc=TjgwqAuaYjYWPM:";

            //string key = urlManagement.Short(urlToShort);
            //Console.WriteLine(key);

            //string getKey = Console.ReadLine();
            //Console.WriteLine(urlManagement.Source(getKey));
            //Console.ReadLine();
            #endregion

            #region Stack and Queue
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(-8);
            stack.Push(22);
            stack.Push(300);

            //Console.WriteLine(stack.Peek());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());

            // FIFO - First Input First Output
            // LIFO - Last Input First Output

            //Console.WriteLine(stack.ElementAt(2));

            //Queue<string> patients = new Queue<string>();
            //patients.Enqueue("kaisar");
            //patients.Enqueue("aliden");
            //patients.Enqueue("omarali");

            //Console.WriteLine(patients.Dequeue());

            //SortedSet<int> integers = new SortedSet<int>();
            //integers.Add(8);
            //integers.Add(20);
            //integers.Add(-22);
            //integers.Add(20);
            //integers.Add(5);
            //integers.Add(8);

            //foreach (var item in integers)
            //{
            //    Console.WriteLine(item);
            //}

            //SortedSet<User> users = new SortedSet<User>();
            //users.Add(new User() { Id = 10, Name = "Iskander" });
            //users.Add(new User() { Id = 11, Name = "Kaisar" });
            //users.Add(new User() { Id = 11, Name = "Kaisar" });

            //foreach (var item in users)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name);
            //}

            //                  20 30 10 50 100
            LinkedList<int> integers = new LinkedList<int>();
            var head = integers.AddFirst(10);
            integers.AddBefore(head, 20);
            integers.AddBefore(head, 30);
            var pointer = integers.AddAfter(head, 50);
            integers.AddAfter(pointer, 100);

            foreach (var item in integers)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
            #endregion

        }
    }
}
