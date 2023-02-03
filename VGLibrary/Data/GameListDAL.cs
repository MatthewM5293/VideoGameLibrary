using VGLibrary.Interfaces;
using VGLibrary.Models;

namespace VGLibrary.Data
{
    public class GameListDAL : IDataAccessLayer
    {

        //hardcoded game list
        private static List<Game> Gamelist = new List<Game>
        {
            new Game(0, "Gears Of War 3", "Xbox 360", "3rd Person", "Mature", 2011, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2a21.png", null, null),
            new Game(1, "Halo Infinite", "Xbox", "1st Person Shooter", "Teen", 2021, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2dto.png", null, null),
            new Game(2, "Doki Doki (DDLC)", "PC", "Visual Novel", "Mature", 2017, "https://images.igdb.com/igdb/image/upload/t_cover_big/sjz2xv4sjhi6qagbveau.png", null, null),
            new Game(3, "Minecraft: Java Edition", "PC", "Sandbox", "PC", 2009, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.png", null, null),
            new Game(4, "Fortnite: Save The World", "PC", "3rd Person", "Teen", 2017, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.png", null, null)
        };

        public void AddGame(Game game)
        {
            Gamelist.Add(game);
        }

        public void EditGame(Game game)
        {
            int i;
            i = GetGame(game);
            Gamelist[i] = game;
        }

        public Game GetGame(int? id)
        {
            //returns specific game
            return Gamelist.Where(M => M.Id == id).FirstOrDefault();
        }

        public int GetGame(Game game)
        {
            return Gamelist.FindIndex(x => x.Id == game.Id);
        }

        public IEnumerable<Game> GetGames()
        {
            return Gamelist;
        }

        public void RemoveGame(int? id)
        {
            Game foundGame = GetGame(id);
            Gamelist.Remove(foundGame);
        }
    }
}
