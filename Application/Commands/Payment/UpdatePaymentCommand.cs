namespace Application.Commands
{
    public class UpdatePaymentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public bool FromStart;
        public Guid Tarif_Id { get; set; }
        public UpdatePaymentCommand(Guid id, bool fromStart, Guid tarif_Id)
        {
            Id = id;
            FromStart = fromStart;
            Tarif_Id = tarif_Id;
        }
    }
}
