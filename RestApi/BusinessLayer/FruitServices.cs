using AutoMapper;
using AutoMapper.Internal;
using RestApi.Models;
using RestApi.Repository;
using RestApi.Repository.IRepository;
using RestApi.ViewModel;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RestApi.BusinessLayer
{
    public class FruitServices : IFruitServices
    {
        private IFruitviceRepository _fr;
        private IMapper _autoMap;
        public FruitServices(IFruitviceRepository fr, IMapper _aMap) {
            _fr = fr;
            _autoMap = _aMap;
        }  
        public List<fruitViewModel> GetFruitsList()
        {
            List<fruitViewModel> fruitsList = new List<fruitViewModel>();
            List<nutritionsViewModel> nutriList = new List<nutritionsViewModel>();
            List<fruit> fruit = new List<fruit>();
            fruit = _fr.GetFruitsList();
            fruitsList = FillNutritionDetails(fruit);
            return fruitsList;
        }

        public fruitViewModel PostFruitDetails(fruitViewModel fruitViewModel)
        {
            fruit fruit = new fruit();
            fruit =_autoMap.Map<fruit>(fruitViewModel);
            nutrition nutrition = new nutrition();
            nutrition = _autoMap.Map<nutrition>(fruitViewModel.Nutritions);
            _fr.PostFruitDetails(fruit,nutrition);
            return fruitViewModel;

        }
        public List<fruitViewModel> GetFruitsDetailsWithFruitFamily(string fruitFamily) 
        {
            List<fruitViewModel> fruitsList = new List<fruitViewModel>();
            List<nutritionsViewModel> nutriList = new List<nutritionsViewModel>();
            List < fruit> fruit = new List<fruit>();
            fruit = _fr.GetFruitsDetailsWithFruitFamily(fruitFamily);
            fruitsList = FillNutritionDetails(fruit);
            return fruitsList;
        }
        public List<fruitViewModel> FillNutritionDetails(List<fruit> fruit)
        {
            List<fruitViewModel> fruitsList = new List<fruitViewModel>();
            List<nutrition> nutriList = new List<nutrition>();
            foreach (fruit f in fruit)
            {              
                nutrition nutrition = new nutrition();
                fruitViewModel fruitViewModel = new fruitViewModel();
                fruitViewModel = _autoMap.Map<fruitViewModel>(f);
                nutrition =_fr.GetNutritionDetailsWithFruitFamily(f.Id);
                fruitViewModel.Nutritions = _autoMap.Map<nutritionsViewModel>(nutrition);

                fruitsList.Add(fruitViewModel);
            }
            return fruitsList;
        }
    }
}
