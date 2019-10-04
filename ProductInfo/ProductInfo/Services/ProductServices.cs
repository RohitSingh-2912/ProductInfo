using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using ProductInfo.Models;
using ProductInfo.Controllers;

namespace ProductInfo.Services
{
    public class ProductServices
    {
        private readonly IMongoCollection<Products> _products;

        public ProductServices(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Products>(settings.ProductCollectionName);
        }



        public List<Products> Get()
        {
            return _products.Find(s => true).ToList();
        }

        public Products GetById(int id)
        {
            return _products.Find<Products>(s => s.id == id).First();
        }

        public Products GetByName(string name)
        {
            return _products.Find<Products>(s => s.Name == name).First();
        }


        public Products Create(Products product)
        {
            product.iid = ObjectId.GenerateNewId().ToString();
            _products.InsertOne(product);
            return product;
        }

        public void Update(Products product)
        {
            _products.ReplaceOne<Products>(s => s.id == product.id, product);
        }

        public DeleteResult Remove(int id)
        {

           return  _products.DeleteOne(s => s.id == id);
            

        }

    }
}
