using EDI_suppliers.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDI_suppliers.Services
{
    public interface IGatewayService
    {
        Task<List<Gateway>> Get();
        Task<Gateway> Get(int id);
        Task<Gateway> Add(Gateway gateway);
        Task<Gateway> Update(Gateway gateway);
        Task<Gateway> Delete(int id);
    }
    public class GatewayService : IGatewayService
    {
        private readonly ApplicationDbContext _context;
        public GatewayService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Gateway>> Get()
        {
            return await _context.Gateways.ToListAsync();
        }
        public async Task<Gateway> Get(int id)
        {
            var gateway = await _context.Gateways.FindAsync(id);
            return gateway;
        }
        public async Task<Gateway> Add(Gateway gateway)
        {
            _context.Gateways.Add(gateway);
            await _context.SaveChangesAsync();
            return gateway;
        }
        public async Task<Gateway> Update(Gateway gateway)
        {
            _context.Entry(gateway).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gateway;
        }
        public async Task<Gateway> Delete(int id)
        {
            var gateway = await _context.Gateways.FindAsync(id);
            _context.Gateways.Remove(gateway);
            await _context.SaveChangesAsync();
            return gateway;
        }
    }
}