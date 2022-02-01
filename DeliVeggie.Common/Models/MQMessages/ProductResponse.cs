using System.Collections.Generic;

namespace DeliVeggie.Common.Models.Messages
{
    public class ProductResponse
    {
        public ProductDto Product { get; set; }
    }
    
    public class ProductsResponse {
         public List<ProductDto> Products { get; set; }
    }
}