using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1
{
    public class Program
    {
        public static SqlConnection con;
        public static SqlCommand command;

        static Program()
        {
            var conf = ConfigurationManager.ConnectionStrings;

            if (conf != null)
            {
                string str = conf["DefaultConnection"].ConnectionString;
                con = new SqlConnection(str);

                command = new SqlCommand();
                command.Connection = con;
            }

        }


        public static List<Rates> GetClassRate(SqlDataReader reader)
        {
            List<Rates> rates = new List<Rates>();
            while (reader.Read())
            {
                Rates rate = new Rates();
                rate.title = reader["title"].ToString();
                rate.description = Convert.ToDouble(reader["description"].ToString().Replace(".", ","));
                rate.pubDate = Convert.ToDateTime(reader["pubDate"]);
                rate.quant = Convert.ToInt32(reader["quant"]);
                rate.change = Convert.ToDouble(reader["change"].ToString().Replace(".", ","));
                rates.Add(rate);
            }
            return rates;
        }

        public static List<Rates> GetRates()
        {
            List<Rates> rates = new List<Rates>();
            try
            {
                con.Open();
                command.CommandText = "SELECT * FROM Rates";
                rates = GetClassRate(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            finally
            {
                con.Close();
            }
            return rates;
        }
        public static List<Rates> GetRates(DateTime date)
        {
            List<Rates> rates = new List<Rates>();
            try
            {
                //2015-01-19
                string str = string.Format("SELECT * FROM Rates WHERE pubDate = '{0:yyyy-MM-dd}'", date);
                con.Open();
                command.CommandText = str;
                rates = GetClassRate(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            finally
            {
                con.Close();
            }
            return rates;
        }
        public static List<Rates> GetRates(DateTime date, string curr)
        {
            List<Rates> rates = new List<Rates>();
            try
            {
                //2015-01-19
                string str = string.Format("SELECT * FROM Rates WHERE pubDate = '{0:yyyy-MM-dd}' AND title = '{1}'", date, curr.ToUpper());
                con.Open();
                command.CommandText = str;
                rates = GetClassRate(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            finally
            {
                con.Close();
            }
            return rates;
        }

        public static List<Rates> GetTodayRates()
        {
            List<Rates> rates = new List<Rates>();
            try
            {
                //2015-01-19
                string str = string.Format("SELECT * FROM Rates WHERE pubDate = '{0:yyyy-MM-dd}'", DateTime.Now);
                con.Open();
                command.CommandText = str;
                rates = GetClassRate(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            finally
            {
                con.Close();
            }
            return rates;
        }

        public static List<Rates> GetXMLRate()
        {
            var Url = ConfigurationManager.AppSettings["RateURL"];
            List<Rates> rates = new List<Rates>();
            if (Url != null)
            {
                XDocument doc = XDocument.Load(Url);
                if (doc != null)
                {
                    var channel = doc.Element("rss").Element("channel");
                    foreach (var item in channel.Elements("item"))
                    {
                        Rates rate = new Rates();
                        rate.title = item.Element("title").Value;
                        rate.pubDate = Convert.ToDateTime(item.Element("pubDate").Value);
                        rate.description = Convert.ToDouble(item.Element("description").Value.Replace(".", ","));
                        rate.quant = Convert.ToInt32(item.Element("quant").Value);
                        rate.change = Convert.ToDouble(item.Element("change").Value.Replace(".", ","));
                        rates.Add(rate);
                    }
                }
            }
            else
            {
                //dosomething
            }
            return rates;
        }

        public static void LoadRates()
        {
            List<Rates> xmlRates = GetXMLRate();
            List<Rates> dbRates = GetTodayRates();
            if (!dbRates.Any())
            {
                foreach (Rates item in xmlRates)
                {
                    InsertIntoDB(item);
                }
            }
            else if (xmlRates.Any())
            {
                foreach (Rates item in xmlRates)
                {
                    Rates r = dbRates
                        .Where(w => w.title == item.title)
                        .OrderBy(o => o.pubDate)
                        .LastOrDefault();
                    if (r != null && r.description != item.description)
                    {
                        InsertIntoDB(item);
                    }
                }
            }
        }
        public static void InsertIntoDB(Rates rate)
        {
            try
            {
                con.Open();
                DateTime n = DateTime.Now;
                DateTime dd = new DateTime(rate.pubDate.Year, rate.pubDate.Month, rate.pubDate.Day, n.Hour, n.Minute, n.Second);


                command.CommandText = $"INSERT INTO [Rates] VALUES('{rate.title}', '{dd}', {rate.description.ToString().Replace(",", ".")}, {rate.quant.ToString().Replace(",", ".")}, {rate.change})";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            finally
            {
                con.Close();
            }
        }
    }

}
