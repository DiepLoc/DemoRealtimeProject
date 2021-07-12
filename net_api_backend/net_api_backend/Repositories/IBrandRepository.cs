using net_api_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAll();

        Task<Brand> GetById(long id);

        Task<Brand> Add(Brand newBrand);

        Task Update(long id, Brand newBrand);

        Task Delete(long id);

        Task<IEnumerable<Device>> GetDevice(long id);
    }
}
