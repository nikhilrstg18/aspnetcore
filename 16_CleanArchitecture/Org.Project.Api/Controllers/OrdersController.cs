using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Org.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;

        }
    }
}
