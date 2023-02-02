namespace WebApplication1.Repository.LoginCredential
{
    public interface ILoginCredential
    {
        Model.LoginCredential GetById(int id);
        List<Model.LoginCredential> GetAll();
        Model.LoginCredential Create(Model.LoginCredential loginCredential);
        Model.LoginCredential AddData(Model.User user);
        List<Model.LoginCredential> GetByEmail(string email);
    }
}
