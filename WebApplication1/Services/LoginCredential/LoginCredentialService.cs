using WebApplication1.Model;
using WebApplication1.Repository.LoginCredential;

namespace WebApplication1.Services.LoginCredential
{
    public class LoginCredentialService : ILoginCredentialService
    {
        private readonly ILoginCredentialRepository loginCredentialRepository;

        public LoginCredentialService(ILoginCredentialRepository loginCredentialRepository)
        {
            this.loginCredentialRepository = loginCredentialRepository;
        }
        public Model.LoginCredential AddData(Model.User user)
        {
            var credential = loginCredentialRepository.AddData(user);
            return credential;
        }

        public Model.LoginCredential Create(Model.LoginCredential loginCredential)
        {
            loginCredential.CreatedBy = 1;
            loginCredential.UpdatedBy = 1;
            loginCredential.CreatedAt = DateTime.Now;
            loginCredential.UpdatedAt = DateTime.Now;
            loginCredential.IsActive = true;
            var Credential = loginCredentialRepository.Create(loginCredential);
            return Credential;
        }

        public List<Model.LoginCredential> GetAll()
        {
            var credentials = loginCredentialRepository.GetAll();
            return credentials;
        }

        public List<Model.LoginCredential> GetByEmail(string email)
        {
            var credential = loginCredentialRepository.GetByEmail(email);
            return credential;
        }

        public Model.LoginCredential GetById(int id)
        {
            var credential = loginCredentialRepository.GetById(id);
            return credential;
        }
    }
}
