namespace ContactApplication.Data
{
    public interface IContactRepo : IPersonRepo, IContactInformationRepo
    {
        //bool SaveChanges();
    }
}
