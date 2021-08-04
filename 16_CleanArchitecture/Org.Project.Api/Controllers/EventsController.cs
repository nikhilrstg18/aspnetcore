using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.Project.Application.Features.Events.Commands.CreateEvent;
using Org.Project.Application.Features.Events.Commands.DeleteEvent;
using Org.Project.Application.Features.Events.Commands.UpdateEvent;
using Org.Project.Application.Features.Events.Queries.GetEventDetail;
using Org.Project.Application.Features.Events.Queries.GetEventList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet(Name = nameof(GetAllEvents))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListDto>>> GetAllEvents()
        {
            var dtos = await _mediator.Send(new GetEventListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = nameof(GetEventById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventListDto>> GetEventById(Guid id)
        {
            var dto = await _mediator.Send(new GetEventDetailQuery { EventId = id });
            return Ok(dto);
        }

        [HttpPost(Name = nameof(AddEvent))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventListDto>> AddEvent([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return Ok(id);
        }

        [HttpPut(Name = nameof(UpdateEvent))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventListDto>> UpdateEvent([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteEvent))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventListDto>> DeleteEvent(Guid id)
        {
            await _mediator.Send(new DeleteEventCommand { EventId = id });
            return NoContent();
        }

    }
}
