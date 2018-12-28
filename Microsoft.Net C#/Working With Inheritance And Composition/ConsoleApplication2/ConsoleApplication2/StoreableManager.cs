using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    //public class User : StoreableObject
    //{
    //    public string Name { get; set; }
    //    public string Password { get; set; }

    //    protected override string ConvertToText()
    //    {
    //        return "...";
    //    }
    //    public override string ToString()
    //    {
    //        return ConvertToText();
    //    }
    //}

    public class Car
    {
        private StoreableObject storeable;
        public string GovernmentalNumber { get; set; }
        public decimal EngineVolume { get; set; }
        public override string ToString()
        {
            if(storeable != null)
            {
                return storeable.ConvertToText(this);
            }
            return "...";
            
        }

        public Car(StoreableObject obj = null)
        {
            storeable = obj;
        }
    }
    public /*abstract*/ class StoreableObject
    {
        public virtual string ConvertToText(object obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in obj.GetType().GetProperties())
            {
                sb.Append(item.Name + " : " + item.GetValue(obj, null));
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }

    public class StorableJsonObject : StoreableObject
    {
        public override string ConvertToText(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
