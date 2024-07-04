namespace Application.CommandHandlers
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, bool>
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMediator _mediator;

        public CreateFeedbackCommandHandler(IFeedbackRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateFeedbackCommand command, CancellationToken cancellationToken)
        {
            var feedback = new Feedback(command.User_Id, command.Text);

            _repository.Add(feedback);

            return true;
        }
    }
}
