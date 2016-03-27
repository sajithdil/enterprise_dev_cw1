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
    public partial class UsernameDialog : Form
    {
        public string username;
        public UsernameDialog()
        {
            InitializeComponent();
            username = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                MessageBox.Show("Username Empty");
            }
            else
            {
                username = txtUsername.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
