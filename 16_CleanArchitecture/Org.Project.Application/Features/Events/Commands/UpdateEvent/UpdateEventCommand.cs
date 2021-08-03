using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }

        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
        {
            private readonly IAsyncRepository<Event> _eventRepository;
            private readonly IMapper _mapper;

            public UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
            {
                var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
                _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

                await _eventRepository.UpdateAsync(eventToUpdate);

                return Unit.Value;
            }
        }


    }
}
