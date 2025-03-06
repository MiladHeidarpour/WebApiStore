using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CatalogTypes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.CatalogTypes;
using Domain.Catalogs;
using Application.Catalogs.CatalogItems.AddNewCatalogItem;

namespace Admin.EndPoint.MappingProfiles
{
    public class CatalogVMMappingProfile:Profile
    {
        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
            CreateMap<AddNewCatalogItemDto, CatalogItem>()
                .ForMember(dest => dest.CatalogItemFeatures, opt => opt.MapFrom(src => src.CatalogItemFeatures))
                .ForMember(dest => dest.CatalogItemImages, opt => opt.MapFrom(src => src.CatalogItemImages));
        }
    }
}
