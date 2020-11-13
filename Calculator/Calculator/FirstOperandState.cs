using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#pragma warning disable IDE1006 // Naming Styles

namespace Calculator
{
    class FirstOperandState : State
    {
        public override State nextState(int EVENT, char param)
        {
            switch (EVENT)
            {
                case GENERAL_EVENT:
                    return this;

                case UNARY_OPERATION_EVENT:
                    recurse(param);
                    outputState.enter(param);
                    return outputState;

                case BINARY_OPERATION_EVENT:
                    setOperator(param);
                    pendingOperandState.enter(param);
                    return pendingOperandState;

                case C_EVENT:
                    emptyState.enter(param);
                    return emptyState;

                case NONZERO_DIGIT_EVENT:
                    this.does(param);
                    return this;

                case ZERO_DIGIT_EVENT:
                    this.does(param);
                    return this;

                case SIGN_CHANGE_EVENT:
                    this.recurse(param);
                    return this;

                case RECURSIVE_EVENT:
                    this.recurse(param);
                    return this;

                case EQUALS_EVENT:
                    return this;
                default:
                    throw new System.InvalidOperationException("Unexpected Event");
            }
        }

        public void does(char param)
        {
            Console.WriteLine("inside firstOperandState does");
            label.Text += param;
            num1 = (double)Convert.ToDouble(label.Text);
            Console.WriteLine("num1: " + num1);
        }

        public override void enter(char p)
        {
            Console.WriteLine("inside firstOperandState enter");
            label.Text = "" + p;
            num1 = (double)Convert.ToDouble(label.Text);
            Console.WriteLine("num1: " + num1);
        }

        public void setOperator(char op)
        {
            operationType = op;
            Console.WriteLine("in first operand state");
            Console.WriteLine("current operationType: " + operationType);
        }

    }
}
