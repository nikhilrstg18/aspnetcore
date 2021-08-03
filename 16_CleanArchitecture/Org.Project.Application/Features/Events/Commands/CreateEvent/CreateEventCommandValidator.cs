using FluentValidation;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is reuqired.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(c => c.Date)
                .NotEmpty().WithMessage("{PropertyName} is reuqired.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("{PropertyName} is reuqired.")
                .GreaterThan(0);

            RuleFor(c => c).MustAsync(EventNameAndDateUnique).WithMessage("An event with same name and date already exists.");
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand c, CancellationToken token)
        {
            return !await _eventRepository.IsEventNameAndDateUnique(c.Name, c.Date);
        }
    }
}
