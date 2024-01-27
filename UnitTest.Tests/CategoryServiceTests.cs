using AutoFixture;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wushu_api.Repository;
using Wushu_api.Services;
using Wushu_api.Helper;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace UnitTest.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly Fixture _fixture;
        private readonly Mock<IEventRepository> _eventRepository;
        private readonly Mock<IAgeCategoryRepository> _ageCategoryRepository;
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryServiceTests()
        {
            _fixture = new Fixture();
            _ageCategoryRepository = new Mock<IAgeCategoryRepository>();
            _eventRepository = new Mock<IEventRepository>();
            _categoryRepository= new Mock<ICategoryRepository>();

            var mockMapper = new MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(AutoMapperProfile).Assembly);
            }).CreateMapper().ConfigurationProvider;

            _mapper = new Mapper(mockMapper);
            _categoryService = new CategoryService(_categoryRepository.Object, _eventRepository.Object,
                                                    _mapper, _ageCategoryRepository.Object);
        }

        [Fact]
        public async void CreateCategory_ValidData_Success()
        {
            //Arrange
              var categoryDto=_fixture.Create<CategoryDto>();
            var ageCategory= _fixture.Build<AgeCategory>().Without(elem=>elem.Categories).Create();
            var competitionEvent = _fixture.Build<Event>().Without(elem=>elem.Categories).Create();
            _eventRepository.Setup(repo => repo.GetEventId(It.IsAny<Guid>())).ReturnsAsync(competitionEvent);
            _ageCategoryRepository.Setup(repo => repo.GetAgeCategoryById(It.IsAny<Guid>())).ReturnsAsync(ageCategory);

            //act
            await _categoryService.CreateCategory(categoryDto, Guid.NewGuid(), Guid.NewGuid());

            //assert
            _categoryRepository.Verify(repo => repo.CreateCategory(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public async void DeleteCategory_ValidCategory_Success()
        {
            // Arrange
            var categoryId = Guid.NewGuid();

            // Act
            await _categoryService.DeleteCategory(categoryId);

            // Assert
            _categoryRepository.Verify(repo => repo.DeleteCategory(categoryId), Times.Once);
        }

        [Fact]
        public async void GetAllCategoriesDto_WithNoParams_Success()
        {
            //Arrange
            var categoriesDto= _fixture.CreateMany<CategoryDto>(10).ToList();
            _categoryRepository.Setup(repo=>repo.GetAllCategoriesDto()).ReturnsAsync(categoriesDto);

            //Act
            var result=await _categoryService.GetAllCategoriesDto();

            //Assert
            Assert.Equal(10,result.Count());
            Assert.IsType<List<CategoryDto>>(result);
        }

        [Fact]
        public async void GetCategoryData_ValidEvent_Success()
        {
            //Arrange
            var categories = _fixture.Build<Category>()
                .Without(elem => elem.Participants)
                .Without(elem => elem.AgeCategory)
                .Without(elem => elem.Event).CreateMany(10).ToList();
            var ageCategory = _fixture.Build<AgeCategory>()
                .Without(elem => elem.Categories).Create();
            _categoryRepository.Setup(repo => repo.GetCategorieForEventId(It.IsAny<Guid>())).ReturnsAsync(categories);
            foreach(var category in categories)
            {
                _ageCategoryRepository.Setup(repo => repo.GetAgeCategoryById(category.AgeCategoryId)).ReturnsAsync(ageCategory);
            }

            //Act
            var result= await _categoryService.GetCategoryData(Guid.NewGuid());

            //Assert
            Assert.Equal(10,result.Count());
            Assert.IsType<List<CategoryDataDto>>(result);
        }
    }
}
