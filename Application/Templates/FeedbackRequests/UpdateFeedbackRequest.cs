namespace Application.Templates
{
    public record UpdateFeedbackRequest
    (
        Guid Id,
        Guid User_Id,
        string Text
    );
}
