namespace Application.Commands
{
    public class CreateFeedbackCommand : IRequest<bool>
    {
        public Guid User_Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public CreateFeedbackCommand(Guid user_Id, string text)
        {
            User_Id = user_Id;
            Text = text;
        }
    }
}
