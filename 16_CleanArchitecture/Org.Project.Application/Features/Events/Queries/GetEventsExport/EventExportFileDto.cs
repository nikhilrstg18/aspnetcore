namespace Org.Project.Application.Features.Events.Queries.GetEventsExport
{
    public class EventExportFileDto
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
