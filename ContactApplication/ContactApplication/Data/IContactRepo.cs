namespace ContactApplication.Data
{
    public interface IContactRepo : IPersonRepo, IContactInformationRepo, IReportRepo
    {
        //bool SaveChanges();
    }
}
