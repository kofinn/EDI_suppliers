using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDI_suppliers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionEdiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ConnectionEdiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<SupplierMFG>> Get()
        {
            return await _dbContext.SupplierMFG.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody]SupplierMFG SupplierMFG)
        {
            if (ModelState.IsValid)
            {
                SupplierMFG.Id = Guid.NewGuid().ToString();
                _dbContext.Add(SupplierMFG);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<SupplierMFG> Details(string id)
        {
            return await _dbContext.SupplierMFG.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(string id, [FromBody]SupplierMFG SupplierMFG)
        {
            if (id != SupplierMFG.Id)
            {
                return false;
            }

            _dbContext.Entry(SupplierMFG).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(string id)
        {
            var SupplierMFG = await _dbContext.SupplierMFG.FindAsync(id);
            if (SupplierMFG == null)
            {
                return false;
            }

            _dbContext.SupplierMFG.Remove(SupplierMFG);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}