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
        /*
			* This method creates a new machine with a list of states 
			* @param a number of states to define the size of the machine
			* @param a string that defines the type of the machine 
		*/

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
        /*
           * This method modifies an existing machine an finds its irrelevant states and deletes them
           * <b>pre:</b> the machine exists and has states and paths created
       */
        public void bfs()
        {
            State state = (State)states[0];

            ArrayList list = new ArrayList();
            ArrayList conectedStates = new ArrayList();
            list.Add(state);
            conectedStates.Add(state);
            while (list.Count != 0)
            {
                for (int i = 0; i < ((State)list[0]).getAdjacents().Count; i++)
                {
                    ArrayList paths = ((State)list[0]).getAdjacents();
                    list.Add(((Path)paths[i]).getDestination());
                    conectedStates.Add(((Path)paths[i]).getDestination());
                }
                list.Remove(0);
            }

            states = conectedStates;
        }
        /*
                    * This method validates if the states belong to a same partition or not 
                    * @param a state one that is the one to compare with others
                    * @param a state two that is the one to compare with others
                    * @param a list of partitions to divide the necessary states
                */

        public Boolean belong(State one, State two, ArrayList partitions)
        {
            Boolean p = false;
            for (int i = 0; i < partitions.Count; i++)
            {
                if (((ArrayList)partitions[i]).Contains(one))
                {
                    if (((ArrayList)partitions[i]).Contains(two))
                    {
                        p = true;
                    }
                }
            }
            return p;
        }

        public Boolean sucesores(State one, State two)
        {
            Boolean s = false;
            for (int i = 0; i < one.getAdjacents().Count; i++)
            {
                if (exists((Path)one.getAdjacents()[i], two))
                {
                    s = true;
                }
            }
            return s;
        }

        public Boolean exists(Path path, State two)
        {
            Boolean e = false;
            for (int i = 0; i < two.getAdjacents().Count; i++)
            {
                if (path.getDestination().Equals(((Path)two.getAdjacents()[i]).getDestination()) && path.getInput().Equals(((Path)two.getAdjacents()[i]).getInput()))
                {
                    e = true;
                }
            }
            return e;
        }

    }
}
