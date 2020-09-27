using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimo_Equivalente
{
    class Machine
    {
        private ArrayList states = new ArrayList();

        public Machine(int numberStates, String type)
        {
            for (int i = 0; i < numberStates; i++)
            {
                State st = new State(i, type);
                states.Add(st);
            }
        }

        public State getState(int nameState)
        {
            return (State)states[nameState];
        }

        public ArrayList getStates()
        {
            return states;
        }

    }
}
