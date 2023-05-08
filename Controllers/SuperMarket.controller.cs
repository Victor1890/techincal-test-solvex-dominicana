using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex_dominicana.Context;
using solvex_dominicana.Models;
using static solvex_dominicana.Interfaces.MarketInterface;

namespace solvex_dominicana.Controllers
{
    [Route("api/super-markets")]
    [ApiController]
    public class SuperMarketController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public SuperMarketController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerator<SuperMarketModel>>> CreateProduct([FromBody] MarketRequestPayload payload)
        {
            if (payload.name == null) return Problem("[name] property doesn't exists", "", 400);

            if (_dbContext.SuperMarket == null) return Problem("Something went wrong", "", 500);

            try
            {
                var found = await _dbContext.SuperMarket.Where(p => p.Name == payload.name).FirstOrDefaultAsync();
                if (found != null) Problem("This super-market does exitst", "", 400);

                _dbContext.SuperMarket.Add(new SuperMarketModel { Name = payload.name });
                await _dbContext.SaveChangesAsync();

                return StatusCode(201, new { ok = true });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerator<SuperMarketModel>>> GetAll()
        {
            if (_dbContext.SuperMarket == null) return Problem("Something went wrong", "", 500);

            try
            {
                var list = await _dbContext.SuperMarket.OrderByDescending(x => x.Id).ToListAsync();
                if (list == null) return StatusCode(200, new List<SuperMarketModel> { });

                return StatusCode(200, list);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<IEnumerator<SuperMarketModel>>> EditOneProduct([FromRoute] int id, [FromBody] MarketRequestPayload payload)
        {
            if (payload.name == null) return Problem("[name] property doesn't exists", "", 400);

            if (_dbContext.SuperMarket == null) return Problem("Something went wrong", "", 500);

            try
            {
                var found = await _dbContext.SuperMarket.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (found == null) return Problem("Content not found", "", 404);

                found.Name = payload.name;
                found.UpdatedAt = DateTime.Now;

                _dbContext.SuperMarket.Update(found);
                await _dbContext.SaveChangesAsync();

                return StatusCode(200, new { update = true });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace, 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerator<SuperMarketModel>>> DeleteOneProduct([FromRoute] int id)
        {
            if (_dbContext.Product == null) return Problem("Something went wrong", "", 500);

            try
            {
                var found = await _dbContext.SuperMarket.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (found == null) return Problem("Content not found", "", 404);


                _dbContext.SuperMarket.Remove(found);
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
