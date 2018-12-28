using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpWeekFourCompleted.Models;
namespace CSharpWeekFourCompleted
{
    #region Storage Implementation

    public static class StorageManager
    {
        private const string _pathToDb = @"C:\Database\WeekFourDb.db";
        public static void DropDatabase()
        {
            if (File.Exists(_pathToDb))
            {
                File.Delete(_pathToDb);
            }            
        }
    }
    public class LiteStorage<T> where T : IDatabaseModel
    {
        private const string _pathToDb = @"C:\Database\WeekFourDb.db";
        private string GetCollectionName => typeof(T).Name;
        public IEnumerable<T> ReadAll()
        {
            using (var db = new LiteDatabase(_pathToDb))
            {
                return db.GetCollection<T>(GetCollectionName).FindAll();
            }
        }
        public IEnumerable<T> Create(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return Create(item);
            }
        }
        public T Create(T item)
        {
            using (var db = new LiteDatabase(_pathToDb))
            {
                try
                {
                    db.GetCollection<T>(GetCollectionName).Insert(item);
                    return item;
                }
                catch (DatabaseOperationException ex)
                {
                    throw;
                }
            }
        }
    }
    #endregion
}
