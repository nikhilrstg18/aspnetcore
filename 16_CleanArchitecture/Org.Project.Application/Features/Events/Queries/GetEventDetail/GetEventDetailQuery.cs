using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<EventDetailDto>
    {
        public Guid EventId { get; set; }

        public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IAsyncRepository<Event> _eventRepository;
            private readonly IAsyncRepository<Category> _categoryRepository;

            public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository)
            {
                _mapper = mapper;
                _eventRepository = eventRepository;
                _categoryRepository = categoryRepository;

            }

            public async Task<EventDetailDto> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
            {
                var @event = await _eventRepository.GetByIdAsync(request.EventId);
                var eventDetailDto = _mapper.Map<EventDetailDto>(@event);

                var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

                eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

                return eventDetailDto;
            }
        }
    }
}
