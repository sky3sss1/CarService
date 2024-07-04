namespace Application.CoommandHandlers
{
    public class GetFeedbackByIdCommandHandler : IRequestHandler<GetFeedbackByIdCommand, Feedback>
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMediator _mediator;

        public GetFeedbackByIdCommandHandler(IFeedbackRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Feedback> Handle(GetFeedbackByIdCommand command, CancellationToken cancellationToken)
        {
            var feedback = await _repository.GetById(command.Id);

            return feedback;
        }
    }
}
