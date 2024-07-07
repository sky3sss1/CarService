namespace Application.Templates
{
    public record CreateTarifRequest
    (
        Guid Wash_id,
        string Name,
        int Cost
    );
}
