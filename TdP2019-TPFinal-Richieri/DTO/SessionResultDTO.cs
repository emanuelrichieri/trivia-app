using System;
namespace TdP2019TPFinalRichieri.DTO
{
    public class SessionResultDTO
    {
        public string Username { get; set; }
        public double Score { get; set; }
        public int Time { get; set; }
        public DateTime Date { get; set; }
        public SessionDTO Session { get; set; }
    }
}
