using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using CrossFeaturesXamarin.Services;
using CrossFeaturesXamarin.Models;
using Parse;
using CrossFeaturesXamarin.Models;

[assembly:Dependency(typeof(CrossFeaturesXamarin.Droid.Services.ParseService))]
namespace CrossFeaturesXamarin.Droid.Services
{
    public class ParseService : IParseService
    {
        public Models.User GetActiveUser()
        {
            var user = new User();
            user.ObjectId = ParseUser.CurrentUser.ObjectId;
            user.Email = ParseUser.CurrentUser.Email;
            user.Username = ParseUser.CurrentUser.Username;
            var name = string.Empty;
            ParseUser.CurrentUser.TryGetValue("Name", out name);
            user.Name = name;
            var birth = new DateTime(2000, 1, 1);
            ParseUser.CurrentUser.TryGetValue("BirthDate", out birth);
            user.BirthDate = birth;
            try
            {
                var file = ParseUser.CurrentUser.Get<ParseFile>("UserPicture");
                var userPicture = new File
                {
                    Name = "profile.jpg",
                    Url = file.Url.AbsoluteUri
                };
                user.UserPicture = userPicture;
            }
            catch (Exception ex)
            {
                //Do nothing
            }
            return user;
        }

        public async System.Threading.Tasks.Task<List<Models.User>> GetUsers()
        {
            try
            {
                var results = await ParseUser.Query.FindAsync();
                var users = new List<Models.User>();
                foreach (var item in results.ToList())
                {
                    Models.User user = new Models.User();
                    user.Username = item.Username;
                    user.Name = item.Get<string>("Name"); 
                    user.Email = item.Email;
                    user.ObjectId = item.ObjectId;
                    ParseFile file;
                    item.TryGetValue<ParseFile>("ProfilePicture", out file);
                    user.UserPicture = new CrossFeaturesXamarin.Models.File();
                    user.UserPicture.Name = file.Name;
                    user.UserPicture.Url = file.Url.ToString();
                    users.Add(user);
                }
                return users;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool IsLoggedIn()
        {
            return ParseUser.CurrentUser != null;
        }

        public async System.Threading.Tasks.Task<bool> Login(string username, string password)
        {
            try
            {
                await ParseUser.LogInAsync(username, password);
            }
            catch (InvalidOperationException inv)
            {
                Console.WriteLine(inv.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // If current Parse user is assigned tje login was successful
            return ParseUser.CurrentUser != null;
        }

        public void Logout()
        {
            ParseUser.LogOut();
        }

        public async System.Threading.Tasks.Task ResetPassword()
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<bool> Signup(Models.User newUser)
        {
            try
            {
                var user = new ParseUser()
                {
                    Email = newUser.Email,
                    Username = newUser.Email,
                    Password = newUser.Password
                };
                user.Add("Name", newUser.Name);
                await user.SignUpAsync();
            }
            catch (ParseException pex)
            {
                Console.WriteLine(pex.Message);
            }
            catch (InvalidOperationException inv)
            {
                Console.WriteLine(inv.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return IsLoggedIn();
        }
    }
}