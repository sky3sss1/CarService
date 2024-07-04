namespace Application.Templates
{
    public record UpdateUserRequest
    (
        Guid Id,
        string Name,
        string Email,
        string Phone_Number
    );
}