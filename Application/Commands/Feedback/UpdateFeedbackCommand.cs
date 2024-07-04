namespace Application.Commands
{
    public class UpdateFeedbackCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public UpdateFeedbackCommand(Guid id, Guid user_Id, string text)
        {
            Id = id;
            User_Id = user_Id;
            Text = text;
        }
    }
}
