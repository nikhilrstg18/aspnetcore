using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Infrastructure;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery : IRequest<EventExportFileDto>
    {
        public class GetEventExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileDto>
        {
            private readonly IAsyncRepository<Event> _eventRepository;
            private readonly ICsvExporter _csvExporter;
            private readonly IMapper _mapper;

            public GetEventExportQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, ICsvExporter csvExporter)
            {
                _eventRepository = eventRepository;
                _csvExporter = csvExporter;
                _mapper = mapper;
            }
                
            public async Task<EventExportFileDto> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
            {
                var allEvents = _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsync()).OrderBy(x => x.Date));

                var fileData = _csvExporter.ExportEventsToCsv(allEvents);

                var eventExportFileDto = new EventExportFileDto
                {
                    ContentType = "text/csv",
                    Data = fileData,
                    Name = $"{Guid.NewGuid()}.csv"
                };
                return eventExportFileDto;


            }
        }
    }
}
