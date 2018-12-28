using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class Url
    {
        public string FromUserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Body { get; set; } 
    }

    public interface IUrlShortener
    {
        string Short(string url);
    }

    // https://admin.mail.yandex.kz/?uid=1130000025304967&login=raimbayev#inbox

    // https://yandex.kzawdawd
    // istep21312313
    public class UrlShortenerWithDomainName : IUrlShortener
    {
        //ftps://google.com/ftp/chrome
        // s = ftps://google.com/ftp/chrome
        // t = '/'
        // n = 3

        private int GetNthIndex(string s, char t)
        {
            int n = 2;
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private string GetProtocol(string url)
        {
            string value;
            int n = GetNthIndex(url, '/');
            value = url.Substring(0, n + 1);
            return value;
        }
        public string Short(string url)
        {
            string protocol = GetProtocol(url);

            StringBuilder sb = new StringBuilder();
            sb.Append(protocol);

            return sb.ToString();
        }
    }
    public class UrlShortener : IUrlShortener
    {
        private Random _random;
        private int _length;
        private Tuple<int, int> _asciiRange;
        public string Short(string input)
        {
            string output = string.Empty;
            for(int i = 1; i <= _length; i++)
            {
                output += (char)_random.Next(_asciiRange.Item1, _asciiRange.Item2);
            }
            return output;
        }

        public UrlShortener()
        {
            _random = new Random();
            _length = 6;
            _asciiRange = new Tuple<int, int>(65, 91);
        }
    }
    public class UrlManagement
    {
        private Dictionary<string, Url> _storage;
        private IUrlShortener _shortener;

        public string Short(string url)
        {
            var key = _shortener.Short(url);
            _storage.Add(key, new Url() { Body = url });
            return key;
        }

        public string Source(string key)
        {
            if (_storage.ContainsKey(key))
            {
                return _storage[key].Body;
            }
            return "No data found";
        }
        public UrlManagement(IUrlShortener shortener)
        {
            _shortener = shortener;
            _storage = new Dictionary<string, Url>();
        }
    }
}
