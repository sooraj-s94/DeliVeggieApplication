using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliVeggie.Services.Models;

namespace DeliVeggie.Services.DataAccessLayer.Repository
{
    public class ProductRepository
    {
        private IMongoDatabase database;
        protected static IMongoClient client; 
        private IMongoCollection<ProductMdo> collection;
        public IConfiguration Configuration { get; }
        public ProductRepository(IConfiguration configuration)
        {
            this.InitializeMongo(configuration);
        }

        public IEnumerable<ProductMdo> GetProducts(){

            var filter = Builders<ProductMdo>.Filter.Empty;
            var result =  this.collection.Find(filter);
            return result?.ToList();
        }

        public ProductMdo GetProduct(string productId){

            var filter = Builders<ProductMdo>.Filter.Where(p => p.ProductId.Equals(productId));
            var result = this.collection.Find(filter);

            return result?.FirstOrDefault();
        }

        private void InitializeMongo(IConfiguration configuration){
            string connectionString =  configuration["MongoSettings:ConnectionString"];
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            var database = client.GetDatabase(mongoUrl.DatabaseName);
            this.collection = database.GetCollection<ProductMdo>("Product");
        }
    }
}