﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WushuParticipants.Dto;
using WushuParticipants.Models;
using WushuParticipants.Services;

namespace WushuParticipants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeCategoryController : ControllerBase
    {
        private readonly IAgeCategoryService _ageCategoryService;

        public AgeCategoryController(IAgeCategoryService ageCategoryService)
        {
            _ageCategoryService = ageCategoryService;
        }

        [HttpPut("create-age-category")]
        public async Task<ActionResult> CreateAgeCategory(AgeCategoryDto ageCategory)
        {
            try
            {
                await _ageCategoryService.CreateAgeCategory(ageCategory);
                return Ok("success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("get-all-age-categories")]
        public async Task<ActionResult<IEnumerable<AgeCategoryDto>>> GetAgeCategories()
        {
            try
            {
                var ageCategories = await _ageCategoryService.GetAgeCategories();
                return Ok(ageCategories);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("get-age-categoty-id/{ageCategoryId}")]

        public async Task<ActionResult<AgeCategory>> GetAgeCategory(Guid ageCategoryId)
        {
            try
            {
                var ageCategory = await _ageCategoryService.GetAgeCategoryById(ageCategoryId);
                return Ok(ageCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
