using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enterprise_Development_CW1
{
    public partial class MainHome : Form
    {

        public MainHome()
        {
            InitializeComponent();
        }
        
        private void converterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Converter c = new Converter();
            c.MdiParent = this;
            c.Show();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game g = new Game();
            g.MdiParent = this;
            g.Show();

            Scores s = new Scores();
            s.MdiParent = this;
            s.Show();
        }

        private void scoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scores s = new Scores();
            s.MdiParent = this;
            s.Show();
        }
    }
}
