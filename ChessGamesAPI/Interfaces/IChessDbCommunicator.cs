using ChessGamesAPI.Data;
using ChessGamesAPI.Models;

namespace ChessGamesAPI.Interfaces
{
    public interface IChessDbCommunicator
    {
        public Task<ChessGameDto> GetChessGame();
        public Task<List<ChessGameDto>> GetAllChessGames();
        public Task<List<ChessGameDto>> getAllChessGamesByLastName(string lastName);
        public Task<List<string>> GetRelevantPlayers();
    }
}
