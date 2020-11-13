using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class EmptyState : State
    {
        public override State nextState(int eve, char param)
        {
            switch (eve)
            {
                case NONZERO_DIGIT_EVENT:
                    firstOperandState.enter(param);
                    return firstOperandState;

                case ZERO_DIGIT_EVENT:
                    emptyState.enter(param);
                    return this;

                default:
                    return this;

            }

        }


        public override void enter(char p)
        {
            Console.WriteLine("inside emptystate enter");
            //label.Text = "";
            label.Text = "0";
        }
    }
}
