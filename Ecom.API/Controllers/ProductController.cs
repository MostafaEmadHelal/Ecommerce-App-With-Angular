using AutoMapper;
using Ecom.API.Helper;
using Ecom.core.DTO;
using Ecom.core.Entities.product;
using Ecom.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try
            {
                var Product = await work.ProductRepository
                    .GetAllAsync(x=>x.Category,x=>x.Photos);

                var result = mapper.Map<List<ProductDTO>>(Product);

                if (Product is null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var product = await work.ProductRepository.GetByIdAsync(id,
                    x => x.Category, x => x.Photos);

                var result = mapper.Map<ProductDTO>(product);
                if (product is null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Product")]
        public async Task<IActionResult> add(AddProductDTO productDTO)
        {
            try
            {
                await work.ProductRepository.AddAsync(productDTO);
                return Ok(new ResponseAPI(200));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400,ex.Message));
            }
        }

        [HttpPut("Update-Product")]
        public async Task<IActionResult> update(UpdateProductDTO updateProductDTO)
        {
            try
            {
                await work.ProductRepository.UpdateAsync(updateProductDTO);
                return Ok(new ResponseAPI(200));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400,ex.Message));

            }
        }

        [HttpDelete("Delete-Product/{Id}")]
        public async Task<IActionResult> delete(int Id)
        {
            try
            {
                var product = await work.ProductRepository
                    .GetByIdAsync(Id, x => x.Photos, x => x.Category);
                await work.ProductRepository.DeleteAsync(product);
                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

    }
}
