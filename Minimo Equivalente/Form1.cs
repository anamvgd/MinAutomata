using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Minimo_Equivalente
{
    public partial class Automata : Form
    {

        private Machine m;
        private int max;
        private int pathsAdded;
        private ArrayList numOutputs;

        public Automata()
        {
            InitializeComponent();
        }

        private void create_table()
        {
            int states = int.Parse(stateNumber.Text);
            string alp = alphabet.Text;
            string[] alph = alp.Split(',');

            if (type.Text.Equals("Mealy"))
            {
                mealy(states, alph);
            }
            else 
            {
                moore(states, alph);
            }
        }

        private void mealy(int states, string[] alph) 
        {

        }

        private void moore(int states, string[] alph)
        {
            Label a = new Label();
            
            /*for (int i=0; i<alph.Length; i++) 
            {
                table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                a.Text = alph[i];
                table.Controls.Add(a,i,0);
            }
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            
            for (int i = 0; i <= states; i++)
            {
                table.RowStyles.Add(new System.Windows.Forms.RowStyle());
                table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            }*/
        }

        private void create_Click(object sender, EventArgs e)
        {

            m = new Machine(int.Parse(stateNumber.Text), type.Text);

            string alp = alphabet.Text;
            string[] alph = alp.Split(',');

            max = int.Parse(stateNumber.Text) * alph.Count();
            pathsAdded = 0;

            numOutputs = new ArrayList();

            type.Enabled = false;
            stateNumber.Enabled = false;
            alphabet.Enabled = false;
            create.Enabled = false;
            initialState.Enabled = true;
            finalstate.Enabled = true;
            entry.Enabled = true;
            exit.Enabled = true;
            add.Enabled = true;
            create_table();
            
        }

        private void add_Click(object sender, EventArgs e)
        {


            State initial = m.getState(int.Parse(initialState.Text));
            State destination = m.getState(int.Parse(finalstate.Text));

            Path p = new Path(initial, destination, entry.Text, exit.Text);
            initial.setOutput(exit.Text);

            initial.addPath(p);
            pathsAdded++;

            if (!numOutputs.Contains(exit.Text))
            {
                numOutputs.Add(exit.Text);
            }

            if (pathsAdded == max)
            {
                initialState.Enabled = false;
                finalstate.Enabled = false;
                entry.Enabled = false;
                exit.Enabled = false;
                add.Enabled = false;

            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Entró minimizar");
            m.bfs();
            if (type.Text.Equals("Moore"))
            {
                Console.WriteLine("....");
                ArrayList m = mooreFirstPartition();
                for(int i=0; i < m.Count;i++)
                {
                    ArrayList mf = (ArrayList)m[i];
                    for (int j=0; j < mf.Count; j++)
                    {
                        Console.WriteLine(((State)mf[j]).getNumber());
                    }
                    Console.WriteLine("------------------------------");
                }
            } else
            {
                mealyFirstPartition();
            }

           

        }

        private ArrayList mooreFirstPartition()
        {
            Console.WriteLine("Entró first moore");
            ArrayList partitions = new ArrayList();
            
            for(int i=0; i < numOutputs.Count; i++)
            {
                ArrayList part = new ArrayList();
                partitions.Add(part);

            }

            for (int i = 0; i < m.getStates().Count; i++)
            {
                State s = (State)m.getStates()[i];

                int n = 0;
                while (!s.getOutput().Equals(numOutputs[n]))
                {
                    n++;
                }

                partitions[n] = s;
            }

            while(nextPartitions(partitions) != partitions)
            {

            }

            return partitions;


        }

        private void mealyFirstPartition()
        {

            Console.WriteLine("Entró first mealy");
            ArrayList partitions = new ArrayList();

            for (int i = 0; i < numOutputs.Count; i++)
            {
                ArrayList part = new ArrayList();
                partitions.Add(part);

            }

            for (int i = 0; i < m.getStates().Count; i++)
            {

                ArrayList p = ((State)m.getStates()[i]).getAdjacents();

                for (int j = 0; j < p.Count; j++)
                {
                    String s = ((Path)p[j]).getOutput();

                    int n = 0;
                    while (!s.Equals(numOutputs[n]))
                    {
                        n++;
                    }

                    partitions[n] = s;
                }

                
            }


        }


        
        public ArrayList nextPartitions(ArrayList partitions)
        {

            Console.WriteLine("Entró next Partitions");

            for (int i = 0; i < m.getStates().Count; i++)
            {
                if (m.belong((State)m.getStates()[i], (State)m.getStates()[i + 1], partitions))
                {
                    if(m.sucesores((State)m.getStates()[i], (State)m.getStates()[i + 1]))
                    {

                    } else
                    {
                        State sta = (State)m.getStates()[i + 1];

                        for(int j=0; j < partitions.Count; j++)
                        {
                            if (((ArrayList)partitions[j]).Contains((State)m.getStates()[i])){

                                ((ArrayList)partitions[j]).Remove((State)m.getStates()[i]);

                            }
                        }
                        
                        partitions.Add(sta);
                    }
                }
            }

            return partitions;
        }


       /* public void finalPartition(ArrayList fPartition)
        {
            Machine fMachine = new Machine(fPartition.Count, type.Text);

            for(int i=0; i < fPartition.Count; i++)
            {
                State s = 
            }
        }*/

        


    }
}
