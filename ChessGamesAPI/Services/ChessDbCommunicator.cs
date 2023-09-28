using ChessGamesAPI.Data;
using ChessGamesAPI.Interfaces;
using ChessGamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessGamesAPI.Services
{
    public class ChessDbCommunicator: IChessDbCommunicator
    {
        private ChessDbContext chessDbContext;

        public ChessDbCommunicator(ChessDbContext chessDbContext)
        {
            this.chessDbContext = chessDbContext;
        }

        public async Task<ChessGameDto> GetChessGame()
        {
            List<ChessGame> allGames = await chessDbContext.chessGames.ToListAsync();
            Random random = new Random();
            ChessGame randomGame = allGames[random.Next(allGames.Count)];
            ChessGameDto randomGameDto = new ChessGameDto(randomGame);
            return randomGameDto;
        }

        public async Task<List<ChessGameDto>> GetAllChessGames()
        {
            List<ChessGame> allGames = await chessDbContext.chessGames.ToListAsync();
            List<ChessGameDto> allGamesDto = new List<ChessGameDto>(allGames.Count);
            foreach (ChessGame game in allGames)
                allGamesDto.Add(new ChessGameDto(game));
            return allGamesDto;
        }

        public async Task<List<ChessGameDto>> getAllChessGamesByLastName(string lastName)
        {
            List<ChessGameDto> allGames = await GetAllChessGames();
            List<ChessGameDto> allGamesByLastName = new List<ChessGameDto>();
            foreach (ChessGameDto game in allGames)
            {
                string lastNameWhite = game.White.Split(',')[0];
                string lastNameBlack = game.Black.Split(',')[0];
                if (lastNameWhite.Equals(lastName) || lastNameBlack.Equals(lastName))
                    allGamesByLastName.Add(game);
            }
            return allGamesByLastName;
        }

        public async Task<List<string>> GetRelevantPlayers()
        {
            List<ChessGameDto> allGames = await GetAllChessGames();

            Dictionary<string, int> playersDictionary = new Dictionary<string, int>();
            foreach (ChessGameDto game in allGames)
            {
                updateDictionary(playersDictionary, game.White.Split(',')[0]);
                updateDictionary(playersDictionary, game.Black.Split(',')[0]);
            }
            
            List<string> relevantPlayers = new List<string>();
            foreach (string key in playersDictionary.Keys)
                if (playersDictionary[key] > 1500)
                    relevantPlayers.Add(key);

            return relevantPlayers;
        }

        private void updateDictionary(Dictionary<string, int> playersDictionary, string player)
        {
            if (playersDictionary.ContainsKey(player))
                playersDictionary[player] = playersDictionary[player] + 1;
            else
                playersDictionary[player] = 1;
        }
    }
}
