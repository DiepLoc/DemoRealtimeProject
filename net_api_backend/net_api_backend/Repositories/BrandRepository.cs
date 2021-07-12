using Microsoft.EntityFrameworkCore;
using net_api_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly sqliteContext dbContext;

        public BrandRepository(sqliteContext context)
        {
            dbContext = context;
        }

        public Task<Brand> Add(Brand newBrand)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await dbContext.Brands.ToListAsync();
        }

        public async Task<Brand> GetById(long id)
        {
            return await dbContext.Brands.FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<IEnumerable<Device>> GetDevice(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(long id, Brand newBrand)
        {
            throw new NotImplementedException();
        }
    }
}
