namespace Application.Templates
{
    public record CreateRentRequest
    (
        Guid Parking_Id,
        Guid Car_Id,
        Guid Payment_Id,
        DateTime Start_Date,
        DateTime End_Date,
        int LosedDays
    );
}