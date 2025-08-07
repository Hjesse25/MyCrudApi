using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private static List<Game> games = new List<Game>
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
    public ActionResult<List<Game>> Get()
    {
        return Ok(games);
    }

    [HttpGet("{id}")]
    public ActionResult<List<Game>> GetById(int id)
    {
        if (id < 0 || id >= games.Count)
        {
            return NotFound();
        }
        else
        {
            var game = games[id];
            return Ok(game);
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Game newGame)
    {
        games.Add(newGame);
        return Ok(newGame);
    }

    [HttpPut("{id}")]
    public ActionResult<List<Game>> Put(int id, [FromBody] Game updatedGame)
    {
        if (id < 0 || id >= games.Count)
        {
            return NotFound();
        }
        else
        {
            var game = games[id];

            game.Id = updatedGame.Id;
            game.Title = updatedGame.Title;
            game.Price = updatedGame.Price;

            return NoContent();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<List<Game>> Delete(int id)
    {
        if (id < 0 || id >= games.Count)
        {
            return NotFound();
        }
        else
        {
            games.RemoveAt(id);
            return NoContent();
        }
    }

}