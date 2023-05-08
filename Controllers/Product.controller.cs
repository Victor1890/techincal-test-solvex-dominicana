using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex_dominicana.Context;
using solvex_dominicana.Models;
using static solvex_dominicana.Interfaces.ProductInterface;

namespace solvex_dominicana.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public ProductController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerator<ProductModel>>> CreateProduct([FromBody] ProductRequestPayload payload)
        {
            if(payload.name == null) return Problem("[name] property doesn't exists", "", 400);

            if (payload.description == string.Empty || payload.description == "" || payload.description == null) payload.description = "Not description";

            if (_dbContext.Product == null) return Problem("Something went wrong", "", 500);

            try
            {
                var product = await _dbContext.Product.Where(p =>  p.Name == payload.name).FirstOrDefaultAsync();
                if(product != null) Problem("This product does exitst", "", 400);

                _dbContext.Product.Add(new ProductModel { Name = payload.name, Description = payload.description });
                await _dbContext.SaveChangesAsync();

                return StatusCode(201, new { ok = true });
            } catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerator<ProductModel>>> GetAll()
        {
            if (_dbContext.Product == null) return Problem("Something went wrong", "", 500);

            try
            {
                var list = await _dbContext.Product.OrderByDescending(x => x.Id).ToListAsync();
                if (list == null) return StatusCode(200, new List<ProductModel> { });

                return StatusCode(200, list);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<IEnumerator<ProductModel>>> EditOneProduct([FromRoute] int id, [FromBody] ProductRequestPayload payload)
        {
            if (payload.name == null) return Problem("[name] property doesn't exists", "", 400);
            if (payload.description == string.Empty || payload.description == "" || payload.description == null) payload.description = "Not description";
            
            if (_dbContext.Product == null) return Problem("Something went wrong", "", 500);

            try
            {
                var productFound = await _dbContext.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (productFound == null) return Problem("Content not found", "", 404);

                productFound.Name = payload.name;
                productFound.Description = payload.description;
                productFound.UpdatedAt = DateTime.Now;

                _dbContext.Product.Update(productFound);
                await _dbContext.SaveChangesAsync();

                return StatusCode(200, new { update = true });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpPost("/api/products/{productId}/brands/{brandId}")]
        public async Task<ActionResult<IEnumerator<BrandProductModel>>> AddProductToBrand([FromRoute] int productId, [FromRoute] int brandId, [FromBody] ProductToBrandRequestPayload payload)
        {

            if (payload.price <= 0) return Problem("[price] property is madatory", "", 400);
            if (_dbContext.BrandProductRelaction == null) return Problem("Something went wrong", "", 500);

            try
            {
                var found = await _dbContext.BrandProductRelaction.Where(x => x.ProductId == productId && x.BrandId == brandId).FirstOrDefaultAsync();
                if (found != null) return Problem("Conflict", "", 500);

                var productFound = await _dbContext.Product.Where(x => x.Id == productId).FirstOrDefaultAsync();
                if (productFound == null) return Problem("Content not found", "", 404);

                var brandFound = await _dbContext.Brand.Where(x => x.Id == brandId).FirstOrDefaultAsync();
                if (brandFound == null) return Problem("Content not found", "", 404);

                productFound.Price = payload.price;
                productFound.UpdatedAt = DateTime.Now;
                _dbContext.Product.Update(productFound);

                _dbContext.BrandProductRelaction.Add(new BrandProductModel { BrandId = brandId, ProductId = productId });
                await _dbContext.SaveChangesAsync();

                return StatusCode(201, new { ok = true });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerator<ProductModel>>> DeleteOneProduct([FromRoute] int id)
        {
            if (_dbContext.Product == null) return Problem("Something went wrong", "", 500);

            try
            {
                var productFound = await _dbContext.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (productFound == null) return Problem("Content not found", "", 404);

                
                _dbContext.Product.Remove(productFound);
                await _dbContext.SaveChangesAsync();

                return StatusCode(200, new { delete = true });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }
    }
}
