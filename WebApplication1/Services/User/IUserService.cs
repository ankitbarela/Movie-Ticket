namespace WebApplication1.Services.User
{
    public interface IUserService
    {
        Model.User GetById(int id);
        List<Model.User> GetAll();
        Model.User Create(Model.User user);
        Model.User Authenticate(string userName, string password);
        string EncodePassword(string password);
        Model.User Update(Model.User user);
        Model.User GetByEmail(string email);
    }
}
