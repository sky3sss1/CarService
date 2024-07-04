namespace Application.Templates
{
    public record UpdateCarRequest
    (
        Guid Id,
        Guid UserId,
        string GovernmentNumber,
        string Model,
        int MinimalVoltage
    );
}