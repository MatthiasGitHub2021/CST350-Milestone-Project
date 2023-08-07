using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CST350_Milestone1.Models
{
    public class UserModel
    {
        public UserModel(string firstName, string lastName, string sex, int age, string state, string emailAddress, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            Age = age;
            State = state;
            EmailAddress = emailAddress;
            UserName = userName;
            Password = password;
        }

        public UserModel() { }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string State { get; set; }

        [DisplayName("Email")]
        //Contains @, no spaces, ., spaces at end okay 
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid Email address")]
        public string EmailAddress { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
