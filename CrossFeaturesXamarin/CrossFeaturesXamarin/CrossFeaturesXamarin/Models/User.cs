using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossFeaturesXamarin.Models
{
    public class User
    {
        public string ObjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public File UserPicture { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //For sorting items
        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name) || Name.Length == 0) return "?";
                return Name[0].ToString().ToUpper();
            }
        }

        public string ProfilePicture
        {
            get
            {
                if (UserPicture == null)
                {
                    return "item_person_placeholder.jpg";
                }
                else
                {
                    return UserPicture.Url;
                }
            }
        }
    }
}
