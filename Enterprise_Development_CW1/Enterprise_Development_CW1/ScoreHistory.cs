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
    public partial class ScoreHistory : Form
    {
        public ScoreHistory()
        {
            InitializeComponent();

            GameDbController db = new GameDbController();

            Collection<string> usernames = db.getAllUsernames();
            foreach(string s in usernames)
            {
                ListViewItem item = new ListViewItem();
                item.Text = s;
                item.Tag = s;
                lstUsernames.Items.Add(item);
            }
        }

        private void lstUsernames_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstGames.Items.Clear();
            String text = lstUsernames.SelectedItems[0].Text;
            GameDbController db = new GameDbController();
            Collection<int> gameIds = db.getGamesByUsername(text);

            for(int i = 0;i<gameIds.ToArray().Length;i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "Game"+i.ToString();
                item.Tag = gameIds.ToArray()[i];
                lstGames.Items.Add(item);
            }
        }

        private void lstGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstGameData.Items.Clear();
            int text = (int)lstGames.SelectedItems[0].Tag;
            GameDbController db = new GameDbController();
            Collection<string> gameStrings = db.getGameDataByGameId(text);

            foreach (string s in gameStrings)
            {
                ListViewItem item = new ListViewItem();
                item.Text = s;
                item.Tag = s;
                lstGameData.Items.Add(item);
            }
        }
    }
}
