using CsvHelper;
using Org.Project.Application.Contracts.Infrastructure;
using Org.Project.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Org.Project.Infrastructure.FileExporter
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using var streamWriter = new StreamWriter(memoryStream);
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecord(eventExportDtos);

            return memoryStream.ToArray();
        }
    }
}
