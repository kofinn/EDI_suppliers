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
    public class PartnerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PartnerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Partner>> Get()
        {
            return await _dbContext.Partner.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody]Partner partner)
        {
            if (ModelState.IsValid)
            {
                partner.Id = Guid.NewGuid().ToString();
                _dbContext.Add(partner);
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
        public async Task<Partner> Details(string id)
        {
            return await _dbContext.Partner.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(string id, [FromBody]Partner partner)
        {
            if (id != partner.Id)
            {
                return false;
            }

            _dbContext.Entry(partner).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(string id)
        {
            var ConnectionEdi = await _dbContext.Partner.FindAsync(id);
            if (ConnectionEdi == null)
            {
                return false;
            }

            _dbContext.Partner.Remove(ConnectionEdi);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}