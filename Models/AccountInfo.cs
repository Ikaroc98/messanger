namespace messanger.Models
{
    public class AccountInfo
    {
        public int Id {  get; set; }
        public int Accountid {  get; set; }
        public Account Account { get; set; }
        public string Name {  get; set; }
        public string Surname { get; set; }
        public DateOnly Birth {  get; set; }
       
    }
}
