namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone_Number { get; set; } = string.Empty;

        public User(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            Phone_Number = phoneNumber;
        }
        public User() { }
    }
}
