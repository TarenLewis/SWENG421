using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

namespace Calculator
{
    class State
    {
        internal const int GENERAL_EVENT = 0;
        internal const int UNARY_OPERATION_EVENT = 1;
        internal const int BINARY_OPERATION_EVENT = 2;
        internal const int EQUALS_OPERATION_EVENT = 3;
        internal const int ZERO_DIGIT_EVENT = 4;
        internal const int NONZERO_DIGIT_EVENT = 5;
        internal const int C_EVENT = 6;
        internal const int SIGN_CHANGE_EVENT = 7;
        internal const int RECURSIVE_EVENT = 8;
        internal const int EQUALS_EVENT = 9;

        public Label label;
        public static double num1 = 0;
        public static double num2 = 0;
        public static char operationType;
        
        static internal EmptyState emptyState;
        static internal FirstOperandState firstOperandState;
        static internal SecondOperandState secondOperandState;
        static internal PendingOperationState pendingOperandState;
        static internal OutputState outputState;

        public State start(Label l)
        {
            State s = new State();
            s.create();
            

            emptyState.label = l;
            firstOperandState.label = l;
            secondOperandState.label = l;
            pendingOperandState.label = l;
            outputState.label = l;

            return emptyState;

        }

        private void create()
        {
            if (firstOperandState == null)
            {
            Console.WriteLine("firstOperandState created");

            firstOperandState = new FirstOperandState();
            emptyState = new EmptyState();
            secondOperandState = new SecondOperandState();
            pendingOperandState = new PendingOperationState();
            outputState = new OutputState();

            }
        }
        
        public virtual void enter(char p) { }

        public virtual void exit() {
            num2 = (double)Convert.ToDouble(label.Text);
        }

        public virtual State nextState(int e, char param)
        {
           throw new System.InvalidOperationException("This method should never be accessed.");
        }

        public State processEvent(int evt, char param)
        {
            State myNextState = nextState(evt, param);
            return myNextState;
        }

        public void recurse(char param)
        {
            double d = (double)Convert.ToDouble(label.Text);
            switch (param)
            {
                case '6':
                    {
                        // Do not allow deletion past 1 length
                        if (label.Text.ToString().Length == 1) { return; }

                        Console.WriteLine("inside deletion case 6");
                        List<char> charList = label.Text.ToList();
                        charList.RemoveAt(charList.Count - 1);
                        label.Text = "";
                        foreach (char c in charList)
                        {
                            label.Text += c;
                        }

                        return;
                    }
                // Square root
                case '7':
                    {
                        label.Text = Math.Sqrt(d).ToString();
                        return;
                    }

                // 1/x
                case '8':
                    {
                        label.Text = (1 / d).ToString();
                        return;
                    }

                // pos/neg
                case '9':
                    {

                        if (Math.Sign(d) == -1)
                        {
                            label.Text = (-1 * d).ToString();
                            return;
                        }
                        else if (Math.Sign(d) == 1)
                        {
                            label.Text = (-d).ToString();
                            return;
                        }
                        else
                            return;

                    }

                default:
                    throw new System.InvalidOperationException("Unexpected Event");
            }

        }
        public void displayDigitClicked(double d)
        {
            Console.WriteLine("Displaying Digit: " + d);
            label.Text = d.ToString();
        }


        public void setDigitClicked(Button button)
        {
            double digitClicked = (double)Convert.ToDouble(button.Text);
            num2 = digitClicked;
        }
        public double getDigitClicked()
        {
            return num2;
        }

        public void doMath (char operationType)
        {
            double math = 0;
            Console.WriteLine("operation Type: " + operationType);
            Console.WriteLine("inside state domath");
            if (operationType == '+')
            {
                math = num1 + num2;
                Console.WriteLine("math: " + math);
            }

            if (operationType == '*')
            {
                math = num1 * num2;
                Console.WriteLine("math: " + math);
            }

            if (operationType == '-')
            {
                math = num1 - num2;
                Console.WriteLine("math: " + math);
            }

            if (operationType == '/')
            {
                math = num1 / num2;
                Console.WriteLine("math: " + math);
            }

            label.Text = math.ToString();
            //num1 = num2;
            Console.WriteLine("num1: " + num1);
            Console.WriteLine("num2: " + num2);
            Console.WriteLine("Doing math... " + math.ToString());
        }


    }
}
