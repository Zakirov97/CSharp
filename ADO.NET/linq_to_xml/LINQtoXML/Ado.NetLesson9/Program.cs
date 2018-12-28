using Ado.NetLesson9.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ado.NetLesson9
{
    class Program
    {
        static ModelEntity db = new ModelEntity();
        static void Main(string[] args)
        {
            //Exmpl3AB();
            //Exmpl3C();
            //Exmpl3D();
            //Exmpl3E();
            //Exmpl3F();
            //Exmpl3G();

            //Exmpl4A();
            //Exmpl4B();
            //Exmpl4С();
        }
        //LINQ To XML
        static void Exmpl3AB()
        {
            foreach (Area area in db.Area.Where(w => w.PavilionId == 1))
            {
                XElement areaElement = new XElement("Area", new XAttribute("AreaId", area.AreaId), new XElement("Name", area.Name));
                areaElement.Save(area.PavilionId + "/" + area.AreaId + ".xml");
            }
        }

        static void Exmpl3C()
        {
            XElement root = new XElement("root");

            foreach (Area area in db.Area.Where(w => w.ParentId != 0))
            {
                XElement areaElement = new XElement("Area", new XElement("AreaId", area.AreaId), new XElement("Name", area.Name), new XElement("FullName", area.FullName), new XElement("Name", area.IP));
                root.Add(areaElement);
            }
            root.Save("Area3c.xml");
            Console.WriteLine(root.ToString());
        }

        static void Exmpl3D()
        {
            XElement elements = new XElement("item");

            foreach (Timer item in db.Timer)
            {
                Area area = db.Area.ToList().Find(w => w.AreaId == item.AreaId);
                XElement element = null;
                if (area != null)
                {
                    element = new XElement("Timer", new XElement("UserId", item.UserId), new XElement("AreaName", area.FullName), new XElement("DateStart", item.DateStart));
                }
                else
                {
                    element = new XElement("Timer", new XElement("UserId", item.UserId), new XElement("AreaName", "NONAME"), new XElement("DateStart", item.DateStart));
                }
                elements.Add(element);
            }
            Console.WriteLine(elements.ToString());
        }

        static void Exmpl3E()
        {
            XElement elements = new XElement("item");

            foreach (Timer item in db.Timer.Where(w => w.DateFinish == null))
            {
                Area area = db.Area.ToList().Find(w => w.AreaId == item.AreaId);
                XElement element = null;
                if (item != null)
                {
                    element = new XElement("Timer", new XElement("UserId", item.UserId), new XElement("AreaName", area.FullName), new XElement("DateStart", item.DateStart));
                }
                else
                {
                    element = new XElement("Timer", new XElement("UserId", item.UserId), new XElement("AreaName", "NONAME"), new XElement("DateStart", item.DateStart));
                }
                elements.Add(element);
            }
            Console.WriteLine(elements.ToString());
        }

        static void Exmpl3F()
        {
            XElement elements = new XElement("item");

            foreach (Timer item in db.Timer.Where(w => w.DateFinish != null))
            {
                Area area = db.Area.ToList().Find(w => w.AreaId == item.AreaId);
                XElement element = null;
                if (area != null)
                    element = new XElement("Timer",
                        new XElement("UserId", item.UserId),
                        new XElement("AreaName", area.FullName),
                        new XElement("DateStart", item.DateStart),
                        new XElement("AreaId", item.AreaId),
                        new XElement("DocumentId", item.DocumentId),
                        new XElement("DateFinish", item.DateFinish));
                else
                    element = new XElement("Timer",
                        new XElement("UserId", item.UserId),
                        new XElement("AreaName", "NONAME"),
                        new XElement("DateStart", item.DateStart),
                        new XElement("AreaId", item.AreaId),
                        new XElement("DocumentId", item.DocumentId),
                        new XElement("DateFinish", item.DateFinish)
                        );
                elements.Add(element);
            }
            elements.Save("Exmpl3F");
            Console.WriteLine(elements.ToString());
        }

        static void Exmpl3G()
        {
            XDocument doc = new XDocument(new XElement("root"));
            foreach (Area area in db.Area)
            {

                XNamespace ns = "http://logbook.itstep.org/";
                doc.Root.SetAttributeValue(XNamespace.Xmlns + "area", ns.NamespaceName);
                XElement element = new XElement("Area", new XAttribute("AreaId", area.AreaId), new XElement("Name", area.Name));
                doc.Root.Add(element);
                doc.Save(area.AreaId + ".xml");

            }
            Console.WriteLine(doc.ToString());
        }

        static void Exmpl4A()
        {
            XElement elements = XElement.Load("Exmpl3F");

            foreach (XElement item in elements.Elements())
            {
                item.Element("AreaName").Remove();
                item.Element("DateStart").Remove();
                item.Element("DateFinish").Remove();
            }
            Console.WriteLine(elements.ToString());
        }

        static void Exmpl4B()
        {
            XElement elements = XElement.Load("Exmpl3F");
            foreach (XElement items in elements.Elements())
            {
                foreach (XElement item in items.Elements())
                {
                    string str = DateTime.Now.ToString();
                    if (item.Name == "DateFinish")
                    {
                        item.Value = str;
                    }
                }
            }
            elements.Save("Exmpl3F");
            Console.WriteLine(elements.ToString());
        }

        static void Exmpl4С()
        {
            XElement elements = XElement.Load("Area3c.xml");
            Console.WriteLine(elements.ToString());
        }
    }
}
