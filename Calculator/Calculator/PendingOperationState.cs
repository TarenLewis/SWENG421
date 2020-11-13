using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class PendingOperationState : State
    {
        char operate;
        double originalRoot;
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
                    pendingOperandState.enter(param);
                    return pendingOperandState;

                case C_EVENT:
                    emptyState.enter(param);
                    return emptyState;

                case NONZERO_DIGIT_EVENT:
                    exit();
                    secondOperandState.enter(param);
                    return secondOperandState;

                case ZERO_DIGIT_EVENT:
                    exit();
                    secondOperandState.enter(param);
                    return secondOperandState;

                case SIGN_CHANGE_EVENT:
                    this.recurse(param);
                    return this;

                case RECURSIVE_EVENT:
                    this.recurse(param);
                    return this;

                case EQUALS_EVENT:
                    this.does(param);
                    return this;

                default:
                    throw new System.InvalidOperationException("Unexpected Event");

            }
        }
        private void setRoot(double d)
        {
            this.originalRoot = d;
        }
        private double getRoot()
        {
            return originalRoot;
        }
        private void does(char param)
        {
            Console.WriteLine("inide pending operation state: does");
            double d = (double)Convert.ToDouble(label.Text);
            label.Text = Math.Sqrt(d).ToString();

            if (operate == '+')
            {
                d += getRoot();
            }
            else if(operate == '-')
            {
                d -= getRoot();
            }
            else if (operate == '*')
            {
                d *= getRoot();
            }
            else if (operate == '/')
            {
                d /= getRoot();
            }
            label.Text = d.ToString();
        }
        
        public override void enter(char op)
        {
            operate = op;
            setRoot((double)Convert.ToDouble(label.Text));
            Console.WriteLine("in pending operation state");
            Console.WriteLine("current operator p: " + op);
        }
    }
}
