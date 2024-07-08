namespace Application.CommandHandlers
{
    public class UpdateTarifCommandHandler : IRequestHandler<UpdateTarifCommand, bool>
    {
        private readonly ITarifRepository _repository;
        private readonly IMediator _mediator;

        public UpdateTarifCommandHandler(ITarifRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateTarifCommand command, CancellationToken cancellationToken)
        {
            var tarif = await _repository.GetById(command.Id);
            if (tarif == null) return false;
            tarif.Wash_Id = command.Wash_Id;
            tarif.Name = command.Name;
            tarif.Cost = command.Cost;
            tarif.CostIfLoosed = command.CostIfLoosed;
            _repository.Update(tarif);
            return true;
        }
    }
}