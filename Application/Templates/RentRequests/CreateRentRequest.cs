namespace Application.Templates
{
    public record CreateRentRequest
    (
        Guid User_Id,
        Guid Parking_Id,
        Guid Car_Id,
        Guid Payment_Id,
        DateTime Start_Date,
        DateTime End_Date,
        int LosedDays
    );
}