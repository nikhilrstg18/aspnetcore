using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
        {
            private readonly IAsyncRepository<Category> _categoryRepository;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;

            }


            public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var createCategoryResponse = new CreateCategoryCommandResponse();
                var validator = new CreateCategoryCommandValidator();
                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                {
                    createCategoryResponse.Success = false;
                    createCategoryResponse.ValidationErrors = new List<string>();
                    foreach (var validationError in validationResult.Errors)
                    {
                        createCategoryResponse.ValidationErrors.Add(validationError.ErrorMessage);
                    }
                }
                if (createCategoryResponse.Success)
                {
                    var category = new Category { Name = request.Name };
                    category = await _categoryRepository.AddAsync(category);
                    createCategoryResponse.Category = _mapper.Map<CreateCategoryDto>(category);
                }

                return createCategoryResponse;
            }
        }

    }
}
