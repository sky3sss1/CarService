namespace Application.Templates
{
    public record UpdateWashRequest
    (
        Guid Id,
        int Price,
        string Description
    );
}