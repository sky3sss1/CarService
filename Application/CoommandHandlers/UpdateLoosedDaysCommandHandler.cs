namespace Application.CommandHandlers
{
    public class UpdateLoosedDaysCommandHandler : IRequestHandler<UpdateLoosedDaysCommand>
    {
        private readonly IRentRepository _repository;

        public UpdateLoosedDaysCommandHandler(IRentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Unit> Handle(UpdateLoosedDaysCommand request, CancellationToken cancellationToken)
        {
            var allRents = await _repository.GetAll();

            foreach (var rent in allRents)
            {
                if (rent.End_Date < DateTime.Today)
                {
                    var loosedDays = (int)(DateTime.Today.Date - rent.End_Date.Date).TotalDays;

                    rent.LosedDays = loosedDays;

                    await _repository.Update(rent);
                }
            }

            return Unit.Value;
        }
    }
}