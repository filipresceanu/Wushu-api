﻿using WushuParticipants.Dto;
using WushuParticipants.Models;
using WushuParticipants.Repository;

namespace WushuParticipants.Services
{
    public class AgeCategoryService : IAgeCategoryService
    {
        private readonly IAgeCategoryRepository _ageCategoryRepository;
        public AgeCategoryService(IAgeCategoryRepository ageCategoryRepository)
        {
            _ageCategoryRepository = ageCategoryRepository;
        }

        public async Task CreateAgeCategory(AgeCategoryDto ageCategory)
        {
            await _ageCategoryRepository.CreateAgeCategory(ageCategory);
        }

        public async Task<AgeCategory> GetAgeCategoryById(Guid ageCategoryId)
        {
            var ageCategory= await _ageCategoryRepository.GetAgeCategoryById(ageCategoryId);
            return ageCategory;
        }

        public async Task<IEnumerable<AgeCategoryDto>> GetAgeCategories()
        {
            var ageCategories=await _ageCategoryRepository.GetAgeCategories();  
            return ageCategories;
        }
    }
}
