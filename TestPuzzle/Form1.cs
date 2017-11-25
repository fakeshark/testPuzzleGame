using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPuzzle
{
    public partial class Form1 : Form
    {
        Button[] GameButtons;
        Button FirstButton;
        Button SecondButton;

        public Form1()
        {
            InitializeComponent();
            GameButtons = new Button[25] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button clickedBtn = (sender as Button);
            int BtnArrIndex = Convert.ToInt32(clickedBtn.Tag);

            {
                if (FirstButton == null)
                {
                    FirstButton = (sender as Button);
                    FirstButton.BackColor = Color.DarkGoldenrod;
                }
                else if (clickedBtn == FirstButton)
                {
                    FirstButton.BackColor = Color.Gold;
                    FirstButton = null;
                }
                else
                {
                    if (BtnArrIndex == Convert.ToInt32(FirstButton.Tag) + 1 || BtnArrIndex == Convert.ToInt32(FirstButton.Tag) - 1 || BtnArrIndex == Convert.ToInt32(FirstButton.Tag) + 5 || BtnArrIndex == Convert.ToInt32(FirstButton.Tag) - 5)
                    {
                        SecondButton = (sender as Button);
                        SecondButton.BackColor = Color.DarkGoldenrod;
                    }
                }

                if (FirstButton != null && SecondButton != null)
                {
                    SwapPlaces(FirstButton, SecondButton);
                    FirstButton.BackColor = Color.Gold;
                    SecondButton.BackColor = Color.Gold;
                    FirstButton = null;
                    SecondButton = null;
                }
            }
        }

        private void SwapPlaces(Button firstButton, Button secondButton)
        {
            //set variables to swap
            int firstBtnXpos = firstButton.Location.X;
            int firstBtnYpos = firstButton.Location.Y;
            int secondBtnXpos = secondButton.Location.X;
            int secondBtnYpos = secondButton.Location.Y;
            int firstTag = Convert.ToInt32(firstButton.Tag);
            int secondTag = Convert.ToInt32(secondButton.Tag);

            //swap variables
            FirstButton.Tag = secondTag;
            SecondButton.Tag = firstTag;
            FirstButton.Left = secondBtnXpos;
            FirstButton.Top = secondBtnYpos;
            SecondButton.Left = firstBtnXpos;
            SecondButton.Top = firstBtnYpos;
            FirstButton.Refresh();
            SecondButton.Refresh();
        }
    }
}
