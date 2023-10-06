using ReportApplication.Dtos;
using ReportApplication.Models;

namespace ReportApplication.Services
{
    public interface IReportService
    {
        void PublishNewReportDetails(ReportDetailsPublishedDto platformPublishedDto);
    }
}
