using ReportApplication.Models;

namespace ReportApplication.Data
{
    public class ReportRepo : IReportRepo
    {
        private readonly AppDbContext _context;
        public ReportRepo(AppDbContext context)
        {
            _context = context;
        }

        //IReportRepo Implemantation
        public IEnumerable<Report> GetAllReports()
        {
            return _context.Reports.ToList();
        }

        public Report GetReportById(Guid id)
        {
            return _context.Reports.FirstOrDefault(p => p.Id == id);
        }

        public ReportDetails GetReportDetailsById(Guid id)
        {
            return _context.ReportDetails.FirstOrDefault(p => p.ReportId == id);
        }

        
    }
}
