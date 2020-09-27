using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            initial.addPath(p);
            pathsAdded++;

            if (pathsAdded == max)
            {
                initialState.Enabled = false;
                finalstate.Enabled = false;
                entry.Enabled = false;
                exit.Enabled = false;
                add.Enabled = false;

            }
        }
    }
}
