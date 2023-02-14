using AutoMapper;
using Pets_R_Us.Data;
using Pets_R_Us.Models;

namespace Pets_R_Us.Configurations
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<PetImageTable, PetImageTablesVM>().ReverseMap();
        }

    }
}
