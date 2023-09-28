namespace ChessGamesAPI.Models
{
    public class ChessGameDto
    { 
        public string White { get; set; }
        public string Black { get; set; }
        public string Result { get; set; }
        public string Date { get; set; }
        public string Game { get; set; }
        public string Site { get; set; }
        public string Event { get; set; }
        public string Round { get; set; }

        public ChessGameDto(ChessGame chessGame)
        {
            this.White = chessGame.White;
            this.Black = chessGame.Black;
            this.Result = chessGame.Result;
            this.Game = chessGame.Game; 
            this.Site = chessGame.Site;
            this.Event = chessGame.Event;
            this.Date = chessGame.Date;
            this.Round = chessGame.Round;
        }
    }
}
