using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Infrastructure;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Application.Exceptions;
using Org.Project.Application.Models.Mail;
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
            private readonly IEmailService _emailService;

            public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
            {
                _mapper = mapper;
                _eventRepository = eventRepository;
                _emailService = emailService;
            }

            public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
            {
                //todo: use DI
                var validator = new CreateEventCommandValidator(_eventRepository);
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                    throw new ValidationException(validationResult);

                var @event = _mapper.Map<Event>(request);

                @event = await _eventRepository.AddAsync(@event);

                var email = new Email { To = "nikhilrstg18@gmail.com", Body = "A new event was created with id: " + @event.EventId, Subject = "A new event created" };

                try
                {
                    await _emailService.SendEmail(email);
                        
                }
                catch (Exception)
                {
                    //this shouldn't stop API and this can be logged
                    //throw;
                }

                return @event.EventId;
            }
        }
    }
}
