namespace Application.Templates
{
    public record UpdatePaymentRequest
    (
        Guid Id,
        bool FromStart,
        Guid Tarif_Id
    );
}