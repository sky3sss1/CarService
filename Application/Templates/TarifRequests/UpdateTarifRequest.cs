namespace Application.Templates
{
    public record UpdateTarifRequest
    (
        Guid Id,
        Guid Wash_Id,
        string Name,
        int Cost,
        int CostIfLoosed
    );
}