using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        private readonly JwtAppContext _context;
        public ProductRepository(JwtAppContext context) : base(context){
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductsMoreExpensive(int cant) =>
            await _context.Products
                .OrderByDescending(p => p.Price)
                .Take(cant)
                .ToListAsync();
        public override async Task<Product> GetByIdAsync(int id){
            return await _context.Products
                   .Include(p => p.Brand)
                   .Include(p => p.Category)
                   .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Product>> GetAllAsync(){
            return await _context.Products
                    .Include(u => u.Brand)
                    .Include(u => u.Category)
                    .ToListAsync();
        }
    }
}