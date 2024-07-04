namespace Application.CommandHandlers
{
    public class GetAllFeedbacksCommandHandler : IRequestHandler<GetAllFeedbacksCommand, IEnumerable<Feedback>>
    {
        private readonly IFeedbackRepository _repository;

        public GetAllFeedbacksCommandHandler(IFeedbackRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Feedback>> Handle(GetAllFeedbacksCommand query, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}