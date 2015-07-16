using CrossFeaturesXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossFeaturesXamarin.Services
{
    public interface IParseService
    {
        //Security
        bool IsLoggedIn();
        Task<bool> Signup(User user);
        //Task<bool> LoginWithFacebook(string userId, string accessToken, DateTime tokenExpiration);
        Task<bool> Login(string username, string password);
        Task ResetPassword();
        void Logout();
        User GetActiveUser();
        Task<List<User>> GetUsers();
    }
}
