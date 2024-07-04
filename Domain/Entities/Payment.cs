namespace Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool FromStart;
        public Guid Tarif_Id;

        public Payment(bool fromStart, Guid tarif_Id)
        {
            FromStart = fromStart;
            Tarif_Id = tarif_Id;
        }
        public Payment()
        {
        }
    }
}
