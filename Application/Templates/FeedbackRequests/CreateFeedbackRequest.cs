namespace Application.Templates
{
    public record CreateFeedbackRequest
    (
        Guid User_Id,
        string Text
    );
}
