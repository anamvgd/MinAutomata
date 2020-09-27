using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimo_Equivalente
{
    class State
    {
		private int number;

		private State[] paths;
		private String[] alphabet;

		public State(int number)
		{
			this.number = number;
		}

		public int getNumber()
		{
			return number;
		}


		public void setNumber(int number)
		{
			this.number = number;
		}

		public State[] getPaths()
		{
			return paths;
		}


		public void setPaths(State[] paths)
		{
			this.paths = paths;
		}

		public String[] getAlphabet()
		{
			return alphabet;
		}


		public void setAlphabet(String[] alphabet)
		{
			this.alphabet = alphabet;
		}
	}
}
