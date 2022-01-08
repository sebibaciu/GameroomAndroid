using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gameroom.Models;

namespace Gameroom.Data
{
    public class ReviewListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ReviewListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ReviewList>().Wait();
        }
        public Task<List<ReviewList>> GetShopListsAsync()
        {
            return _database.Table<ReviewList>().ToListAsync();
        }
        public Task<ReviewList> GetShopListAsync(int id)
        {
            return _database.Table<ReviewList>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ReviewList rlist)
        {
            if (rlist.ID != 0)
            {
                return _database.UpdateAsync(rlist);
            }
            else
            {
                return _database.InsertAsync(rlist);
            }
        }
        public Task<int> DeleteShopListAsync(ReviewList rlist)
        {
            return _database.DeleteAsync(rlist);
        }
    }
}
