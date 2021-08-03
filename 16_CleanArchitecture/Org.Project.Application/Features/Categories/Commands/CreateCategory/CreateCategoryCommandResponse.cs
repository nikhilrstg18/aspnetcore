using Org.Project.Application.Responses;

namespace Org.Project.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse():base()
        {

        }
        public CreateCategoryDto Category { get; set; }
    }
}