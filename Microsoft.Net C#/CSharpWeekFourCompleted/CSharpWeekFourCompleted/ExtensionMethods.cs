using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWeekFourCompleted
{
    public static class ExtensionMethods
    {
        public static string ToSha1Hash(this string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        // To Complete...
        public static string Serialize(this IApplicationSerializable obj, SerializationType type)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
