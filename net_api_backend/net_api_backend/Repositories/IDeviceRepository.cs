using net_api_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAll(QueryParameter query);

        Task<Device> GetById(long id);

        Task<Device> Add(Device newDevice);

        Task Update(long id, Device newDeviceState);

        Task Delete(long id);

        Task<Brand> GetBrand(long id);

        Task<long> GetCount(QueryParameter query);

        //Task<IEnumerable<Device>> GetAllByBrandId(long brandId);
    }
}
