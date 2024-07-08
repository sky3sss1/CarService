namespace Application.CoommandHandlers
{
    public class GetTarifPriceByIdCommandHandler : IRequestHandler<GetTarifPriceByIdCommand, int>
    {
        private readonly ITarifRepository _repository;
        private readonly IWashRepository _washRepository;
        private readonly IMediator _mediator;

        public GetTarifPriceByIdCommandHandler(IWashRepository washRepository, ITarifRepository repository, IMediator mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _washRepository = washRepository ?? throw new ArgumentNullException(nameof(washRepository));
        }
        public async Task<int> Handle(GetTarifPriceByIdCommand command, CancellationToken cancellationToken)
        {
            var tarif = await _repository.GetById(command.Id);
            try
            {
                var wash = await _washRepository.GetById(tarif.Wash_Id);
                return tarif.Cost + wash.Price;
            }
            catch
            {
                return tarif.Cost;
            }
        }
    }
}
