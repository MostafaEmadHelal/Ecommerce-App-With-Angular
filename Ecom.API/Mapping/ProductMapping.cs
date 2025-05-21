﻿using AutoMapper;
using Ecom.core.DTO;
using Ecom.core.Entities.product;

namespace Ecom.API.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>
                ().ForMember(x => x.CategoryName, op => op.MapFrom(src => src.Category.Name)).ReverseMap();

            CreateMap<Photo,PhotoDTO>().ReverseMap();

            CreateMap<AddProductDTO, Product>()
                .ForMember(m => m.Photos, op => op.Ignore())
                .ReverseMap();

            CreateMap<UpdateProductDTO, Product>()
                .ForMember(m => m.Photos, op => op.Ignore())
                .ReverseMap();

        }
    }
}
