using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDI_suppliers.Data;
using Microsoft.EntityFrameworkCore;

namespace EDI_suppliers.Services
{
    public interface ISupplierService
    {
        Task<List<Supplier>> Get();
        Task<Supplier> Get(int id);
        Task<Supplier> Add(Supplier supplier);
        Task<Supplier> Update(Supplier supplier);
        Task<Supplier> Delete(int id);
    }
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Supplier>> Get()
        {
            return await _context.Suppliers.ToListAsync();
        }
        public async Task<Supplier> Get(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            return supplier;
        }
        public async Task<Supplier> Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
        public async Task<Supplier> Update(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return supplier;
        }
        public async Task<Supplier> Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
    }
}