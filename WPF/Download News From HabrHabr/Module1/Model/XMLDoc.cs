using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Xml
{
    [Serializable]
    public class Item
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public Item(string Title, string Description, string Link, string PubDate)
        {
            this.Title = Title;
            this.Link = Link;
            this.Description = Description;
            this.PubDate = Convert.ToDateTime(PubDate);
        }
        public Item()
        {

        }
    }
    public class XMLDoc
    {
        public static Tuple<List<Item>, string, string> GetInfo()
        {
            XmlDocument doc = new XmlDocument();
            List<Item> Items = new List<Item>();

            string s = "https://habrahabr.ru/rss/interesting/";
            string mngEditor = "", generator = "";
            doc.Load(s);

            foreach (XmlNode channel in doc.DocumentElement.ChildNodes)
            {

                foreach (XmlNode item in channel.ChildNodes)
                {
                    if (item.Name == "managingEditor")
                    {
                        mngEditor = item.InnerText;
                    }
                    if (item.Name == "generator")
                    {
                        generator = item.InnerText;
                    }
                    if (item.Name == "item")
                    {
                        XmlNode title = item.SelectSingleNode("title");
                        XmlNode description = item.SelectSingleNode("description");
                        XmlNode link = item.SelectSingleNode("link");
                        XmlNode pubdate = item.SelectSingleNode("pubDate");
                        Items.Add(new Item(title.InnerText, description.InnerText, link.InnerText, pubdate.InnerText));
                        Console.WriteLine(title.InnerText + "\n" + description.InnerText + "\n" + link.InnerText + "\n\n\n");
                    }
                }
            }
            Tuple<List<Item>, string, string> tuple = new Tuple<List<Item>, string, string>(Items, mngEditor, generator);
            return tuple;
        }
        public static void Serialise(string path)
        {
            XmlDocument doc = new XmlDocument();
            List<Item> Items = new List<Item>();

            string s = "https://habrahabr.ru/rss/interesting/";
            string mngEditor, generator;
            doc.Load(s);

            foreach (XmlNode channel in doc.DocumentElement.ChildNodes)
            {

                foreach (XmlNode item in channel.ChildNodes)
                {
                    if (item.Name == "managingEditor")
                    {
                        mngEditor = item.InnerText;
                    }
                    if (item.Name == "generator")
                    {
                        generator = item.InnerText;
                    }
                    if (item.Name == "item")
                    {
                        XmlNode title = item.SelectSingleNode("title");
                        XmlNode description = item.SelectSingleNode("description");
                        XmlNode link = item.SelectSingleNode("link");
                        XmlNode pubdate = item.SelectSingleNode("pubDate");
                        Items.Add(new Item(title.InnerText, description.InnerText, link.InnerText, pubdate.InnerText));
                        Console.WriteLine(title.InnerText + "\n" + description.InnerText + "\n" + link.InnerText + "\n\n\n");
                    }
                }
            }
            MyClass.SerializeObject(Items, "xmlU");
            XmlDocument newDoc = new XmlDocument();
            XmlElement root = newDoc.CreateElement("newses");
            foreach (Item item in Items)
            {
                XmlElement news = newDoc.CreateElement("news");
                news.InnerText = item.Title;
                root.AppendChild(news);
            }
            newDoc.AppendChild(root);

            newDoc.Save(path);
        }
    }
    public static class MyClass
    {
        public static void SerializeObject(this List<Item> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Item>));
            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, list);
            }
        }
    }
}
