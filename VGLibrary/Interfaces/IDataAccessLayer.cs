using VGLibrary.Models;
using System.Collections.Generic;

namespace VGLibrary.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Game> GetGames();

        void AddGame(Game game);

        void RemoveGame(int? id);

        void EditGame(Game game);

        Game GetGame(int? id);

        //int GetGame(Game game);

        IEnumerable<Game> FilterCollection(string genre, string platform, string esrbRating);
    }
}
