using Microsoft.AspNetCore.Mvc;
using RestApi.BusinessLayer;
using RestApi.Models;
using RestApi.ViewModel;
using System.Collections.Generic;

namespace RestApi.Controllers
{
    [Route("api/FruitVice")]
    [ApiController]
    public class FruitViceController :ControllerBase
    {
        private IFruitServices FruitServices;

        public FruitViceController(IFruitServices fruitServices)
        {
            FruitServices= fruitServices;               // constructor dependency injection
                }



        [HttpGet]
        public IEnumerable<fruitViewModel> GetFruits()
        {
            List <fruitViewModel> fruitList = new List<fruitViewModel>();
            fruitList = FruitServices.GetFruitsList();
            return fruitList;
        }
        [HttpPost]
        public  ActionResult<fruitViewModel> CreateFruitDetails([FromBody] fruitViewModel fruitViewModel )
        {
           if( fruitViewModel == null )
            {
                return BadRequest(fruitViewModel);
            }
            try
            {
                FruitServices.PostFruitDetails(fruitViewModel);
                return Ok(fruitViewModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
             
        
        }

        [HttpPost("{fruitFamily}")]
        
        public IEnumerable<fruitViewModel> GetFruitsDetailsWithFruitFamily(string fruitFamily)
        {
            
            List<fruitViewModel> fruitList = new List<fruitViewModel>();
            fruitList = FruitServices.GetFruitsDetailsWithFruitFamily(fruitFamily);
            return fruitList;
        }
    }
}
