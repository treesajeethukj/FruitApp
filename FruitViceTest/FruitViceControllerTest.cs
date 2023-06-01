using AutoMapper;
using Moq;
using Newtonsoft.Json;
using RestApi.BusinessLayer;
using RestApi.Controllers;
using RestApi.Models;
using RestApi.Repository.IRepository;
using RestApi.ViewModel;
using System;
using System.Text.Json.Nodes;
using FakeItEasy;
using System.Collections.Generic;

namespace FruitViceTest
{
    public class FruitViceControllerTest
    {
     
        private readonly IFruitServices fruitService;
        private readonly Mock<IFruitviceRepository> fruitviceRepositoryMock = new Mock<IFruitviceRepository>();
        private readonly Mock<IMapper> mapperMock = new Mock<IMapper>();
        
        [Fact]

        public void GetFruitsTest()
        {
           
           var fr = new FruitServices(fruitviceRepositoryMock.Object, mapperMock.Object);
           
            List<fruit> fruitList = new List<fruit>();
           nutrition nlist = new nutrition();
          
            using StreamReader reader = new("G:\\ASPNET\\Project\\FruitViceTest\\fruit.json");
            var json = reader.ReadToEnd();
            fruitList = JsonConvert.DeserializeObject<List<fruit>>(json);
            fruitviceRepositoryMock.Setup(x => x.GetFruitsList()).Returns(fruitList);
            fruitviceRepositoryMock.Setup(x => x.GetNutritionDetailsWithFruitFamily(1)).Returns(nlist);
            mapperMock.Setup(m => m.Map< fruit, fruitViewModel>(It.IsAny<fruit>())).Returns(new fruitViewModel());
           
            mapperMock.Setup(m => m.Map<nutrition, nutritionsViewModel>(It.IsAny<nutrition>())).Returns(new nutritionsViewModel());
            var fruitList1 = fr.GetFruitsList();
           
            Assert.NotNull(fruitList1);
        }

    }
}