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
        public class SupplierController : ControllerBase
        {
            private readonly ApplicationDbContext _dbContext;

            public SupplierController(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            [HttpGet]
            [Route("Get")]
            public async Task<List<Supplier>> Get()
            {
                return await _dbContext.Supplier.ToListAsync();
            }

            [HttpPost]
            [Route("Create")]
            public async Task<bool> Create([FromBody]Supplier supplier)
            {
                if (ModelState.IsValid)
                {
                    supplier.Id = Guid.NewGuid().ToString();
                    _dbContext.Add(supplier);
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
            public async Task<Supplier> Details(string id)
            {
                return await _dbContext.Supplier.FindAsync(id);
            }

            [HttpPut]
            [Route("Edit/{id}")]
            public async Task<bool> Edit(string id, [FromBody]Supplier supplier)
            {
                if (id != supplier.Id)
                {
                    return false;
                }

                _dbContext.Entry(supplier).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            [HttpDelete]
            [Route("Delete/{id}")]
            public async Task<bool> DeleteConfirmed(string id)
            {
                var suppliermfg = await _dbContext.Supplier.FindAsync(id);
                if (suppliermfg == null)
                {
                    return false;
                }

                _dbContext.Supplier.Remove(suppliermfg);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

    }