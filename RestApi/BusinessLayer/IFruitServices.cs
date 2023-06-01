using RestApi.Models;
using RestApi.ViewModel;

namespace RestApi.BusinessLayer
{
    public interface IFruitServices
    {
        List<fruitViewModel> GetFruitsList();
        fruitViewModel PostFruitDetails(fruitViewModel fruit);
        List<fruitViewModel> GetFruitsDetailsWithFruitFamily(string fruitFamily);
    }
}
