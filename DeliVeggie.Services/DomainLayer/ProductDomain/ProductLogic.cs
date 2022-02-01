using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyNetQ;
using DeliVeggie.Common.Models.Messages;
using System.Linq;
using DeliVeggie.Common.Models;
using DeliVeggie.Services.DataAccessLayer.Repository;

namespace DeliVeggie.Services.DomainLayer
{
    public class ProductLogic
    {
        private ProductRepository productRepository;
        private IBus messageBus;
        public ProductLogic(IConfiguration Configuration)
        {
            this.productRepository = new ProductRepository(Configuration);
            messageBus = RabbitHutch.CreateBus(GetConnectionString(Configuration));

            messageBus.Rpc.Respond<ProductsRequest, ProductsResponse>(request => new ProductsResponse
            {
                Products = this.GetProducts()
            });

            messageBus.Rpc.Respond<ProductRequest, ProductResponse>(request => new ProductResponse
            {
                Product = this.GetProduct(request.ProductId)
            });
        }

        public List<ProductDto> GetProducts()
        {
            var result = this.productRepository.GetProducts();
            return result.Select(x => new ProductDto { ProductId = x.ProductId, Name = x.Name, Description = x.Description, Price = x.Price }).ToList();
        }

        public ProductDto GetProduct(string productId)
        {
            if(string.IsNullOrWhiteSpace(productId)){
                return null;
            }
            var result = this.productRepository.GetProduct(productId);
            return new ProductDto { ProductId = result.ProductId, Name = result.Name, Description = result.Description, Price = result.Price};
        }

        private string GetConnectionString(IConfiguration Configuration){
            return Configuration["RabbitMq:Host"];
        }
    }
}