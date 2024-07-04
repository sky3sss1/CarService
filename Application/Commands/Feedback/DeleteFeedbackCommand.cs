namespace Application.Commands
{
    public class DeleteFeedbackCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteFeedbackCommand(Guid id)
        {
            Id = id;
        }
    }
}
