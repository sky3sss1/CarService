namespace Application.Templates
{
    public record UpdateFloorRequest
    (
        Guid Id,
        int FloorNumber
    );
}