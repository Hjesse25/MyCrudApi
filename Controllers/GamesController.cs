using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    static private List<Game> games = new List<Game>
    {
        new Game
        {
            Id = 1,
            Title = "Mario Kart 8",
            Price = 49.99
        },
        new Game
        {
            Id = 2,
            Title = "Super Smash Bros Ultimate",
            Price = 69.99
        }
    };

    [HttpGet]
    public ActionResult<List<Game>> GetAllGames()
    {
        return Ok(games);
    }

    [HttpGet("{id}")]
    public ActionResult<List<Game>> GetGame(int id)
    {
        if (id < 0 || id >= games.Count)
            return NotFound("Invalid Id");

        var game = games[id];
        return Ok(game);
    }
}