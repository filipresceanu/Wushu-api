using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Services;

namespace Wushu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        public CategoryController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpPut("create-category")]
        public async Task<ActionResult> AddEvent(CategoryDto categoryDto)
        {
            try
            {
                await _categoryServices.CreateCategory(categoryDto);

            }
            catch (Exception ex)
            {
                return BadRequest("Something Bad");
            }
            return Ok("Success");
        }

        [HttpGet("get-all-categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            try
            {
                var categories= await _categoryServices.GetAllCategoriesDto();
                return Ok(categories);
            }
            catch(Exception ex)
            {
                return BadRequest("Something Bad");
            }
            
        }
    }
}
