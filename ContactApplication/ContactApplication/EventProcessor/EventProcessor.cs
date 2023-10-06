using AutoMapper;
using ContactApplication.Data;
using ContactApplication.Dtos;
using ContactApplication.Services;
using System.Text.Json;

namespace ContactApplication.EventProcessor
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);
            switch (eventType)
            {
                case EventType.ReportRequested:
                    addReport(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
            switch (eventType.Event)
            {
                case "ReportRequested":
                    Console.WriteLine("--> Report Requested Event Detected");
                    return EventType.ReportRequested;
                default:
                    Console.WriteLine("--> Could not determine event type");
                    return EventType.Undermined;
            }
        }

        private void addReport(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IContactRepo>();

                var reportRequestDto = JsonSerializer.Deserialize<ReportRequestDto>(platformPublishedMessage);

                try
                {
                    if (repo.IsReportExist(reportRequestDto.Id))
                    {
                        ExcelBuilder excelBuilder = new ExcelBuilder();
                        var file = excelBuilder.BuildExcel(repo.GetAllDetailed().ToList());
                        repo.CreateReportDetail(reportRequestDto.Id, file);
                        repo.UpdateReportStatus(reportRequestDto.Id);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("--> Could not add Report to DB " + ex.Message);
                }
            }
        }
    }
    enum EventType
    {
        ReportRequested,
        Undermined
    }

}

