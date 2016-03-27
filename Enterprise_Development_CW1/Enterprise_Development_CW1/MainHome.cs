using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enterprise_Development_CW1.View
{
    public partial class MainHome : Form
    {

        public MainHome()
        {
            InitializeComponent();
        }
        
        private void converterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Converter))
                {
                    form.Activate();
                    MessageBox.Show("Converter Already Open");
                    return;
                }
            }
            Converter c = new Converter();
            c.MdiParent = this;
            c.Show();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Game))
                {
                    form.Activate();
                    MessageBox.Show("Game Already Open");
                    return;
                }
            }
            Game g = new Game(this);
            g.MdiParent = this;
            g.Show();

            
        }

        private void scoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* foreach (Form form in Application.OpenForms)
             {
                 if (form.GetType() == typeof(Game))
                 {
                     form.Activate();
                     MessageBox.Show("Game Already Open");
                     return;
                 }
             }*/
            //Scores s = new Scores();
            //s.MdiParent = this;
            //s.Show();

            ScoreHistory h = new ScoreHistory();
            h.MdiParent = this;
            h.Show();
        }
    }
}
