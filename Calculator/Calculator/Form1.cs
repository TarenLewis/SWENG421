using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        State state = new State();
       
        public Form1()
        {
            InitializeComponent();
            state = state.start(displayLabel);

            zeroButton.Click += new EventHandler(zero_clicked);
            oneButton.Click += new EventHandler(digit_clicked);
            twoButton.Click += new EventHandler(digit_clicked);
            threeButton.Click += new EventHandler(digit_clicked);
            fourButton.Click += new EventHandler(digit_clicked);
            fiveButton.Click += new EventHandler(digit_clicked);
            sixButton.Click += new EventHandler(digit_clicked);
            sevenButton.Click += new EventHandler(digit_clicked);
            eightButton.Click += new EventHandler(digit_clicked);
            nineButton.Click += new EventHandler(digit_clicked);

            backSpaceButton.Click += new EventHandler(backspace_clicked);
            ceButton.Click += new EventHandler(digit_clicked);
            cButton.Click += new EventHandler(digit_clicked);
            signButton.Click += new EventHandler(sign_clicked);
            divideButton.Click += new EventHandler(divide_clicked);
            multiplyButton.Click += new EventHandler(multiply_clicked);
            addButton.Click += new EventHandler(add_clicked);
            subtractButton.Click += new EventHandler(subtract_clicked);
            decimalButton.Click += new EventHandler(digit_clicked);
            squareRootButton.Click += new EventHandler(square_clicked);
            equalsButton.Click += new EventHandler(digit_clicked);
            fractionButton.Click += new EventHandler(fraction_clicked);
        }
        private void multiply_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '*');
        }

        private void divide_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '/');
        }
        private void add_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '+');
        }
        private void subtract_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '-');
        }

        private void backspace_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '6');
        }

        private void sign_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '9');
        }

        private void zero_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '0');
        }
        private void digit_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            //state.label = displayLabel;
            char[] c = button.Text.ToCharArray();
            state = state.processEvent(buttonTagAsInt, c[0]);
        }


        private void square_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '7');
        }
        private void fraction_clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonTagAsInt = int.Parse(button.Tag.ToString());
            state = state.processEvent(buttonTagAsInt, '8');
        }


    }
}
