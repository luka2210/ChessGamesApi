namespace ChessGamesAPI.Models
{
    public class ChessGame
    {
        public int Id { get; set; } 
        public string White { get; set; }
        public string Black { get; set; }
        public string Result { get; set; }
        public string Date { get; set; }
        public string Game { get; set; }
        public string Site { get; set; }
        public string Event { get; set; }
        public string Round { get; set; }
    }
}
