using Org.Project.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace Org.Project.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
