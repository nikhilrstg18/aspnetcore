using AutoMapper;
using Org.Project.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Org.Project.Application.Features.Categories.Queries.GetCategoryList;
using Org.Project.Application.Features.Events.Commands.CreateEvent;
using Org.Project.Application.Features.Events.Commands.UpdateEvent;
using Org.Project.Application.Features.Events.Queries.GetEventDetail;
using Org.Project.Application.Features.Events.Queries.GetEventList;
using Org.Project.Application.Features.Events.Queries.GetEventsExport;
using Org.Project.Domain.Entities;

namespace Org.Project.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListDto>().ReverseMap();
            CreateMap<Event, EventDetailDto>().ReverseMap();
            CreateMap<Event, EventExportDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryEventListDto>();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
        } 
    }
}
