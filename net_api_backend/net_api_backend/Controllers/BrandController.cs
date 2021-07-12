using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_api_backend.Models;
using net_api_backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository repo;

        public BrandController(IBrandRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
        {
            var brands = await repo.GetAll();
            if (brands == null) return NotFound();

            return brands.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrandById(long id)
        {
            var brand = await repo.GetById(id);
            if (brand == null) return BadRequest();

            return brand;
        }
    }
}
