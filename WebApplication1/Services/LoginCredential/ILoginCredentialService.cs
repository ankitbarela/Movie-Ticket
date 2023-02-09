namespace WebApplication1.Services.LoginCredential
{
    public interface ILoginCredentialService
    {
        Model.LoginCredential GetById(int id);
        List<Model.LoginCredential> GetAll();
        Model.LoginCredential Create(Model.LoginCredential loginCredential);
        Model.LoginCredential AddData(Model.User user);
        List<Model.LoginCredential> GetByEmail(string email);
    }
}
