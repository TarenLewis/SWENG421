using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class OutputState : State
    {
        char operate;

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
                    firstOperandState.enter(param);
                    return firstOperandState;

                case ZERO_DIGIT_EVENT:
                    emptyState.enter(param);
                    return emptyState;

                case RECURSIVE_EVENT:
                    this.recurse(param);
                    return this;

                case EQUALS_EVENT:
                    doOutputMath();
                    return this;

                default:
                    throw new System.InvalidOperationException("Unexpected Event");
            }
        }
        public override void enter(char p)
        {
            operate = operationType;
            //setRoot((double)Convert.ToDouble(label.Text));
            Console.WriteLine("in output state");
            Console.WriteLine("current operator operate: " + operate);
        }

        public void doOutputMath()
        {
            Console.WriteLine("inide output state: do output math");
            
            double d = (double)Convert.ToDouble(label.Text);
            label.Text = Math.Sqrt(d).ToString();

            if (operate == '+')
            {
                d += num2;
            }
            else if (operate == '-')
            {
                d -= num2;
            }
            else if (operate == '*')
            {
                d *= num2;
            }
            else if (operate == '/')
            {
                d /= num2;
            }
            label.Text = d.ToString();
        }

    }
}
