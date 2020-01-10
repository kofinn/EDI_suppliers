using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EDI_suppliers.Data;

namespace EDI_suppliers.Controllers
{
        [Route("api/[controller]")]
        //[Authorize]
        [ApiController]
        public class SupplierMFGController : ControllerBase
        {
            private readonly ApplicationDbContext _dbContext;

            public SupplierMFGController(ApplicationDbContext dbContext)
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
            public async Task<bool> Create([FromBody]SupplierMFG suppliermfg)
            {
                if (ModelState.IsValid)
                {
                    suppliermfg.Id = Guid.NewGuid().ToString();
                    _dbContext.Add(suppliermfg);
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
            public async Task<bool> Edit(string id, [FromBody]SupplierMFG suppliermfg)
            {
                if (id != suppliermfg.Id)
                {
                    return false;
                }

                _dbContext.Entry(suppliermfg).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            [HttpDelete]
            [Route("Delete/{id}")]
            public async Task<bool> DeleteConfirmed(string id)
            {
                var suppliermfg = await _dbContext.SupplierMFG.FindAsync(id);
                if (suppliermfg == null)
                {
                    return false;
                }

                _dbContext.SupplierMFG.Remove(suppliermfg);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

    }