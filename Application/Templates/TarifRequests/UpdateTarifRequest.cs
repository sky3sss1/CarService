namespace Application.Templates
{
    public record UpdateTarifRequest
    (
        Guid Id,
        string Name,
        int Cost
    );
}