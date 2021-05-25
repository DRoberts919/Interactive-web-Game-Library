using GameLibraryPt1.Interfaces;
using GameLibraryPt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryPt1.Data
{
    public class GameControllerDAL : IDataAccessLayer
    {

        private VideoGameContext _db;
        

        public GameControllerDAL(VideoGameContext db)
        {
            this._db = db;
        }

        public void AddGame(Game game )
        {
            

            _db.Add(game);
            _db.SaveChanges();
            //GameList.Add(game);
        }

       

        public void DeleteGame(int id,string userId)
        {
            var foundGame = getGame(id,userId);

            if(foundGame != null)
            {
                _db.Remove(foundGame);
                _db.SaveChanges();
            }
        }


        public Game getGame(int id,string userid)
        {
            return _db.Games.Where(g => g.Id == id && g.UserId == userid).FirstOrDefault();
        }

        public IEnumerable<Game> GetCollection(string userid)
        {
            return _db.Games.Where(g => g.UserId == userid);
        }

        public IEnumerable<Game> SearchForGames(string key, string genre, string platform, string esrbRating,string userid)
        {
            var allGames = GetCollection(userid);

            if (!String.IsNullOrWhiteSpace(key))
            {
                allGames = allGames.Where(p => p.Title.ToLower().Contains(key.ToLower())).ToList();
            }

            if (!String.IsNullOrWhiteSpace(genre))
            {
                allGames = allGames.Where(g => g.Genre.ToLower() == genre.ToLower());
            }

            if (!String.IsNullOrWhiteSpace(platform))
            {
                allGames = allGames.Where(g => g.Platform.ToLower() == platform.ToLower());
            }

            if (!String.IsNullOrWhiteSpace(esrbRating))
            {
                allGames = allGames.Where(g => g.Rating.ToLower() == esrbRating.ToLower());
            }

            return allGames;
        }

      

        public void updateGame(Game game)
        {
            _db.Games.Update(game);
            _db.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            throw new NotImplementedException();
        }
    }
}
