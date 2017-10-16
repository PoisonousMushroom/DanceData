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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           label11.Text =persoanaTableAdapter.NrPersoaneActive().ToString();
        }
        int ok = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tabDataSet.Echipament' table. You can move, or remove it, as needed.
            this.echipamentTableAdapter.Fill(this.tabDataSet.Echipament);
            // TODO: This line of code loads data into the 'tabDataSet.Persoana' table. You can move, or remove it, as needed.
            this.persoanaTableAdapter.Fill(this.tabDataSet.Persoana);
            // TODO: This line of code loads data into the 'tabDataSet.Dans' table. You can move, or remove it, as needed.
            tabDataSet.EnforceConstraints = false;
            this.dansTableAdapter.Fill(this.tabDataSet.Dans);

        }
        private void inscriereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
            label49.Visible = false;
            ok = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            monthCalendar1.SetDate(DateTime.Today);
            monthCalendar2.SetDate( DateTime.Today); 
            monthCalendar3.SetDate ( DateTime.Today);
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            tabControl2.SelectedIndex = 0;
            tabControl1.SelectedIndex = 1;
        }

        private void stergereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            button31.Enabled = false;
            button4.Enabled = false;
            monthCalendar4.SetDate(DateTime.Today);
            comboBox3.Items.Clear();
            persoanaTableAdapter.PersoaneActive(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["datai"].Equals(dt.Rows[i]["dataf"]) == true)
                {
                    string s = dt.Rows[i]["Nume"].ToString().Trim() + " " + dt.Rows[i]["Prenume"].ToString().Trim();
                    comboBox3.Items.Add(s);
                }
            }
            comboBox3.Sorted=true;
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            tabControl1.SelectedIndex = 2;
        }

        private void modificareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            label25.Visible = false;
            comboBox4.Items.Clear();
            for(int i=0;i< dt.Rows.Count;i++)
            {
                string s = dt.Rows[i]["Nume"].ToString().Trim() + " " + dt.Rows[i]["Prenume"].ToString().Trim();
                comboBox4.Items.Add(s);
            }
            comboBox4.Sorted = true;
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            monthCalendar3.SetDate ( DateTime.Today);
            monthCalendar4.SetDate(DateTime.Today);
            comboBox5.SelectedIndex = -1;
            comboBox5.Text = "";
            comboBox4.Text = "";
            tabControl1.SelectedIndex = 3;
        }

        private void activareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            for(int i=0;i< dt.Rows.Count;i++)
            {
                if(dt.Rows[i]["datai"].Equals(dt.Rows[i]["dataf"])==false)
                {
                    string s = dt.Rows[i]["nume"].ToString().Trim() + " " + dt.Rows[i]["prenume"].ToString().Trim();
                    comboBox6.Items.Add(s);
                }
            }
            comboBox6.Sorted = true;
            comboBox6.Text = "";
            label24.Text = "";
            tabControl1.SelectedIndex = 4;
        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label27.Text = "";
            comboBox7.Items.Clear();
            comboBox7.Text = "";
            persoanaTableAdapter.EchipamentLipsa(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            for(int i=0;i<dt.Rows.Count; i++)
            {
                string s = dt.Rows[i]["nume"].ToString().Trim() + " " + dt.Rows[i]["prenume"].ToString().Trim();
                comboBox7.Items.Add(s);
            }
            comboBox7.Sorted = true;
            tabControl1.SelectedIndex = 5;
        }

        private void stergereToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            comboBox8.Items.Clear();
            comboBox8.Text = "";
            persoanaTableAdapter.EchipamentExista(tabDataSet.Persoana) ;
            DataTable dt = tabDataSet.Persoana;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                string s = dt.Rows[i]["nume"].ToString().Trim() + " " + dt.Rows[i]["prenume"].ToString().Trim();
                comboBox8.Items.Add(s);
            }
            comboBox8.Sorted = true;
            tabControl1.SelectedIndex = 6;
        }

        private void modificareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
            comboBox9.Items.Clear();
            comboBox9.Text = "";
            persoanaTableAdapter.EchipamentExista(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i]["nume"].ToString().Trim() + " " + dt.Rows[i]["prenume"].ToString().Trim();
                comboBox9.Items.Add(s);
            }
            comboBox9.Sorted = true;
            tabControl1.SelectedIndex = 7;
        }

        private void plataTaxaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox4.Text = "";
            monthCalendar5.SetDate(DateTime.Now.Date);
            label31.Visible = false;
            comboBox10.Items.Clear();
            comboBox10.Text = "";
            persoanaTableAdapter.PersoaneActive(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i]["nume"].ToString().Trim() + " " + dt.Rows[i]["prenume"].ToString().Trim();
                comboBox10.Items.Add(s);
            }
            comboBox10.Sorted = true;
            tabControl1.SelectedIndex = 8;
        }

        private void introducereConcursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 10;
        }

        private void introducereRezultateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 11;
        }

        private void trecereClasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 12;
        }

        private void perioadaTaxaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void varsteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("nume", "Nume");
            dataGridView1.Columns.Add("prenume", "Prenume");
            dataGridView1.Columns.Add("tip", "Grupa");
            dataGridView1.Columns.Add("carnet", "Numar carnet");
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            numericUpDown4.Value = 5;
            tabControl1.SelectedIndex = 14;
        }

        private void clasaDansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Add("nume", "Nume");
            dataGridView2.Columns.Add("prenume", "Prenume");
            dataGridView2.Columns.Add("tip", "Grupa");
            dataGridView2.Columns.Add("carnet", "Numar carnet");
            dataGridView2.Columns.Add("st", "Clasa Standard");
            dataGridView2.Columns.Add("la", "Clasa Latino");
            tabControl1.SelectedIndex = 9;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            echipamentTableAdapter.StergereEchipament(int.Parse(persoanaTableAdapter.NrPersoane().ToString()) + 1);
            tabControl1.SelectedIndex = 0;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {


        }
        private void button2_Click(object sender, EventArgs e)
        {
            int n=1;
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            if (tabDataSet.Persoana.Rows.Count!= 0)
            {
                n = (int)(tabDataSet.Persoana[tabDataSet.Persoana.Count - 1]["Id"]) + 1;
            }
            if (textBox1.Text.ToString() == ""||textBox2.Text.ToString()==""||textBox3.Text.ToString()==""||comboBox1.Text.ToString()==""||comboBox2.Text.ToString()=="")
            {
                label10.Visible = true;
                label49.Visible = false;
            }
            else
            {
                string s = textBox1.Text.ToString(),d = textBox2.Text.ToString();
                if (persoanaTableAdapter.ReturnareIdDupaNume(s,d)!=null&&(int)(persoanaTableAdapter.ReturnareIdDupaNume(s, d))>=0)
                {
                    label10.Visible = false;
                    label49.Visible = true;
                }
                else {
                    if (comboBox2.Text == "Nu")
                    {
                        echipamentTableAdapter.StergereEchipament(n);
                    }
                    label10.Visible = false;
                    label49.Visible = false;
                    int a, b;
                    if (comboBox2.Text.ToString() == "Da")
                    {
                        a = 1;
                    }
                    else
                    { a = 0; }
                    if (comboBox1.Text.ToString() == "Incepator") { b = 1; }
                    else { b = 2; }
                    if (textBox4.Text == "")
                    {
                        persoanaTableAdapter.Adauga(n, textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), "", DateTime.Parse(monthCalendar1.SelectionRange.Start.Date.ToString()), DateTime.Parse(monthCalendar1.SelectionRange.Start.Date.ToString()), b, DateTime.Parse(monthCalendar2.SelectionRange.Start.Date.ToString()), a, DateTime.Parse(monthCalendar3.SelectionRange.Start.Date.ToString()));
                        persoanaTableAdapter.Update(tabDataSet.Persoana); label11.Text = persoanaTableAdapter.NrPersoaneActive().ToString();
                        tabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        persoanaTableAdapter.Adauga(n, textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), DateTime.Parse(monthCalendar1.SelectionRange.Start.Date.ToString()), DateTime.Parse(monthCalendar1.SelectionRange.Start.Date.ToString()), b, DateTime.Parse(monthCalendar2.SelectionRange.Start.Date.ToString()), a, DateTime.Parse(monthCalendar3.SelectionRange.Start.Date.ToString()));
                        persoanaTableAdapter.Update(tabDataSet.Persoana); label11.Text = persoanaTableAdapter.NrPersoaneActive().ToString();
                        tabControl1.SelectedIndex = 0;
                    }
                }
            }
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            button4.Enabled = true;
            button31.Enabled = true;
            string[] x = new string[2];
            x=comboBox3.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            int a =(int) (persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            richTextBox1.Text = x[0].Trim() + " " + x[1].Trim() + "\n" + "Telefon parinte      " + tabDataSet.Persoana[0]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"] != null && tabDataSet.Persoana[0]["T2"].Equals("") == false)
            {
                richTextBox1.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0]["datai"].ToString().Trim());
            richTextBox1.Text += "Data inscriere        " + v.Date.ToShortDateString()
                + "\n" + "Tip dansator      ";
            if (tabDataSet.Persoana[0]["Tip"].Equals(1) == true)
            {
                richTextBox1.Text += "Incepator" + "\n";
            }
            else
            {
                richTextBox1.Text += "Avansat" + "\n";
            }
            richTextBox1.Text += "Descriere echipament \n" + echipamentTableAdapter.Descriere(a);
        }

       private void button4_Click(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox3.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            DateTime v = DateTime.Parse(monthCalendar4.SelectionRange.Start.ToString());
            persoanaTableAdapter.RetragereSportiv(v, a);
            label11.Text = persoanaTableAdapter.NrPersoaneActive().ToString();
            tabControl1.SelectedIndex = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] x = new string[2];
            x = comboBox4.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            DataTable dt = tabDataSet.Persoana;
            textBox5.Text = dt.Rows[0]["nume"].ToString();
            textBox6.Text = dt.Rows[0]["prenume"].ToString();
            textBox7.Text = dt.Rows[0]["T1"].ToString();
            textBox8.Text = dt.Rows[0]["T2"].ToString();
            dateTimePicker1.Text = dt.Rows[0]["datai"].ToString();
            dateTimePicker2.Text = dt.Rows[0]["vizam"].ToString();
            if((int)(dt.Rows[0]["tip"])==1)
            {
                comboBox5.SelectedIndex = 0;
            }
            else
            {
                comboBox5.SelectedIndex = 1;
            }
        }

         private void comboBox3_TextChanged(object sender, EventArgs e)
        {
             comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
              comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
              comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox6.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox4.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox4.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            DateTime v = DateTime.Parse(dateTimePicker1.Text.ToString());
            DateTime d = DateTime.Parse(dateTimePicker2.Text.ToString());
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            int ok;
            if(dt.Rows[0]["datai"].Equals(dt.Rows[0]["dataf"]))
            {
                ok = 0;
            }
            else
                { ok = 1; }
            if (textBox5.Text.ToString() == "" || textBox6.Text.ToString() == "" || textBox7.Text.ToString() == "")
            {
                label25.Visible = true;
            }
            else
            {
                label25.Visible = false;
                int b;
                if (comboBox5.Text.ToString() == "Incepator") { b = 1; }
                else { b = 2; }
                if (textBox8.Text == "")
                {
                    if (ok == 1)
                    {
                        persoanaTableAdapter.Modifica(textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), "", v, DateTime.Parse(dt.Rows[a-1]["dataf"].ToString()), b, d, a);
                        persoanaTableAdapter.Update(tabDataSet.Persoana);
                    }
                    else
                    {
                        persoanaTableAdapter.Modifica(textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), "", v, v, b, d, a);
                        persoanaTableAdapter.Update(tabDataSet.Persoana);
                    }
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    if (ok == 1)
                    {
                        persoanaTableAdapter.Modifica(textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), v, DateTime.Parse(dt.Rows[a-1]["dataf"].ToString()), b, d,a );
                        persoanaTableAdapter.Update(tabDataSet.Persoana);
                    }
                    else
                    {
                        persoanaTableAdapter.Modifica(textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), v, v, b, d, a);
                        persoanaTableAdapter.Update(tabDataSet.Persoana);
                    }
                    tabControl1.SelectedIndex = 0;
                }
            }
        }
        
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox6.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            label24.Text = x[0].Trim() + " " + x[1].Trim()+ "\n" + "Telefon parinte      " + tabDataSet.Persoana[0]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"]!=null && tabDataSet.Persoana[0]["T2"].Equals("")== false)
            {
                label24.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0]["datai"].ToString().Trim());
            label24.Text += "Data inscriere        " +  v.Date.ToShortDateString()
                + "\n" + "Tip dansator      ";
            if(tabDataSet.Persoana[0]["Tip"].Equals(1)==true)
            {
                label24.Text += "Incepator" + "\n";
            }   
            else
            {
                label24.Text += "Avansat" + "\n";
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox6.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.Activare(a);
            tabControl1.SelectedIndex = 0;
            label11.Text = persoanaTableAdapter.NrPersoaneActive().ToString();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esti sigur ca vrei sa stergi definitiv acest sportiv din baza de date? \n          (informatiile pierdute nu pot fi recuperate)", "Stergere Sportiv", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                string[] x = new string[2];
                x = comboBox3.Text.Split(' ');
                if (x.Count() >= 3)
                {
                    int i = 3;
                    do
                    {
                        x[1] = x[1] + " " + x[i - 1];
                        i++;
                    } while (i <= x.Count());
                }
                persoanaTableAdapter.Fill(tabDataSet.Persoana);
                int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
                persoanaTableAdapter.Stergere(a);
                label11.Text = persoanaTableAdapter.NrPersoaneActive().ToString();
                tabControl1.SelectedIndex = 0;
                echipamentTableAdapter.StergereEchipament(a);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text=="Da")
            {
                persoanaTableAdapter.Fill(tabDataSet.Persoana);
                if (ok == 0)
                {
                    int n=1;
                    if (tabDataSet.Persoana.Rows.Count != 0) {
                        n = (int)(tabDataSet.Persoana[tabDataSet.Persoana.Count - 1]["Id"]) + 1;
                    }
                    Form2 d = new Form2(n, 1);
                    d.ShowDialog();
                    ok = 1;
                }

            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox7.Text.Split(' ');
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            label27.Text = x[0].Trim() + " " + x[1].Trim() + "\n" + "Telefon parinte      " + tabDataSet.Persoana[0]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"] != null && tabDataSet.Persoana[0]["T2"].Equals("") == false)
            {
                label27.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0]["datai"].ToString().Trim());
            label27.Text += "Data inscriere        " + v.Date.ToShortDateString() + "\n" + "Tip dansator      ";
            if (tabDataSet.Persoana[0]["Tip"].Equals(1) == true)
            {
                label27.Text += "Incepator" + "\n";
            }
            else
            {
                label27.Text += "Avansat" + "\n";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox7.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.AdaugareEchip(a);
            Form2 b = new Form2(a,1);
            b.ShowDialog();
            tabControl1.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox8.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            richTextBox2.Text = x[0].Trim() + " " + x[1].Trim() + "\n" + "Telefon parinte      " + tabDataSet.Persoana[0 ]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"] != null && tabDataSet.Persoana[0 ]["T2"].Equals("") == false)
            {
                richTextBox2.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0 ]["datai"].ToString().Trim());
            richTextBox2.Text += "Data inscriere        " + v.Date.ToShortDateString()
                + "\n" + "Tip dansator      ";
            if (tabDataSet.Persoana[0 ]["Tip"].Equals(1) == true)
            {
                richTextBox2.Text += "Incepator" + "\n";
            }
            else
            {
                richTextBox2.Text += "Avansat" + "\n";
            }
            richTextBox2.Text +="Descriere echipament \n"+ echipamentTableAdapter.Descriere(a);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox8.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            if (MessageBox.Show("Esti sigur ca vrei sa stergi definitiv informatiile pastrate despre echipamentul sportivului selectat? \n        ( Aceste date nu pot fi recuperate )", "Stergere Echipament", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                echipamentTableAdapter.StergereEchipament(a);
                persoanaTableAdapter.LipsaEchipament(a);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox9.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            richTextBox3.Text = x[0].Trim() + " " + x[1].Trim() + "\n" + "Telefon parinte      " + tabDataSet.Persoana[0]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"] != null && tabDataSet.Persoana[0]["T2"].Equals("") == false)
            {
                richTextBox3.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0]["datai"].ToString().Trim());
            richTextBox3.Text += "Data inscriere        " + v.Date.ToShortDateString()
                + "\n" + "Tip dansator      ";
            if (tabDataSet.Persoana[0]["Tip"].Equals(1) == true)
            {
                richTextBox3.Text += "Incepator" + "\n";
            }
            else
            {
                richTextBox3.Text += "Avansat" + "\n";
            }
            richTextBox3.Text += "Descriere echipament \n" + echipamentTableAdapter.Descriere(a);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox9.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.AdaugareEchip(a);
            Form2 b = new Form2(a, 2);
            b.ShowDialog();
            tabControl1.SelectedIndex = 0;
        }

        private void comboBox7_TextChanged(object sender, EventArgs e)
        {
            comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox7.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void comboBox8_TextChanged(object sender, EventArgs e)
        {
            comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox8.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox8.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void comboBox9_TextChanged(object sender, EventArgs e)
        {
            comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox9.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox9.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox10.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            richTextBox4.Text = x[0].Trim() + " " + x[1].Trim() + "\n" + "Telefon parinte      " + tabDataSet.Persoana[0]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"] != null && tabDataSet.Persoana[0]["T2"].Equals("") == false)
            {
                richTextBox4.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0]["datai"].ToString().Trim());
            richTextBox4.Text += "Data inscriere        " + v.Date.ToShortDateString()
                + "\n" + "Tip dansator      ";
            if (tabDataSet.Persoana[0]["Tip"].Equals(1) == true)
            {
                richTextBox4.Text += "Incepator" + "\n";
            }
            else
            {
                richTextBox4.Text += "Avansat" + "\n";
            }
            richTextBox4.Text += "Descriere echipament \n" + echipamentTableAdapter.Descriere(a);
            monthCalendar5.SetDate(DateTime.Parse(tabDataSet.Persoana[0]["idt"].ToString()));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (comboBox10.Text == "")
            {
                label31.Visible = true;
            }
            else
            {
                string[] x = new string[2];
                x = comboBox10.Text.Split(' ');
                if (x.Count() >= 3)
                {
                    int i = 3;
                    do
                    {
                        x[1] = x[1] + " " + x[i - 1];
                        i++;
                    } while (i <= x.Count());
                }
                persoanaTableAdapter.Fill(tabDataSet.Persoana);
                int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
                persoanaTableAdapter.PlataTaxa(DateTime.Parse(monthCalendar5.SelectionRange.Start.Date.ToString()), a);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = persoanaTableAdapter.NrPersoaneActive().ToString();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void persoaneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void echipamentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void taxaClubToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void concursuriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage16_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage15_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar5_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar4_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage17_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage18_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tabPage19_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tabPage20_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tabPage21_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tabPage14_Click(object sender, EventArgs e)
        {

        }

        private void dansBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void persoanaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void echipamentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void crearePerecheToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            int v = textBox10.Text.Count();
            int a,b,c;
            if(textBox10.Text==""||textBox12.Text==""||comboBox12.Text==""||comboBox11.Text==""||comboBox13.Text==""||comboBox14.Text==""||int.TryParse(textBox12.Text.ToString(),out c)==false||v!=13)
            {
                label43.Visible = true;
            }
            else
            {
                string s;
                if(comboBox11.Text.ToString()=="S"||comboBox12.Text.ToString()=="S")
                {
                    s = "S";
                }
                else
                {
                    if (comboBox11.Text.ToString()== "A"|| comboBox12.Text.ToString() == "A")
                        {
                            s = "A";
                        }
                    else
                    {
                        if (comboBox11.Text.ToString() == "B" || comboBox12.Text.ToString() == "B")
                        {
                            s = "B";
                        }
                        else
                        {
                            if (comboBox11.Text.ToString() == "C" || comboBox12.Text.ToString() == "C")
                            {
                                s = "C";
                            }
                            else
                            {
                                if (comboBox11.Text.ToString() == "D" || comboBox12.Text.ToString() == "D")
                                {
                                    s = "D";
                                }
                                else
                                {
                                    if (comboBox11.Text.ToString() == "E" || comboBox12.Text.ToString() == "E")
                                    {
                                        s = "E";
                                    }
                                    else
                                    {
                                        if (comboBox11.Text.ToString() == "Hobby" || comboBox12.Text.ToString() == "Hobby")
                                        {
                                            s = "Hobby";
                                        }
                                        else
                                        {
                                            s = "Precompetitional";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if(comboBox13.Text=="Da")
                {
                    a = 1;
                }
                else
                {
                    a = 0;
                }
                if(comboBox14.Text=="Da")
                {
                    b = 1;
                }
                else
                {
                    b = 0;
                }
                dansTableAdapter.CreareCarnet(int.Parse(label45.Text.ToString()), c, textBox10.Text.ToString().Trim(), comboBox12.Text.ToString(), comboBox11.Text.ToString(), s, (int)(numericUpDown1.Value),(int)( numericUpDown2.Value),(int)( numericUpDown3.Value), a, b);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void creareCarnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox15.Items.Clear();
            persoanaTableAdapter.PersoaneActive(tabDataSet.Persoana);
            DataTable dt = tabDataSet.Persoana;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                comboBox15.Items.Add(dt.Rows[i]["Nume"].ToString().Trim() + " " + dt.Rows[i]["Prenume"].ToString().Trim());
            }
            comboBox15.Sorted = true;
            richTextBox5.Text = "";
            tabControl1.SelectedIndex = 16;
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox15.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            dansTableAdapter.ReturnareDupaId(tabDataSet.Dans, a);
            if (tabDataSet.Dans.Rows.Count != 0)
            {
                if(MessageBox.Show("Acest dansator detine deja un carnet de dans. Doriti sa creati unul nou?     \n       Datele despre carnetul anterior vor fi sterse complet si chiar daca renuntati la crearea carnetului nou nu pot fi recuperate", "Creare Carnet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dansTableAdapter.StergereCarnet(a);
                    textBox10.Text = "";
                    label43.Visible = false;
                    textBox12.Text = "";
                    comboBox11.Text = "";
                    comboBox11.SelectedIndex = -1;
                    comboBox12.Text = "";
                    comboBox12.SelectedIndex = -1;
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    numericUpDown3.Value = 0;
                    comboBox13.Text = "";
                    comboBox13.SelectedIndex = -1;
                    comboBox14.Text = "";
                    comboBox14.SelectedIndex = -1;
                    tabControl3.SelectedIndex = 0;
                    tabControl1.SelectedIndex = 15;
                    label45.Text = a.ToString();
                }
            }
            else
            {
                textBox10.Text = "";
                label43.Visible = false;
                textBox12.Text = "";
                comboBox11.Text = "";
                comboBox11.SelectedIndex = -1;
                comboBox12.Text = "";
                comboBox12.SelectedIndex = -1;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
                comboBox13.Text = "";
                comboBox13.SelectedIndex = -1;
                comboBox14.Text = "";
                comboBox14.SelectedIndex = -1;
                tabControl3.SelectedIndex = 0;
                tabControl1.SelectedIndex = 15;
                label45.Text = a.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox15.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            richTextBox5.Text = x[0].Trim() + " " + x[1].Trim() + "\n" + "Telefon parinte      " + tabDataSet.Persoana[0]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"] != null && tabDataSet.Persoana[0]["T2"].Equals("") == false)
            {
                richTextBox5.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0]["datai"].ToString().Trim());
            richTextBox5.Text += "Data inscriere        " + v.Date.ToShortDateString()
                + "\n" + "Tip dansator      ";
            if (tabDataSet.Persoana[0]["Tip"].Equals(1) == true)
            {
                richTextBox5.Text += "Incepator" + "\n";
            }
            else
            {
                richTextBox5.Text += "Avansat" + "\n";
            }
            richTextBox5.Text += "Descriere echipament \n" + echipamentTableAdapter.Descriere(a);
        }

        private void taxaClubToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox6.Text = "";
            label46.Text = "Taxa club";
            comboBox17.Enabled = false;
            comboBox16.Text = "";
            comboBox16.SelectedIndex = -1;
            persoanaTableAdapter.PersoaneActive(tabDataSet.Persoana);
            tabControl1.SelectedIndex = 12;
        }

        private void taxaFRDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox6.Text = "";
            label46.Text = "Taxa FRDS";
            comboBox16.Text = "";
            comboBox16.SelectedIndex = -1;
            comboBox17.Enabled = false; 
            tabControl1.SelectedIndex = 12;
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox6.Text = "";
            comboBox17.Items.Clear();
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            DataTable dt=tabDataSet.Persoana;
            dansTableAdapter.Fill(tabDataSet.Dans);
            DataTable gt = tabDataSet.Dans;
            if(label46.Text=="Taxa FRDS")
            {
                if (comboBox16.SelectedIndex == 0)
                {
                    for(int i=0;i<gt.Rows.Count;i++)
                    {
                        if (dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["datai"].Equals(dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["dataf"]) == true)
                        {
                            if ((int)gt.Rows[i]["Viza"]==1)
                            {
                                comboBox17.Items.Add(dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["Nume"].ToString().Trim() + " " + dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["Prenume"].ToString().Trim());
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gt.Rows.Count; i++)
                    {
                        if (dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["datai"].Equals(dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["dataf"]) == true)
                        {
                            if ((int)gt.Rows[i]["Viza"] == 0)
                            {
                                comboBox17.Items.Add(dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["Nume"].ToString().Trim() + " " + dt.Rows[(int)(gt.Rows[i]["Id"]) - 1]["Prenume"].ToString().Trim());
                            }
                        }
                    }
                }
            }
            else
            {
                if(comboBox16.SelectedIndex==0)
                {
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        if((DateTime)(dt.Rows[i]["idt"])>DateTime.Today.Date)
                        {
                            comboBox17.Items.Add(dt.Rows[i]["Nume"].ToString().Trim() + " " + dt.Rows[i]["Prenume"].ToString().Trim());
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((DateTime)(dt.Rows[i]["idt"]) <= DateTime.Today.Date)
                        {
                            comboBox17.Items.Add(dt.Rows[i]["Nume"].ToString().Trim() + " " + dt.Rows[i]["Prenume"].ToString().Trim());
                        }
                    }
                }
            }
            persoanaTableAdapter.PersoaneInactive(tabDataSet.Persoana);
            dt = tabDataSet.Persoana;
            for(int i=0;i<comboBox17.Items.Count;i++)
            {
                for(int j=0;j<dt.Rows.Count;j++)
                {
                    if(comboBox17.Items[i].Equals(dt.Rows[j]["Nume"].ToString().Trim() + " " + dt.Rows[j]["Prenume"].ToString().Trim())==true)
                    {
                        comboBox17.Items.RemoveAt(i);
                        break;
                    }
                }
            }
            comboBox17.Sorted = true;
            comboBox17.Enabled = true;
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] x = new string[2];
            x = comboBox17.Text.Split(' ');
            if (x.Count() >= 3)
            {
                int i = 3;
                do
                {
                    x[1] = x[1] + " " + x[i - 1];
                    i++;
                } while (i <= x.Count());
            }
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            int a = (int)(persoanaTableAdapter.ReturnareIdDupaNume(x[0].Trim(), x[1].Trim()));
            persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, a);
            richTextBox6.Text = x[0].Trim() + " " + x[1].Trim() + "\n" + "Telefon parinte      " + tabDataSet.Persoana[0]["T1"].ToString().Trim() + "\n";
            if (tabDataSet.Persoana[0]["T2"] != null && tabDataSet.Persoana[0]["T2"].Equals("") == false)
            {
                richTextBox6.Text += "Telefon sportiv       " + tabDataSet.Persoana[0]["T2"].ToString().Trim() + "\n";
            }
            DateTime v = DateTime.Parse(tabDataSet.Persoana[0]["datai"].ToString().Trim());
            richTextBox6.Text += "Data inscriere        " + v.Date.ToShortDateString()
                + "\n" + "Tip dansator      ";
            if (tabDataSet.Persoana[0]["Tip"].Equals(1) == true)
            {
                richTextBox6.Text += "Incepator" + "\n";
            }
            else
            {
                richTextBox6.Text += "Avansat" + "\n";
            }
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            dansTableAdapter.Fill(tabDataSet.Dans);
            DataTable dt = tabDataSet.Dans;
            int a;
            for (int i=0;i<dt.Rows.Count;i++)
            {
                string s = dt.Rows[i]["cnp"].ToString();
                a = 1900+(s[1]-'0')*10+(s[2]-'0');
                if (a < 1990)
                {
                    a = a - 1900 + 2000;
                }
                if(int.Parse(numericUpDown4.Value.ToString())==(int)(DateTime.Today.Year)-a)
                {
                    persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, (int)(dt.Rows[i]["Id"]));
                    string t;
                    DataTable bt = tabDataSet.Persoana;
                    if ((int)(bt.Rows[0]["tip"]) == 1)
                    {
                        t = "Avansati";
                    }
                    else
                    {
                        t = "Incepatori";
                    }
                    dataGridView1.Rows.Add(bt.Rows[0]["Nume"].ToString(), bt.Rows[0]["Prenume"].ToString(),t, dt.Rows[i]["nrc"].ToString());
                }
            }
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            persoanaTableAdapter.Fill(tabDataSet.Persoana);
            dansTableAdapter.Fill(tabDataSet.Dans);
            DataTable dt = tabDataSet.Dans;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["cmx"].ToString().Trim() == comboBox18.Text.ToString().Trim())
                {
                    persoanaTableAdapter.ReturnarePersoanaDupaId(tabDataSet.Persoana, (int)(dt.Rows[i]["Id"]));
                    string s;
                    DataTable bt = tabDataSet.Persoana;
                    if ((int)(bt.Rows[0]["tip"]) == 1)
                    {
                        s = "Avansati";
                    }
                    else
                    {
                        s = "Incepatori";
                    }
                    dataGridView2.Rows.Add(bt.Rows[0]["Nume"].ToString(), bt.Rows[0]["Prenume"].ToString(), s, dt.Rows[i]["nrc"].ToString(), dt.Rows[i]["cst"].ToString(), dt.Rows[i]["cla"].ToString());

                }
            }
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
