using Microsoft.AspNetCore.Mvc;
using Modul10_103022400002;
namespace Modul10_103022400002
{
    [Route("api/[controller]")]
    [ApiController]
    public class gameController : ControllerBase
    {
        private static List<Game> games = new List<Game>
        {
            new Game { id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = ["PC"], Mode = ["Multiplayer"], IsOnline = true, Harga = 0 },
            new Game { id = 2, Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, Platform = ["PC", "PS4", "PS5", "Xbox"], 
                Mode = ["Single Player" , "Multiplayer"], IsOnline = true, Harga = 3000000 },
            new Game { id = 3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform = ["PC", "PS4", "PS5", "Xbox", "Switch"], 
                Mode = ["Single Player"], IsOnline = false, Harga = 250000 }

        };

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return games;
        }
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            if (id == 0 || id >= games.Count)
                return NotFound();

            return games[id];
        }

        [HttpPost]
        public ActionResult<List<Game>> AddGames(Game game)
        {
            games.Add(game);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id) 
            {
                if(id <  0 || id >= games.Count || games[id] == null) 
                return NotFound();

                games.RemoveAt(id);
                    return Ok();
            }
        [HttpPut]
        public ActionResult Put(int id, Game game)
        {
            games[id] = game;
            return Ok();
        }
    }
}
