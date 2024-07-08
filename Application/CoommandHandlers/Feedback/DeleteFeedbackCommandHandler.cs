namespace Application.CoommandHandlers
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, bool>
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMediator _mediator;

        public DeleteFeedbackCommandHandler(IFeedbackRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(DeleteFeedbackCommand command, CancellationToken cancellationToken)
        {
            var feedback = await _repository.GetById(command.Id);

            if (feedback == null) return false;

            await _repository.Delete(feedback);

            return true;
        }
    }
}
