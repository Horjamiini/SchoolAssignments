using SHAA3209;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAA3209
{
    public class Playstation : ICanPlayGame
    {
        private List<Game> _games;
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public bool Controller { get; set; }
        public List<Game> Games { get { return _games; } }
        public Playstation(string name, string manufacturer, bool controller)
        {
            Name = name;
            Manufacturer = manufacturer;
            Controller = controller;
            _games = new List<Game>();
        }
        public string StartGame(Game game)
        {
            if (Games.Contains(game))
            {
                if (game.SaveState > 0)
                {
                    game.RecordCurrentlyPlaying();
                    return $"You have a save in {game.Name}  ...Loading save...";
                }
                else
                {
                    game.RecordPlaying();
                    game.RecordCurrentlyPlaying();
                    return $"Starting {game.Name}";
                }
            }
            else
            {
                return $"You do not own {game.Name}, couldn't be started!";
            }
        }
        public string SaveGame(Game game)
        {
            if (game.CurrentlyPlaying)
            {
                if (game.SaveState > 3)
                {
                    return $"Couldn't save the game {game.Name}, disk space not enough!";
                }
                else
                {
                    game.RecordPlaying();
                    return $"Saving game {game.Name}";
                }
            }
            else
            {
                return $"You aren't currenlty playing the game you are trying to save!";
            }
        }
        public string QuitGame(Game game)
        {
            if (game.CurrentlyPlaying)
            {
                game.RecordCurrentlyPlaying();
                return $"Quitting game {game.Name}";
            }
            else
            {
                return $"You are not currently playing the game you are trying to quit!";
            }
        }
        public override string ToString()
        {
            return $"{Name} from {Manufacturer}\nHas Controller: {Controller}\nHas games:";
        }
    }
}
