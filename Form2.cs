using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public int id,q;
        public Form2(int Id,int o)
        {
            InitializeComponent();
            if (o == 1||o==2)
            {
                tabControl1.SelectedIndex = 0;
                this.Text = "Echipament";
                if(o==2)
                {
                    richTextBox1.Text = echipamentTableAdapter.Descriere(Id).ToString();
                    dateTimePicker1.Text = echipamentTableAdapter.Data(Id).ToString();
                }
            }
            id = Id;
            q = o;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (q == 1)
            {
                if (richTextBox1.Text != "")
                {
                    echipamentTableAdapter.AdaugareEchipament(id, DateTime.Parse(dateTimePicker1.Text.ToString()), richTextBox1.Text.ToString(), DateTime.Parse(dateTimePicker1.Text.ToString()));
                    this.Close();
                }
                else
                {
                    label2.Text += " \n Acesc camp nu poate ramane gol";
                }
            }
            if(q==2)
            {
                if(richTextBox1.Text=="")
                {
                    label2.Text += " \n Acesc camp nu poate ramane gol";
                }
                else
                {
                    echipamentTableAdapter.ModificareDataPrimire(DateTime.Parse(dateTimePicker1.Text.ToString()), id);
                    echipamentTableAdapter.ModificareDescriere(richTextBox1.Text.ToString(), id);
                    this.Close();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tabDataSet.Echipament' table. You can move, or remove it, as needed.
            this.echipamentTableAdapter.Fill(this.tabDataSet.Echipament);

        }
    }
}
