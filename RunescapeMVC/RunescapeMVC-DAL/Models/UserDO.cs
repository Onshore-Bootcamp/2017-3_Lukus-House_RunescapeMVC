namespace RunescapeMVC_DAL.Models
{
    public class UserDO : IUserDO
    {
        public long UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
