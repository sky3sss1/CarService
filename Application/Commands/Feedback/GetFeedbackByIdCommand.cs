namespace Application.Commands
{
    public class GetFeedbackByIdCommand : IRequest<Feedback>
    {
        public Guid Id { get; set; }
        public GetFeedbackByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
