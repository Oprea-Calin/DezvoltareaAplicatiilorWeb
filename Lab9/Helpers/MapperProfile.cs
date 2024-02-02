using AutoMapper;
using Lab9.Models;
using Proiect.Data.DTOs;
using Proiect.Data.Models;

namespace Lab9.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Comanda, ComandaDTO>()
                .ForMember(t => t.User, opt => opt.MapFrom(src => new UserDTO
                {
                    Id = src.User.Id
                })); ;
            CreateMap<ComandaDTO, Comanda>();


            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Provider, ProviderDTO>();
            CreateMap<ProviderDTO, Provider>();
            CreateMap<ComandaArticol, ComandaArticolDTO>();
            CreateMap<ComandaArticolDTO, ComandaArticol>();
            CreateMap<Articol, ArticolDTO>()
                .ForMember(t => t.Provider, opt => opt.MapFrom(src => new ProviderDTO
                {
                    Id = src.Provider.Id,
                    Nume=src.Provider.Nume
                    
                })) ;
            CreateMap<ArticolDTO, Articol>();
            CreateMap<User, UserUpdateDTO>();
            CreateMap<UserUpdateDTO, User>();
        }

    }
}
