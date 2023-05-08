using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex_dominicana.Context;
using solvex_dominicana.Models;
using static solvex_dominicana.Interfaces.BrandInterface;

namespace solvex_dominicana.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public BrandController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerator<BrandModel>>> CreateProduct([FromBody] BrandRequestPayload payload)
        {
            if (payload.name == null) return Problem("[name] property doesn't exists", "", 400);

            if (_dbContext.Brand == null) return Problem("Something went wrong", "", 500);

            try
            {
                var found = await _dbContext.Brand.Where(p => p.Name == payload.name).FirstOrDefaultAsync();
                if (found != null) Problem("This brand does exitst", "", 400);

                _dbContext.Brand.Add(new BrandModel { Name = payload.name });
                await _dbContext.SaveChangesAsync();

                return StatusCode(201, new { ok = true });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerator<BrandModel>>> GetAll()
        {
            if (_dbContext.Brand == null) return Problem("Something went wrong", "", 500);

            try
            {
                var list = await _dbContext.Brand.OrderByDescending(x => x.Id).ToListAsync();
                if (list == null) return StatusCode(200, new List<BrandModel> { });

                return StatusCode(200, list);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<IEnumerator<BrandModel>>> EditOneProduct([FromRoute] int id, [FromBody] BrandRequestPayload payload)
        {
            if (payload.name == null) return Problem("[name] property doesn't exists", "", 400);

            if (_dbContext.Brand == null) return Problem("Something went wrong", "", 500);

            try
            {
                var found = await _dbContext.Brand.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (found == null) return Problem("Content not found", "", 404);

                found.Name = payload.name;
                found.UpdatedAt = DateTime.Now;

                _dbContext.Brand.Update(found);
                await _dbContext.SaveChangesAsync();

                return StatusCode(200, new { update = true });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerator<BrandModel>>> DeleteOneProduct([FromRoute] int id)
        {
            if (_dbContext.Brand == null) return Problem("Something went wrong", "", 500);

            try
            {
                var found = await _dbContext.Brand.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (found == null) return Problem("Content not found", "", 404);


                _dbContext.Brand.Remove(found);
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
