using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using net_api_backend.Hubs;
using net_api_backend.Hubs.Clients;
using net_api_backend.Models;
using net_api_backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository repo;
        private readonly IHubContext<DeviceHub, IDeviceClient> deviceHub;


        public DeviceController(IDeviceRepository repo, IHubContext<DeviceHub, IDeviceClient> deviceHub)
        {
            this.repo = repo;
            this.deviceHub = deviceHub;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDeviceById(long id)
        {
            var device = await repo.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            return device;
        }

        [HttpGet]
        public async Task<Object> GetAllDevices([FromQuery] QueryParameter queryParam)
        {
            var devices = await repo.GetAll(queryParam);
            var count = await repo.GetCount(queryParam);

            if (devices == null) return NotFound();
            var (pageSize, page, _) = queryParam;
            return new { devices, pageInfo = new { pageSize, page, count, pageCount = (int)Math.Ceiling((double)count / pageSize)} };
        }

        //[HttpGet()]
        //public async Task<ActionResult<IEnumerable<Device>>> GetAllDevicesByBrand(long brandId)
        //{
        //    var devices = await repo.GetAllByBrandId(brandId);

        //    if (devices == null) return NotFound();
        //    return devices.ToList();
        //}

        [HttpPost]
        public async Task<ActionResult<Device>> AddDevice(Device newDevice)
        {
            var device = await repo.Add(newDevice);
            await requestReloadData();
            return device;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(long id, Device newDevice)
        {
            await repo.Update(id, newDevice);
            await requestReloadData();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(long id)
        {
            await repo.Delete(id);
            await requestReloadData();
            return NoContent();
        }

        [HttpGet("{id}/brand")]
        public async Task<ActionResult<Brand>> GetBrandById(long id)
        {
            return await repo.GetBrand(id);
        }

        private async Task requestReloadData()
        {
            await deviceHub.Clients.All.ReloadData(DateTime.Now.ToString("yyyyMMddHHmmss"));
            return;
        }
    }
 }
