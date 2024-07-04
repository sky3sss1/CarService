namespace Domain.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid User_Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public Feedback(Guid user_Id, string text)
        {
            User_Id = user_Id;
            Text = text;
        }
        public Feedback() { }
    }
}
