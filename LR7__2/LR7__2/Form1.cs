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
    public partial class Form1 : Form
    {
        Form2 f2;
        bool flag;
        public static ListAccounts ListAccounts = new ListAccounts();
        public Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Все поля обязательны к заполнению!");
            }
            else
            {
                foreach (Account account in ListAccounts.accounts)
                {
                    if (textBox1.Text == account.Surname && textBox2.Text == account.Password)
                    {
                        f2 = new Form2();
                        f2.account = account;
                        f2.form = this;

                        f2.Show();
                        this.Hide();
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string osnova = textBox1.Text;
        }

        private void regKnopka_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Все поля обязательны к заполнению!");
            }
            else
            {
                
                ListAccounts.accounts.Add(new Account(textBox1.Text, random.Next(100000, 999999), 0, random.Next(0, 1000000), textBox2.Text));
                MessageBox.Show("Успешно");
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();     
            f4.Show();
            f4.form = this;
            this.Hide();
            
        }
    }
}
