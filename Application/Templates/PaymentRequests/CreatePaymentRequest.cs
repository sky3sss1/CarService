namespace Application.Templates
{
    public record CreatePaymentRequest
    (
        bool FromStart,
        Guid Tarif_Id
    );
}