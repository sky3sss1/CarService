namespace Application.Templates
{
    public record CreateParkingRequest
    (
        Guid Floor_Id,
        Guid Place_Id
    );
}