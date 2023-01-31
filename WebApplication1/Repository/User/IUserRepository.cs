namespace WebApplication1.Repository.User
{
    public interface IUserRepository
    {
        Model.User GetById(int id);
        List<Model.User> GetAll();
        Model.User Create(Model.User city);
        Model.User Authenticate(string userName, string password);
        string EncodePassword(string password);
        string DecodePassword(string password);

    }
}
