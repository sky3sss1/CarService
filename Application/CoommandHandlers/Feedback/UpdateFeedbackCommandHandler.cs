namespace Application.CoommandHandlers
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, bool>
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMediator _mediator;

        public UpdateFeedbackCommandHandler(IFeedbackRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateFeedbackCommand command, CancellationToken cancellationToken)
        {
            var feedback = await _repository.GetById(command.Id);

            if (feedback == null) return false;

            feedback.User_Id = command.User_Id;
            feedback.Text = command.Text;

            _repository.Update(feedback);

            return true;
        }
    }
}
