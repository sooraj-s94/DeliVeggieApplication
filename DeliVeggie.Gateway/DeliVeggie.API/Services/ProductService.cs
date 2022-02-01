using System;
using System.Collections.Generic;
using System.Linq;
using DeliVeggie.API.Models;
using DeliVeggie.Common.Models;
using DeliVeggie.Common.Models.Messages;
using EasyNetQ;
using Microsoft.Extensions.Configuration;


namespace DeliVeggie.API.Services
{

/// <summary>
/// Summary description for Class1
/// </summary>
public class ProductService
{
    public IConfiguration Configuration;
    public ProductService(IConfiguration Configuration)
    {
        this.Configuration = Configuration;
    }

    public IEnumerable<ProductModel> GetProducts()
    {
       List<ProductModel> productModels = new List<ProductModel>();
        using (var bus = RabbitHutch.CreateBus(this.GetConnectionString()))
        {
            var request = new ProductsRequest();
            var response = bus.Rpc.Request<ProductsRequest, ProductsResponse>(request);
            productModels = response.Products.Select(x => MapProductResponseToModel(x)).ToList();
        }
        
        return productModels;
    }

    public ProductModel GetProduct(string ProductId)
    {
        ProductModel productModels = new ProductModel();
         using (var bus = RabbitHutch.CreateBus(this.GetConnectionString()))
        {
             var request = new ProductRequest(){ProductId = ProductId};
             var response = bus.Rpc.Request<ProductRequest, ProductResponse>(request);
             productModels = MapProductResponseToModel(response.Product);
         }
        
        return productModels;

    }

     private ProductModel MapProductResponseToModel(ProductDto productDto){
         return new ProductModel{ProductId = productDto.ProductId, Name = productDto.Name, Description = productDto.Description, Price = productDto.Price};
     }

     private string GetConnectionString(){
         return Configuration["RabbitMq:Host"];
     }
}
}