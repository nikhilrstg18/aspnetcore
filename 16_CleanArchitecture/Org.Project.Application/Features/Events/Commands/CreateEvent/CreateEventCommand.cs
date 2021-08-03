using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Event name:{Name};Price:{Price};By:{Artist};On:{Date.ToShortDateString()};Description:{Description}";
        }

        public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
        {
            private readonly IMapper _mapper;
            private readonly IEventRepository _eventRepository;

            public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
            {
                _mapper = mapper;
                _eventRepository = eventRepository;
            }

            public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
            {
                var @event = _mapper.Map<Event>(request);

                @event = await _eventRepository.AddAsync(@event);

                return @event.EventId;
            }
        }
    }
}
