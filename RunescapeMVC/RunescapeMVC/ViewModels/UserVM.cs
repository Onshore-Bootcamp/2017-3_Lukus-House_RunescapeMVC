using RunescapeMVC.Models;
using RunescapeMVC_DAL.Models;
using System.Collections.Generic;

namespace RunescapeMVC.ViewModels
{
    public class UserVM
    {
        public UserVM()
        {
            User = new UserPO();
            Login = new LoginPO();
            AllUsers = new List<UserPO>();
        }

        public UserPO User { get; set; }

        public LoginPO Login { get; set; }

        public List<UserPO> AllUsers { get; set; }

        public string ErrorMessage { get; set; }
    }
}