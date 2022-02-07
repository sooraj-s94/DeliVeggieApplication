#DeliVeggie Application
----------------------

The solution contains the following items
 
	1. DeliVeggie.WebApplication
	2. DeliVeggie.Gateway
	3. DeliVeggie.Services
	4. DeliVeggie.Common
	
	
================================================================================================================================ 
1. WebApplication - Angular application to display product list and product details.
    It mainly Contains 2 pages 
        1. Product list page
        2. Product details page

    Components:
    1. all-products - To display all the products.
    2. product-info - To display product details.

    services/web-api.service.ts
        It contains functions to call web api to fetch product all products and product details.		
================================================================================================================================ 

2. DeliVeggie.Gateway/DeliVeggie.API - Web api to get product details. 
    1. ProductController Contains 2 apis
        1.1)  GetProducts (https://localhost:5001/product) - To get all products.
        1.2) GetProductDetails (https://localhost:5001/product/{id}) - To get details of a product by Id.
    
    2. Services/ProductService.cs
        Service class to call product microservice to fetch product list and product details.
    3. Models\ProductModel.cs - To hold product data.
================================================================================================================================ 

3.  DeliVeggie.Services - Microservice to fetch product list and product details from database.
    1. DataAccessLayer/Models/ProductMdo - To hold product data  
    2. DomainLayer/ProductDomain/ProductLogic - Business layer to fetch product data from data access layer.
    3. DataAccessLayer/Models/Repository - Repository class to fetch product data from database.

================================================================================================================================ 

4. DeliVeggie.Common
		This project contains models which is used to pass product data from Gateway to Microservices
		   1. ProductDto.cs - product data model.
		   2. MQMessages\ProductRequest.cs - RabitMq communication model to pass input request
		   3. MQMessages\ProductResponse.cs - RabitMq communication model to pass output response.

================================================================================================================================ 

Note: Used RabitMq for communication between Getway and Microservice.

