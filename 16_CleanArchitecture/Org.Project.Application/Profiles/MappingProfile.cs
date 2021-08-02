using AutoMapper;
using Org.Project.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Org.Project.Application.Features.Categories.Queries.GetCategoryList;
using Org.Project.Application.Features.Events.Queries.GetEventDetail;
using Org.Project.Application.Features.Events.Queries.GetEventList;
using Org.Project.Domain.Entities;

namespace Org.Project.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListDto>().ReverseMap();
            CreateMap<Event, EventDetailDto>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryEventListDto>();
        } 
    }
}
