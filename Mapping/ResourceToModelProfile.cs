using AutoMapper;
using Shop.Api.Domain.Models;
using Shop.Api.Resources;

namespace Shop.Api.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveGoodResource, Good>();
        }
    }
}