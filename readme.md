# Technical test - Solvex Dominicana
This is a sample API built with ASP.NET for managing products, brands, and supermarkets. The API provides endpoints for CRUD operations on these entities, as well as relationships between them.

## Technologies Used
The following technologies were used in building this API:

* ASP.NET Core 3.1
* Entity Framework Core 3.1
* Microsoft SQL Server Express LocalDB


## Getting Started
To get started with this API, follow these steps:

1. Clone the repository to your local machine
2. Open the solution file in Visual Studio
3. Build the solution
4. Run the application

Once the application is running, you can use an HTTP client such as Postman to interact with the API.

## Endpoints
The API provides the following endpoints for managing products, brands, and supermarkets:

### Products
* GET /api/products - returns a list of all products
* POST /api/products - creates a new product
* PUT /api/products/:id - updates an existing product
* DELETE /api/products/:id - deletes a product
* POST /api/products/:productId/brands/:brandId - associates a brand with a product

### Brands
* GET /api/brands - returns a list of all brands
* POST /api/brands - creates a new brand
* PUT /api/brands/:id - updates an existing brand
* DELETE /api/brands/:id - deletes a brand

### Supermarkets
* GET /api/supermarkets - returns a list of all supermarkets
* POST /api/supermarkets - creates a new supermarket
* PUT /api/supermarkets/:id - updates an existing supermarket
* DELETE /api/supermarkets/:id - deletes a supermarket
