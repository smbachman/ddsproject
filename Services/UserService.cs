using DDSProject.Interfaces;

namespace DDSProject.Services 
{
    public class UserService : IUserService
    {
        public bool IsValidUser(string username, string password)
        {
            return username == "scott" && password == "tiger";
        }
    }
}