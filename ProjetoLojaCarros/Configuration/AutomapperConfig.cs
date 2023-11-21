using AutoMapper;
using DevIOApi.ViewModels;
using DevIoBusiness.Models;

namespace DevIOApi.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

        }

    }
}
