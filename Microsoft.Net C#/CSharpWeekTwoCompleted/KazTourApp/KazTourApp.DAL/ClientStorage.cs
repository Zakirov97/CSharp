using KazTourApp.Shared.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.DAL
{
    public class ClientStorage
    {
        public void AddClient(ClientRecord record)
        {
            using (var db = new LiteDatabase(@"C:\Users\РаимбаевИ\Databases\LiteDb.db"))
            {
                var clients = db.GetCollection<ClientRecord>("clients");
                clients.Insert(record);
            }
        }

        public List<ClientRecord> ReadAll()
        {
            using (var db = new LiteDatabase(@"C:\Users\РаимбаевИ\Databases\LiteDb.db"))
            {
                var clients = db.GetCollection<ClientRecord>("clients");
                return clients.FindAll().ToList();
            }
        }
    }
}
