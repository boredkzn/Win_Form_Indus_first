using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7__2
{
    public partial class Form4 : Form
    {
        public Form form;
        ListAccounts ListAccounts = new ListAccounts();
        int counter = 0;
        public Form4()
        {
            InitializeComponent();
            this.ListAccounts = Form1.ListAccounts;
            foreach(Account i in this.ListAccounts.accounts)
            {
                listBox1.Items.Add(i.Surname);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            counter++;
            button3.Text = Convert.ToString(counter);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "";

            for (int i = 0; i < this.ListAccounts.accounts.Count; i++)
            {
                if (Convert.ToString(listBox1.SelectedItem) == this.ListAccounts.accounts[i].Surname)
                {
                    label2.Text = this.ListAccounts.accounts[i].Password.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i <= this.ListAccounts.accounts.Count; i++)
            {
                
                if (Convert.ToString(listBox1.SelectedItem) == this.ListAccounts.accounts[i].Surname)
                {
                    MessageBox.Show("");
                    this.ListAccounts.accounts.Remove(this.ListAccounts.accounts[i]);
                }
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.form.Show();
        }
    }
}
