using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class SecondOperandState : State
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
                    pendingOperandState.enter(param);
                    return pendingOperandState;

                case C_EVENT:
                    emptyState.enter(param);
                    return emptyState;

                case NONZERO_DIGIT_EVENT:
                    this.process(param);
                    return this;

                case ZERO_DIGIT_EVENT:
                    this.process(param);
                    return this;

                case SIGN_CHANGE_EVENT:
                    this.recurse(param);
                    return this;

                case RECURSIVE_EVENT:
                    this.recurse(param);
                    return this;

                case EQUALS_EVENT:
                    doMath(operationType);
                    outputState.enter(param);
                    return outputState;

                default:
                    throw new System.InvalidOperationException("Unexpected Event");
            }
        }
        
        private void process(char param)
        {
            label.Text += param;
            num2 = (double)Convert.ToDouble(label.Text);
            Console.WriteLine("num2: " + num2);
        }

        public override void enter(char p)
        {
            Console.WriteLine("inside secondOperandState enter");
            label.Text = "" + p;
            Console.WriteLine("num2 inside secondOperandState:" + num2 + "...");
            num2 = (double)Convert.ToDouble(label.Text); ;
            Console.WriteLine("num2: " + num2);
        }
        
    }
}
