using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.Project.Application.Features.Categories.Commands.CreateCategory;
using Org.Project.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Org.Project.Application.Features.Categories.Queries.GetCategoryList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = nameof(GetAllCategories))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListDto>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }

        [HttpGet("withevents", Name = nameof(GetAllCategoriesWithEvents))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListDto>>> GetAllCategoriesWithEvents(bool includeHistory)
        {
            var dtos = await _mediator.Send(new GetCategoriesListWithEventsQuery
            {
                IncludeHistory = includeHistory
            });
            return Ok(dtos);
        }

        [HttpPost(Name = nameof(AddCategory))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListDto>>> AddCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
