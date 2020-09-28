using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
     * This class is created to represent the states that will be part of the machine.
     */
class State
{
	/*
	 * This attribute represents what number of state each one represents
	*/
	private int number;
	/*
	 * This attribute represents the type of the machine in which will be added the state
	*/
	private String typeMachine;
	/*
	 * This attribute represents the output of the state when its a Moore machine
	*/
	private String output;

	private ArrayList adjacents = new ArrayList();

	/*
		* This method creates a new state for the machine
		* @param int number that represents the number of the state
		* @param string type machine that defines the machine which belong the state
	*/
	public State(int number, String typeMachine)
	{
		this.number = number;
		this.typeMachine = typeMachine;

	}


	public String getOutput()
		{
			return output;
		}

		public void setOutput(String output)
		{
			this.output = output;
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
