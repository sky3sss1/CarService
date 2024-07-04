namespace Application.Commands
{
    public class CreatePaymentCommand : IRequest<bool>
    {
        public bool FromStart;
        public Guid Tarif_Id { get; set; }
        public CreatePaymentCommand(bool fromStart, Guid tarif_Id)
        {
            FromStart = fromStart;
            Tarif_Id = tarif_Id;
        }
    }
}
