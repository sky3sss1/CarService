namespace Application.Templates
{
    public record CreateCarRequest
    (
        Guid UserId,
        string GovernmentNumber,
        string Model,
        int MinimalVoltage
    );
}
