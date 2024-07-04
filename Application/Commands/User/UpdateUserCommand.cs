namespace Application.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }

        public UpdateUserCommand(Guid id, string name, string email, string phone_Number)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone_Number = phone_Number;
        }
    }
}