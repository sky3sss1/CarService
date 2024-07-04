namespace Application.Templates
{
    public record UpdateCarRequest
    (
        Guid Id,
        string GovernmentNumber,
        string Model,
        int MinimalVoltage
    );
}