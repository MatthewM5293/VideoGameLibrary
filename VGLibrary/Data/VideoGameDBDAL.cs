using VGLibrary.Interfaces;
using VGLibrary.Models;

namespace VGLibrary.Data
{
    public class VideoGameDBDAL : IDataAccessLayer
    {

        ////hardcoded game list
        //private static List<Game> Gamelist = new List<Game>
        //{
        //    new Game(0, "Gears Of War 3", "Xbox 360", "3rd Person", "Mature", 2011, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2a21.png", null, null),
        //    new Game(1, "Halo Infinite", "Xbox", "1st Person Shooter", "Teen", 2021, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2dto.png", null, null),
        //    new Game(2, "Doki Doki (DDLC)", "PC", "Visual Novel", "Mature", 2017, "https://images.igdb.com/igdb/image/upload/t_cover_big/sjz2xv4sjhi6qagbveau.png", null, null),
        //    new Game(3, "Minecraft: Java Edition", "PC", "Sandbox", "PC", 2009, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.png", null, null),
        //    new Game(4, "Fortnite: Save The World", "PC", "3rd Person", "Teen", 2017, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.png", null, null)
        //};

        private VideoGameDBContext db;
        public VideoGameDBDAL(VideoGameDBContext indb)
        {
            db = indb;
        }

        public void AddGame(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges();
        }

        public void EditGame(Game game)
        {
            db.Games.Update(game);
            db.SaveChanges();
        }

        public Game GetGame(int? id)
        {
            return db.Games.Where(g => g.Id == id).FirstOrDefault();
        }

        //public int GetGame(Game game)
        //{
        //    return Gamelist.FindIndex(x => x.Id == game.Id);
        //}

        public IEnumerable<Game> GetGames()
        {
            //return db.Games.ToList();
            return db.Games.OrderBy(g => g.Title).ToList();
        }

        public void RemoveGame(int? id)
        {
            Game foundGame = GetGame(id);
            db.Games.Remove(foundGame);
            db.SaveChanges();
        }
        public IEnumerable<Game> FilterCollection(string genre, string platform, string esrbRating)
        {
            //simple fix
            if (genre == null) genre = String.Empty;
            if (esrbRating == null) esrbRating = String.Empty;
            if (platform == null) platform = String.Empty;

            if (genre == "" && esrbRating == "" && platform == "") return GetGames(); //returns if all empty

            IEnumerable<Game> lstGames = GetGames().Where(g=> (!String.IsNullOrEmpty(g.Genre) && g.Genre.ToLower().Contains(genre.ToLower()))).ToList();
            IEnumerable<Game> lstGames2 = lstGames.Where(g=> (!String.IsNullOrEmpty(g.Rating) && g.Rating.ToLower().Equals(esrbRating.ToLower()))).ToList();
            IEnumerable<Game> lstGames3 = lstGames2.Where(g=> (!String.IsNullOrEmpty(g.Platform) && g.Platform.ToLower().Contains(platform.ToLower()))).ToList();

            ////////not working as intended
            if (lstGames2.Count() == 0 && lstGames3.Count() == 0) return lstGames; //returns only genre
            if (lstGames3.Count() == 0 && lstGames.Count() == 0) return lstGames2; //returns genre and/or rating filtered

            return lstGames3; //returns all if all all full/platform
        }
    }
}
