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
    public partial class Game : Form
    {
        Timer gameTimer;
        int countdownTimer = 10;
        int convertValue = 0;
        int life = 3;
        Random randomiser;

        ValueType fromType;
        ValueType toType;

        int score = 0;

        string username;
        public Game()
        {
            InitializeComponent();

            txtValue.TextAlign = HorizontalAlignment.Center;
            randomiser = new Random();

            using (var form = new UsernameDialog())
            {
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    username = form.username;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            btnSubmit.Enabled = true;
            gameTimer = new Timer();
            gameTimer.Tick += new EventHandler(timer_Tick);
            gameTimer.Interval = 1000; // 1 second
            gameTimer.Start();

            GenerateNextQuestion(false);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            countdownTimer--;
            if (countdownTimer == 0)
            {
                //gameTimer.Stop();
                //lblMessage.Text = "Game Over";
                ReduceLife();
            }

            lblTimer.Text = countdownTimer.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserInput.Text == "")
            {
                ReduceLife();
            }
            else
            {
                switch (fromType)
                {
                    case ValueType.Decimal:
                        int result = 0;
                        if (!int.TryParse(txtUserInput.Text, out result))
                        {
                            ReduceLife();
                        }
                        else
                        {
                            switch (toType)
                            {
                                //case ValueType.Integer:
                                //break;
                                case ValueType.Binary:

                                    try
                                    {
                                        if (txtUserInput.Text ==
                                        Convert.ToString(int.Parse(txtValue.Text), 2))
                                        {
                                            GenerateNextQuestion(true);
                                        }
                                        else
                                        {
                                            ReduceLife();
                                        }
                                    }
                                    catch(Exception)
                                    {
                                        ReduceLife();
                                    }
                                    break;
                                case ValueType.Hexadecimal:
                                    if (Util.OnlyHexInString(txtUserInput.Text))
                                    {
                                        if (txtUserInput.Text == int.Parse(txtValue.Text).ToString("X"))
                                        {
                                            GenerateNextQuestion(true);
                                        }
                                        else
                                        {
                                            ReduceLife();
                                        }
                                    }
                                    else
                                    {
                                        ReduceLife();
                                    }
                                    break;
                            }
                        }
                        break;
                    case ValueType.Binary:
                        
                        switch (toType)
                        {
                            case ValueType.Decimal:
                                int userOutput = 0;
                                if (!int.TryParse(txtUserInput.Text, out userOutput))
                                {
                                    ReduceLife();
                                }
                                else
                                {
                                    int output = Convert.ToInt32(txtValue.Text, 2);


                                    if (output == userOutput)
                                    {
                                        GenerateNextQuestion(true);
                                    }
                                    else
                                    {
                                        ReduceLife();
                                    }
                                }
                                break;
                            case ValueType.Hexadecimal:
                                if (Util.OnlyHexInString(txtUserInput.Text))
                                {
                                    if (txtUserInput.Text == Util.HexConverted(txtValue.Text))
                                    {
                                        GenerateNextQuestion(true);
                                    }
                                    else
                                    {
                                        ReduceLife();
                                    }
                                }
                                else
                                {
                                    ReduceLife();
                                }
                                break;
                        }
                        break;
                    case ValueType.Hexadecimal:
                        if (!Util.OnlyHexInString(txtUserInput.Text))
                        {
                            ReduceLife();
                        }
                        else
                        {
                            switch (toType)
                            {
                                case ValueType.Decimal:
                                    int userInt = 0;
                                    if (!int.TryParse(txtUserInput.Text, out userInt))
                                    {
                                        ReduceLife();
                                    }
                                    int valueInt = int.Parse(txtValue.Text, System.Globalization.NumberStyles.HexNumber);
                                    if (userInt == valueInt)
                                    {
                                        GenerateNextQuestion(true);
                                    }
                                    else
                                    {
                                        ReduceLife();
                                    }
                                    break;
                                case ValueType.Binary:
                                    try {
                                        string binaryUserstring = String.Join(String.Empty,
                                          txtUserInput.Text.Select(
                                            c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                                          )
                                        );
                                        if (Convert.ToString(int.Parse(txtUserInput.Text), 2) ==
                                            Convert.ToString(int.Parse(txtValue.Text), 2))
                                        {
                                            GenerateNextQuestion(true);
                                        }
                                        else
                                        {
                                            ReduceLife();
                                        }
                                    }
                                    catch(Exception)
                                    {
                                        ReduceLife();
                                    }
                                    break;

                                    }
                        }
                        break;
                }


            }


        }

        private void ReduceLife()
        {
            life--;
            lblMessage.Text = "Incorrect Input, You have only " + life.ToString() + " attempt(s) left";
            countdownTimer = 10;
            lblAttempts.Text = life.ToString();

            if (life == 0)
            {
                gameTimer.Stop();
                lblMessage.Text = "Game Over";
                btnStart.Enabled = true;
                life = 3;
                lblAttempts.Text = life.ToString();
                btnSubmit.Enabled = false;
                lblScore.Text = "0";

                MessageBox.Show("Game Over\nFinal Score: " + score);
                score = 0;
            }
            else
            {
                GenerateNextQuestion(false);
            }
        }

        private void GenerateNextQuestion(bool passed)
        {
            if (passed)
            {
                score++;
                Util.UpdateScore(fromType, toType);
            }
            lblMessage.Text = "";
            btnSubmit.Enabled = true;
            lblScore.Text = score.ToString();

            int randomFrom = randomiser.Next(1, 4);
            int randomTo = randomiser.Next(1, 4);

            while (randomFrom == randomTo)
            {
                randomTo = randomiser.Next(1, 4);
            }

            convertValue = randomiser.Next(1, 50);

            switch (randomFrom)
            {
                case 1:
                    fromType = ValueType.Decimal;
                    txtValue.Text = convertValue.ToString();
                    break;
                case 2:
                    fromType = ValueType.Binary;
                    txtValue.Text = Convert.ToString(convertValue, 2);
                    break;
                case 3:
                    fromType = ValueType.Hexadecimal;
                    txtValue.Text = convertValue.ToString("X");
                    break;
                default:
                    throw new Exception("unknown type");
                    break;
            }
            switch (randomTo)
            {
                case 1:
                    toType = ValueType.Decimal;
                    break;
                case 2:
                    toType = ValueType.Binary;
                    break;
                case 3:
                    toType = ValueType.Hexadecimal;
                    break;
                default:
                    throw new Exception("unknown type");
                    break;
            }

            btnStart.Enabled = false;
            lblGameText.Text = Util.buildGameString(fromType, toType);
        }
    }
}
