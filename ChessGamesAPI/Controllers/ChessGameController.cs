using ChessGamesAPI.Interfaces;
using ChessGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessGamesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessGameController : Controller
    {
        private readonly IChessDbCommunicator _communicator;

        public ChessGameController(IChessDbCommunicator communicator)
        {
            _communicator = communicator;
        }

        [HttpGet]
        public async Task<ActionResult<ChessGameDto>> GetRandomChessGame()
        {
            ChessGameDto chessGameDto = await _communicator.GetChessGame();
            return Ok(chessGameDto);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<ChessGameDto>>> GetAllChessGames()
        {
            List<ChessGameDto> allGames = await _communicator.GetAllChessGames();
            return Ok(allGames);
        }

        [HttpGet]
        [Route("{lastName}")]
        public async Task<ActionResult<List<ChessGameDto>>> GetChessGamesByLastName([FromRoute] string lastName)
        {
            List<ChessGameDto> allGames = await _communicator.getAllChessGamesByLastName(lastName);
            return Ok(allGames);
        }

        [HttpGet]
        [Route("players")]
        public async Task<ActionResult<List<string>>> GetPlayers()
        {
            List<string> relevantPlayers = await _communicator.GetRelevantPlayers();
            return Ok(relevantPlayers);
        }
    }
}
