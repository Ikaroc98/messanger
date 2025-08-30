namespace messanger.Models
{
    public class Chat
    {
        public int Id {  get; set; }
        public int FirstUserId {  get; set; }
        public Account FirstUser { get; set; }
        public int SecondUserId { get; set; }
        public Account SecondUser { get; set; }
        public string ChatName {  get; set; }
    }
}
