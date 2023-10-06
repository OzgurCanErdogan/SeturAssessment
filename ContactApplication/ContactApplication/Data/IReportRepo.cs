namespace ContactApplication.Data
{
    public interface IReportRepo
    {
        void CreateReportDetail(Guid reportId, byte[] file);
        bool IsReportExist(Guid reportId);
        void UpdateReportStatus(Guid reportId);
    }
}
