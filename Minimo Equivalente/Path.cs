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
