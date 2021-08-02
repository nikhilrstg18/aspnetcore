using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventListDto>>
    {

        public class GetEventListQueryHandler
        : IRequestHandler<GetEventListQuery, List<EventListDto>>
        {
            private readonly IAsyncRepository<Event> _eventRepository;
            private readonly IMapper _mapper;

            public GetEventListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;

            }

            public async Task<List<EventListDto>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
            {
                var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);

                return _mapper.Map<List<EventListDto>>(allEvents);
            }
        }
    }
}
 