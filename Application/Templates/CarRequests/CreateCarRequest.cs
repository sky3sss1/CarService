namespace Application.Templates
{
    public record CreateCarRequest
    (
        string GovernmentNumber,
        string Model,
        int MinimalVoltage
    );
}
