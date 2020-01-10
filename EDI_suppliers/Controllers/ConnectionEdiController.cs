using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EDI_suppliers.Data;

namespace EDI_suppliers.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
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
        public async Task<List<ConnectionEdi>> Get()
        {
            return await _dbContext.ConnectionEdi.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody]ConnectionEdi ConnectionEdi)
        {
            if (ModelState.IsValid)
            {
                ConnectionEdi.Id = Guid.NewGuid().ToString();
                _dbContext.Add(ConnectionEdi);
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
        public async Task<ConnectionEdi> Details(string id)
        {
            return await _dbContext.ConnectionEdi.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(string id, [FromBody]ConnectionEdi ConnectionEdi)
        {
            if (id != ConnectionEdi.Id)
            {
                return false;
            }

            _dbContext.Entry(ConnectionEdi).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(string id)
        {
            var ConnectionEdi = await _dbContext.ConnectionEdi.FindAsync(id);
            if (ConnectionEdi == null)
            {
                return false;
            }

            _dbContext.ConnectionEdi.Remove(ConnectionEdi);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}