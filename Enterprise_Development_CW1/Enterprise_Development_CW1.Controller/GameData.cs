using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Development_CW1.Controller
{
    public class GameData
    {
        public string Username { set; get; }

        public Collection<GameState> GameStates { set; get; }
    }
}
