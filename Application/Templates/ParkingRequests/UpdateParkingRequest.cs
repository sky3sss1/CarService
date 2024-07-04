namespace Application.Templates
{
    public record UpdateParkingRequest
    (
        Guid Id,
        Guid Floor_Id,
        Guid Place_Id
    );
}