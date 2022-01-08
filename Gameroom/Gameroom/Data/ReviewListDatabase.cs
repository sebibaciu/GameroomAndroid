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
            _database.CreateTableAsync<Package>().Wait();
            _database.CreateTableAsync<ListPackage>().Wait();
        }
        public Task<int> SaveProductAsync(Package product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Package product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Package>> GetProductsAsync()
        {
            return _database.Table<Package>().ToListAsync();
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
        public Task<int> SaveShopListAsync(ReviewList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(ReviewList slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveListProductAsync(ListPackage listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Package>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Package>(
            "select P.ID, P.Description from Package P"
            + " inner join ListPackage LP"
            + " on P.ID = LP.PackageID where LP.ReviewListID = ?",
            shoplistid);
        }
    }
}