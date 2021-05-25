using GameLibraryPt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryPt1.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Game> GetCollection(string userid);
        IEnumerable<Game> SearchForGames(string key, string genre, string platform, string esrbRating, string userid);
        void AddGame(Game game);
        void DeleteGame(int id, string userid);

        Game getGame(int id, string userid);

        void updateGame(Game game);
    }
}
