using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimo_Equivalente
{
    class State
    {
		private int number;
		private String typeMachine;

		private ArrayList adjacents = new ArrayList();

		public State(int number, String typeMachine)
		{
			this.number = number;
			this.typeMachine = typeMachine;
		}

		public int getNumber()
		{
			return number;
		}


		public void setNumber(int number)
		{
			this.number = number;
		}

		public String getType()
		{
			return typeMachine;
		}


		public void setType(String typeMachine)
		{
			this.typeMachine = typeMachine;
		}


		public ArrayList getAdjacents()
		{
			return adjacents;
		}


		public void setAdjacents(ArrayList adjacents)
		{
			this.adjacents = adjacents;
		}

		public void addPath(Path path)
        {
			adjacents.Add(path);
        }
	}
}
