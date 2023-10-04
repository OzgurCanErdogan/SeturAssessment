using ReportApplication.Models;

namespace ReportApplication.Data
{
    public interface IReportRepo
    {
        Report GetReportById(Guid id);
        IEnumerable<Report> GetAllReports();
        ReportDetails GetReportDetailsById(Guid id);

    }
}
