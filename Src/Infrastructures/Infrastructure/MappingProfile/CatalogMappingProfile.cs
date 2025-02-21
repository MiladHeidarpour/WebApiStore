using Application.Catalogs.GetMenuItem;
using Application.Dtos.CatalogTypes;
using AutoMapper;
using Domain.Catalogs;

namespace Infrastructure.MappingProfile;

public class CatalogMappingProfile : Profile
{
    public CatalogMappingProfile()
    {
        CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

        CreateMap<CatalogType, CatalogTypeListDto>().ReverseMap();
        //.ForMember(dest => dest.SubTypeCount, option =>
        //option.MapFrom(src => src.SubType.Count))

        CreateMap<CatalogType, MenuItemDto>().ReverseMap();
    }
}