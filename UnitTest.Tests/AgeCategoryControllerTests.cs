using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Wushu_api.Controllers;
using Wushu_api.Dto;
using Wushu_api.Services;

namespace UnitTest.Tests
{
    public class AgeCategoryControllerTests
    {
        private readonly Mock<IAgeCategoryService>_ageCategoryService;
        private readonly Fixture _fixture;
        private readonly AgeCategoryController _ageCategoryController;

        public AgeCategoryControllerTests()
        {
            _fixture=new Fixture();
            _ageCategoryService = new Mock<IAgeCategoryService>();
            _ageCategoryController=new AgeCategoryController(_ageCategoryService.Object);
        }

        [Fact]
        public async void CreateAgeCategory_ValidData_Success()
        {
            //arrange
            var ageCategory=_fixture.Create<AgeCategoryDto>();

            //act
            var result = await _ageCategoryController.CreateAgeCategory(ageCategory);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}