using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDI_suppliers.Data;
using Microsoft.EntityFrameworkCore;

namespace EDI_suppliers.Services
{
    public interface IPartnerService
    {
        Task<List<Partner>> Get();
        Task<Partner> Get(int id);
        Task<Partner> Add(Partner partner);
        Task<Partner> Update(Partner partner);
        Task<Partner> Delete(int id);
    }
    public class PartnerService : IPartnerService
    {
        private readonly ApplicationDbContext _context;
        public PartnerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Partner>> Get()
        {
            return await _context.Partners.ToListAsync();
        }
        public async Task<Partner> Get(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            return partner;
        }
        public async Task<Partner> Add(Partner partner)
        {
            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();
            return partner;
        }
        public async Task<Partner> Update(Partner partner)
        {
            _context.Entry(partner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return partner;
        }
        public async Task<Partner> Delete(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
            return partner;
        }
    }
}