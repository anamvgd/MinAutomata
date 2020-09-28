using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimo_Equivalente
{
    class Path
    {

        private State origin;
        private State destination;
        private String input;
        private String output;
        /*
			* This method creates a new path that connects two states
			* <b>pre:</b> the states initial and destination has to be created
			* @param a state that is the initial state 
			* @param a state that is the destination state where the path takes to
			* @param a string input that is defined by the language 
			* @param a string output that is the result where takes the destination state
		*/
        public Path(State origin, State destination, String input, String output)
        {
            this.origin = origin;
            this.destination = destination;
            this.input = input;
            this.output = output;
        }

        public State getOrigin()
        {
            return origin;
        }

        public void setOrigin(State origin)
        {
            this.origin = origin;
        }

        public State getDestination()
        {
            return destination;
        }
        public void setDestination(State destination)
        {
            this.destination = destination;
        }

        public String getInput()
        {
            return input;
        }

        public void setInput(String input)
        {
            this.input = input;
        }

        public String getOutput()
        {
            return output;
        }

        public void setOutput(String output)
        {
            this.output = output;
        }

    }
}
