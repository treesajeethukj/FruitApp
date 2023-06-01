using Microsoft.EntityFrameworkCore;
using RestApi.DataLayer;
using RestApi.Models;
using RestApi.Repository.IRepository;

namespace RestApi.Repository
{
    public class FruitviceRepository : IFruitviceRepository
    {
        public FruitviceRepository(FruitviceApplicationDbContext db) { 
        _db = db;
        }
        private readonly FruitviceApplicationDbContext _db;
        public List<fruit> GetFruitsList()
        {
            IQueryable<fruit> query = _db.Fruit;
            return query.ToList();
        } 

        public fruit PostFruitDetails(fruit fruit,nutrition nutrition)
        {
          
             _db.Fruit.Add(fruit);

            _db.SaveChanges();
            nutrition.IdFruit = fruit.Id;
      
            _db.Nutrition.Add(nutrition);

            _db.SaveChanges();
            return fruit;
        }

        public List<fruit> GetFruitsDetailsWithFruitFamily(string fruitFamily)
        {
            IQueryable<fruit> query = _db.Fruit.Where(x => x.FruitFamily == fruitFamily);
         
            return query.ToList();
        }
        public nutrition GetNutritionDetailsWithFruitFamily(int fruitId)
        {
          nutrition query = _db.Nutrition.Where(x => x.IdFruit == fruitId).ToList().First();
           
            return query;
        }
    }
}
