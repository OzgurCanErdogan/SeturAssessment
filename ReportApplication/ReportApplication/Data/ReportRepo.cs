using ReportApplication.Models;
using System;

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
        public void CreateReport(Report report)
        {
            
            _context.Reports.Add(report);
            SaveChanges();
        }
        public void CreateReportDetail(ReportDetails reportDetails)
        {
            if (reportDetails == null)
            {
                throw new ArgumentNullException(nameof(reportDetails));
            }
            _context.ReportDetails.Add(reportDetails);
            SaveChanges();
        }
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
        public IEnumerable<Report> GetAllReportsWithCompletedStatus()
        {
            return _context.Reports.Where(p=>p.Status == ReportStatus.Created).ToList();
        }
        
        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
