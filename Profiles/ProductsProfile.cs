using AutoMapper;
using dotnet_login.Dtos;
using dotnet_login.Models;

namespace dotnet_login.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            //Source -> Target
            CreateMap<Product, ReadProductDto>();
            // CreateMap<CommandCreateDto, Command>();
            // CreateMap<CommandUpdateDto, Command>();
            // CreateMap<Command, CommandUpdateDto>();
        }
    }
}