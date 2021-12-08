using BatchApp.IService;

namespace BatchApp.Service
{
    public class UserService : IUserService
    {
        public bool CheckUser(string username, string password)
        {
            return username.Equals("sanyogita") && password.Equals("123");
        }
    }
}
