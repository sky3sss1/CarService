namespace Application.Templates
{
    public record UpdatePlaceRequest
    (
        Guid Id,
        bool Is_Charge,
        int Voltage
    );
}