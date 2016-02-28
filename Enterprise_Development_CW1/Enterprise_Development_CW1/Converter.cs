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
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }

        private void txtDecimal_TextChanged(object sender, EventArgs e)
        {
            int result = 0;
            if(!int.TryParse(txtDecimal.Text, out result))
            {
                lblErr.Text = "Error: Invalid Input in decimal box";
                txtBinary.Text = "";
                txtHex.Text = "";
            }
            else
            {
                lblErr.Text = "";
                txtHex.Text = int.Parse(txtDecimal.Text).ToString("X");
                txtBinary.Text = Convert.ToString(int.Parse(txtDecimal.Text), 2);
            }
        }

        private void txtHex_TextChanged(object sender, EventArgs e)
        {
            if(!OnlyHexInString(txtHex.Text))
            {
                lblErr.Text = "Error: Invalid Input in hexadecimal box";
                txtBinary.Text = "";
                txtDecimal.Text = "";
            }
            else
            {
                int intAgain = int.Parse(txtHex.Text, System.Globalization.NumberStyles.HexNumber);
                txtDecimal.Text = intAgain.ToString();

                string binarystring = String.Join(String.Empty,
                  txtHex.Text.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                  )
                );

                txtBinary.Text = binarystring;
            }
        }

        public bool OnlyHexInString(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        private void txtBinary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int output = Convert.ToInt32(txtBinary.Text, 2);
                txtDecimal.Text = output.ToString();
                txtHex.Text = HexConverted(txtBinary.Text);
            }
            catch(Exception ex)
            {
                lblErr.Text = "Error: Invalid Input in binary box";
                txtDecimal.Text = "";
                txtHex.Text = "";
            }
        }

        string HexConverted(string strBinary)
        {
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X");
            return strHex;
        }
    }
}
