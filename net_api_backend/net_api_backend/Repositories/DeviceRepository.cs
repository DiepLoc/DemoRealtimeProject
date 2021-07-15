using net_api_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace net_api_backend.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly sqliteContext dbContext;

        public DeviceRepository (sqliteContext context)
        {
            dbContext = context;
        }

        public async Task<Device> Add(Device newDevice)
        {          
            dbContext.Devices.Add(newDevice);
            await dbContext.SaveChangesAsync();

            return await dbContext.Devices.Include(d => d.Brand).FirstOrDefaultAsync(d => d.Id == newDevice.Id);
        }

        
        public async Task Delete(long id)
        {
            var device = await dbContext.Devices.FindAsync(id);

            if (device == null) throw new Exception("Device not found");

            dbContext.Devices.Remove(device);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Device>> GetAll(QueryParameter query)
        {
            var (pageSize, page, brandId) = query;
            IQueryable<Device> queryable;

            if (brandId != null)
            {
                queryable = dbContext.Devices
                    .Include("Brand")
                    .Where(d => d.BrandId == brandId)
                    .OrderBy(d => d.Name)
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize);

                while( await queryable.CountAsync() < 1 && page > 1)
                {
                    page--;
                    queryable = dbContext.Devices
                    .Include("Brand")
                    .Where(d => d.BrandId == brandId)
                    .OrderBy(d => d.Name)
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize);
                }
            } 
            else
            {
                queryable = dbContext.Devices
                .Include("Brand")
                .OrderBy(d => d.Name)
                .Skip(pageSize * (page - 1))
                .Take(pageSize);

                while (await queryable.CountAsync() < 1 && page > 1)
                {
                    page--;
                    queryable = dbContext.Devices
                        .Include("Brand")
                        .OrderBy(d => d.Name)
                        .Skip(pageSize * (page - 1))
                        .Take(pageSize);
                }
            }
            query.Page = page;
            return await queryable.ToListAsync();
        }
        
        public async Task<long> GetCount(QueryParameter query)
        {
            var brandId = query.BrandId;
            if (brandId == null) return await dbContext.Devices.CountAsync();

            return await dbContext.Devices.Where(d => d.BrandId == brandId).CountAsync();
        }

        public async Task<IEnumerable<Device>> GetAllByBrandId(long brandId)
        {
            return await dbContext.Devices.Where(d => d.BrandId == brandId).ToListAsync();
        }

        public async Task<Brand> GetBrand(long id)
        {
            var device = await GetById(id);
            if (device == null) throw new Exception("Bad request");

            return await dbContext.Brands.Include(b => b.Devices).FirstOrDefaultAsync(b => b == device.Brand);
        }

        public async Task<Device> GetById(long id)
        {
            return await dbContext.Devices.Include(d => d.Brand).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Update(long id, Device newDeviceState)
        {
            if (newDeviceState != null && id != newDeviceState.Id) throw new Exception("Bad request");

            var device = await dbContext.Devices.FindAsync(id);

            if (device == null) throw new Exception("Not found");

            dbContext.Entry(device).State = EntityState.Detached;
            dbContext.Entry(newDeviceState).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

    }
}
