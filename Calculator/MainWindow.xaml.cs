using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += (s, e) =>
            {
                mainTextBox.Text = "0";
            };

            List<Button> numericButtons = new List<Button> { zeroButton, oneButton, twoButton, threeButton, fourButton, fiveButton, sixButton, sevenButton, eightButton, nineButton };
            foreach (Button currentButton in numericButtons)
            {
                currentButton.Click += (s, e) =>
                {
                    if (mainTextBox.Text != "0")
                    {
                        mainTextBox.Text = mainTextBox.Text + numericButtons.IndexOf(currentButton);
                    }
                    else
                    {
                        mainTextBox.Text = numericButtons.IndexOf(currentButton).ToString();
                    }

                };
            }

            pointButton.Click += (s, e) =>
            {
                if (mainTextBox.Text.Contains(".") == false)
                {
                    mainTextBox.Text = mainTextBox.Text + ".";
                }
                
            };
        }
    }
}
