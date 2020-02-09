﻿using System;
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
    public class ConnectionController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ConnectionController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Connection>> Get()
        {
            return await _dbContext.Connection.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody]Connection connection)
        {
            if (ModelState.IsValid)
            {
                connection.Id = Guid.NewGuid().ToString();
                _dbContext.Add(connection);
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
        public async Task<Connection> Details(string id)
        {
            return await _dbContext.Connection.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(string id, [FromBody]Connection connection)
        {
            if (id != connection.Id)
            {
                return false;
            }

            _dbContext.Entry(connection).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(string id)
        {
            var ConnectionEdi = await _dbContext.Connection.FindAsync(id);
            if (ConnectionEdi == null)
            {
                return false;
            }

            _dbContext.Connection.Remove(ConnectionEdi);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}