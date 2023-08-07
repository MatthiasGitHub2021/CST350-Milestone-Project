using CST350_Milestone1.Models;

namespace CST350_Milestone1.Services
{
    /* SecurityService: Used by LoginController to access SecurityDAO using UserModel. Provides encapsulation.
     * 
     */
    public class SecurityService
    {
        //Create SecurityDAO class 
        SecurityDAO securityDAO = new SecurityDAO();

        //Used by LoginController to verify is username and password match
        public bool IsValid(UserModel user)
        {
            return securityDAO.FindByUsernameAndPassword(user);
        }

        //Used by RegistrationController to register new user
        public bool AddNewUser(UserModel user)
        {
            return securityDAO.RegisterNewUser(user);
        }
    }
}
