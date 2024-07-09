namespace Application.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }

        public CreateUserCommand(string name, string email, string phone_Number)
        {
            Name = name;
            Email = email;
            Phone_Number = phone_Number;
        }
    }
}