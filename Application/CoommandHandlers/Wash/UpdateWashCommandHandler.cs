namespace Application.CommandHandlers
{
    public class UpdateWashCommandHandler : IRequestHandler<UpdateWashCommand, bool>
    {
        private readonly IWashRepository _repository;
        private readonly IMediator _mediator;

        public UpdateWashCommandHandler(IWashRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateWashCommand command, CancellationToken cancellationToken)
        {
            var wash = await _repository.GetById(command.Id);

            if (wash == null) return false;

            wash.Price = command.Price;
            wash.Description = command.Description;

            _repository.Update(wash);

            return true;
        }
    }
}