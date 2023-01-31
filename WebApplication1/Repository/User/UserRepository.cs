using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;

namespace WebApplication1.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.User> entities;

        public UserRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.User>();
        }

        public Model.User Authenticate(string userName, string password)
        {
            return dbContext.User.FirstOrDefault(x => x.Name == userName && x.Password == password);
        }

        public Model.User Create(Model.User user)
        {
            this.dbContext.Add(user);
            this.dbContext.SaveChanges();
            return user;
        }

        public List<Model.User> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.User GetById(int id)
        {
            return entities.Find(id);
        }

       public  string EncodePassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public string DecodePassword(string password)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
