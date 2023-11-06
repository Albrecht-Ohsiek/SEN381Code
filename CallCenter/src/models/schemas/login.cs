namespace CallCenter.Models
{
    public class Login
	{
        private Guid employeeId;
        private string username;
        private string password;
        public Login()
        {

        }

        public Guid EmployeeId { get => employeeId; set => employeeId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}

