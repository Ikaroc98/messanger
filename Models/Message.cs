namespace messanger.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId {  get; set; }
        public Chat Chat { get; set; }
        public int AuthorId {  get; set; }
        public Account Author { get; set; }
        public string Text {  get; set; }
        public DateTime Datetime { get; set; }
    }
}
