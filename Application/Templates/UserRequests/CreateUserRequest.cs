namespace Application.Templates
{
    public record CreateUserRequest
    (
        string Name,
        string Email,
        string Phone_Number
    );
}