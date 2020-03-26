using AutoMapper;
using Shop.Api.Domain.Models;
using Shop.Api.Resources;

namespace Shop.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
            public ModelToResourceProfile()
            {
                CreateMap<Category, CategoryResource>();
                CreateMap<Good, GoodResource>();
            }
    }
}