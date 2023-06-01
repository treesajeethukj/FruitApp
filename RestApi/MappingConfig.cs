using AutoMapper;
using RestApi.Models;
using RestApi.ViewModel;

namespace RestApi
{
    public class MappingConfig :Profile
    {
        public MappingConfig() {
            CreateMap<fruit, fruitViewModel>().ReverseMap();
          
            CreateMap<nutrition, nutritionsViewModel>();
            CreateMap<nutritionsViewModel, nutrition>();
        }
    }
}
