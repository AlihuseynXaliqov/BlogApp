using System.Runtime;
using AutoMapper;
using BlogApp.API.DTOs.Category;
using BlogApp.API.DTOs.Product;
using BlogApp.Model.Entities;

namespace BlogApp.API.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper() {
            CreateMap<CreateCategoryDtos, Category>().ReverseMap();
            CreateMap<UpdateCategoryDtos, Category>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();

        }

    }
}
