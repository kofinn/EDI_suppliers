using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDI_suppliers.Data;
using Microsoft.EntityFrameworkCore;

namespace EDI_suppliers.Services
{
    public interface IConnectionService
    {
        Task<List<Connection>> Get();
        Task<Connection> Get(int id);
        Task<Connection> Add(Connection connection);
        Task<Connection> Update(Connection connection);
        Task<Connection> Delete(int id);
    }
    public class ConnectionService : IConnectionService
    {
        private readonly ApplicationDbContext _context;
        public ConnectionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Connection>> Get()
        {
            return await _context.Connections.ToListAsync();
        }
        public async Task<Connection> Get(int id)
        {
            var connection = await _context.Connections.FindAsync(id);
            return connection;
        }
        public async Task<Connection> Add(Connection connection)
        {
            _context.Connections.Add(connection);
            await _context.SaveChangesAsync();
            return connection;
        }
        public async Task<Connection> Update(Connection connection)
        {
            _context.Entry(connection).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return connection;
        }
        public async Task<Connection> Delete(int id)
        {
            var connection = await _context.Connections.FindAsync(id);
            _context.Connections.Remove(connection);
            await _context.SaveChangesAsync();
            return connection;
        }
    }
}
