namespace CallCenter.Models
{
    public class Login
	{
        public Guid EmployeeId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public Login()
        {

        }

    }
}

