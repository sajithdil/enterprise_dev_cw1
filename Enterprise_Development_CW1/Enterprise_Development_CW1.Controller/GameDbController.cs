using Enterprise_Development_CW1.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Development_CW1.Controller
{
    public class GameDbController
    {
        public void SaveGame(GameData GameData)
        {
            using (ConverterGameDBEntities entities = new ConverterGameDBEntities())
            {
                var usernamesDbList = from u in entities.Usernames
                                where u.Username == GameData.Username
                                select u;

                Usernames username;
                bool exist = false;
                if (usernamesDbList.ToArray().Length >0)
                {
                    exist = true;
                    username = usernamesDbList.ToArray()[0];
                }
                else
                {
                    exist = false;
                    username = new Usernames()
                    {
                        Username = GameData.Username
                    };
                }
                

                int lastId = entities.Games.ToArray().Length;
                Game game = new Game()
                {
                    Username = username,
                    Id = lastId + 1
                };
                
                username.Games.Add(game);

                int lastGameId = entities.GameDatas.ToArray().Length;
                Collection<Enterprise_Development_CW1.DB.GameData> gameData = new Collection<DB.GameData>();
                foreach (GameState state in GameData.GameStates)
                {
                    lastGameId++;
                    string fromType = "";
                    string toType = "";
                    switch (state.From)
                    {
                        case ValueType.Decimal:
                            fromType = "Decimal";
                            break;
                        case ValueType.Binary:
                            fromType = "Binary";
                            break;
                        case ValueType.Hexadecimal:
                            fromType = "Hexadecimal";
                            break;
                        default:
                            fromType = "";
                            break;
                    }

                    switch (state.To)
                    {
                        case ValueType.Decimal:
                            toType = "Decimal";
                            break;
                        case ValueType.Binary:
                            toType = "Binary";
                            break;
                        case ValueType.Hexadecimal:
                            toType = "Hexadecimal";
                            break;
                        default:
                            toType = "";
                            break;
                    }
                    gameData.Add(new DB.GameData()
                    {
                        FromType = fromType,
                        ToType = toType,
                        FromValue = state.FromVal,
                        ToValue = state.ToVal,
                        Game = game,
                        GameString = state.GameString,
                        Id = lastGameId
                    });
                }

                game.GameDatas = gameData;

                if (!exist)
                {
                    entities.Usernames.Add(username);
                }
                try {
                    entities.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

        public Collection<string> getAllUsernames()
        {
            Collection<string> usernames = new Collection<string>();

            using (ConverterGameDBEntities entities = new ConverterGameDBEntities())
            {
                foreach(Usernames name in entities.Usernames)
                {
                    usernames.Add(name.Username);
                }
            }

            return usernames;
        }

        public Collection<int> getGamesByUsername(string username)
        {
            Collection<int> gameList = new Collection<int>();
            using (ConverterGameDBEntities entities = new ConverterGameDBEntities())
            {
                var GameData = from u in entities.Games
                               where u.UserN == username
                               select u;

                foreach(Game g in GameData)
                {
                    gameList.Add(g.Id);
                }
            }

            return gameList;
        }

        public Collection<string> getGameDataByGameId(int id)
        {
            Collection<string> gameStrings = new Collection<string>();
            using (ConverterGameDBEntities entities = new ConverterGameDBEntities())
            {
                var gameData = from u in entities.GameDatas
                               where u.GameId == id
                               select u;
                foreach (Enterprise_Development_CW1.DB.GameData data in gameData)
                {
                    if(data.GameString == "" |data.GameString == null)
                    {
                        gameStrings.Add(Util.BuildScoringString(data.FromType, data.ToType, data.FromValue, data.ToValue));
                    }
                    else
                    {
                        gameStrings.Add(data.GameString);
                    }
                }
            }
            return gameStrings;
        }
    }
}
