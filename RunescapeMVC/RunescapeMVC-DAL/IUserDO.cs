namespace RunescapeMVC_DAL
{
    public interface IUserDO
    {
        long UserID { get; set; }

        string UserName { get; set; }

        string Password { get; set; }

        int Role { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
