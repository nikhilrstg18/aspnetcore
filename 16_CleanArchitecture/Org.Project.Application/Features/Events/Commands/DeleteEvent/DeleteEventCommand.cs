using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }

        public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
        {
            private readonly IAsyncRepository<Event> _eventRepository;
            private readonly IMapper _mapper;

            public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
            {
                var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);
                await _eventRepository.DeleteAsync(eventToDelete);

                return Unit.Value;
            }
        }
    }
}
