using Enterprise_Development_CW1.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enterprise_Development_CW1.View
{
    public partial class Scores : Form
    {
        private string username;
        private int score = 0;
        private int life = 3;
        GameData gameData;
        Collection<GameState> gameStates;
        public Scores(string username)
        {
            InitializeComponent();

            Util.UpdateScoreEvent += new Util.ScoreUpdateHandler(HandleUpdateScore);
            Util.GameOverEvent += new Util.GameOverHandler(HandleGameOver);
            Util.GameStartEvent += new Util.GameStartHandler(HandleGameStart);
            Util.LostLifeEvent += new Util.LostLifeHandler(HandleLostLife);

            this.username = username;

            
        }

        private void HandleUpdateScore(ValueType from, ValueType to, string fromVal, string toVal)
        {
            //MessageBox.Show("Event Fired");
            score++;
            lblCurrentScore.Text = score.ToString();
            string scoreString = Util.BuildScoringString(from, to, fromVal, toVal);
            lstScoreHistory.Items.Add(scoreString);

            gameStates.Add(new GameState()
            {
                From = from,
                To = to,
                FromVal = fromVal,
                ToVal = toVal
                
            });
        }

        private void HandleGameOver()
        {
            //save all to db
            lstScoreHistory.Items.Add("Game Over");
            if(life!=0)
            {
                //incomplete game closed
                MessageBox.Show("Game closed before finishing. Score was not saved");
            }
            else
            {
                gameStates.Add(new GameState()
                {
                    GameString = "Game Over"
                });
                gameData.GameStates = gameStates;

                GameDbController dbController = new GameDbController();
                dbController.SaveGame(gameData);
            }
        }

        private void HandleGameStart()
        {
            score = 0;
            life = 3;
            lstScoreHistory.Items.Clear();
            lblCurrentScore.Text = score.ToString();
            lstScoreHistory.Items.Add("Game Start");

            gameData = new GameData();
            gameStates = new Collection<GameState>();

            gameData.Username = username;
            gameStates.Add(new GameState()
            {
                GameString = "Game Start"
            });
        }

        private void HandleLostLife()
        {
            life--;
            lstScoreHistory.Items.Add("Lost Life");
            gameStates.Add(new GameState()
            {
                GameString = "Lost Life"
            });
        }
    }
    
}
