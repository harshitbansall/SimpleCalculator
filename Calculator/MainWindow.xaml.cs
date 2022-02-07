using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Brush focusColor = Brushes.Yellow;
            Brush defaultColor = Brushes.Black;
            string firstQuery = null;
            Button focusOperation = null;

            acButton.Click += (s, e) =>
            {
                mainTextBox.Text = "0";
            };
            pointButton.Click += (s, e) =>
            {
                if (mainTextBox.Text.Contains(".") == false)
                {
                    mainTextBox.Text = mainTextBox.Text + ".";
                }

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

            
            plusButton.Click += (s, e) =>
            {
                focusOperation = plusButton;
                focusOperation.Background = focusColor;
                firstQuery = mainTextBox.Text;
                mainTextBox.Text = "";
            };
            minusButton.Click += (s, e) =>
            {
                focusOperation = minusButton;
                focusOperation.Background = focusColor;
                firstQuery = mainTextBox.Text;
                mainTextBox.Text = "";
            };
            multiplyButton.Click += (s, e) =>
            {
                focusOperation = multiplyButton;
                focusOperation.Background = focusColor;
                firstQuery = mainTextBox.Text;
                mainTextBox.Text = "";
            };
            divideButton.Click += (s, e) =>
            {
                focusOperation = divideButton;
                focusOperation.Background = focusColor;
                firstQuery = mainTextBox.Text;
                mainTextBox.Text = "";
            };

            equalsButton.Click += (s, e) =>
            {
                focusOperation.Background = default;
                if (focusOperation.Content.Equals("+")){ mainTextBox.Text = (float.Parse(firstQuery) + float.Parse(mainTextBox.Text)).ToString(); }
                else if (focusOperation.Content.Equals("-")) { mainTextBox.Text = (float.Parse(firstQuery) - float.Parse(mainTextBox.Text)).ToString(); }
                else if (focusOperation.Content.Equals("*")) { mainTextBox.Text = (float.Parse(firstQuery) * float.Parse(mainTextBox.Text)).ToString(); }
                else if (focusOperation.Content.Equals("/")) { mainTextBox.Text = (float.Parse(firstQuery) / float.Parse(mainTextBox.Text)).ToString(); }
            };
            
        }
        private Brush _defaultColor;
        public Brush defaultColor { get { return _defaultColor; } set { _defaultColor = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
