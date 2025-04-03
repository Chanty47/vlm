using Microsoft.AspNetCore.Mvc;
using Serilog;


    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // Simulating in-memory storage for products
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Smartphone", Price = 799.99m }
        };

        // Get all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            Log.Information("Getting all products...");
            return Ok(Products);
        }

        // Get a product by id
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Log.Warning("Product with ID {Id} not found", id);
                return NotFound();
            }

            Log.Information("Getting product with ID {Id}", id);
            return Ok(product);
        }

        // Add a new product
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            Products.Add(product);
            Log.Information("Added a new product: {Name}", product.Name);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Update a product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                Log.Warning("Product with ID {Id} not found to update", id);
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            Log.Information("Updated product with ID {Id}", id);
            return NoContent();
        }

        // Delete a product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Log.Warning("Product with ID {Id} not found to delete", id);
                return NotFound();
            }

            Products.Remove(product);
            Log.Information("Deleted product with ID {Id}", id);
            return NoContent();
        }
    }

    // Product model
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

