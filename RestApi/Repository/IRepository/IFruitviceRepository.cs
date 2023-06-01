using RestApi.Models;
using RestApi.ViewModel;

namespace RestApi.Repository.IRepository
{
    public interface IFruitviceRepository
    {
       List<fruit> GetFruitsList();
        fruit PostFruitDetails(fruit fruit,nutrition nutrition);
        List<fruit> GetFruitsDetailsWithFruitFamily(string fruitFamily);
       nutrition GetNutritionDetailsWithFruitFamily(int  id);
    }
}
