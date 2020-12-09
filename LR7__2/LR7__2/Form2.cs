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
    public partial class Form2 : Form
    {
        public Form form;
        public Account account;

        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            this.form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (account.SumRub == 0) return;
            int val = int.Parse(account.SumRub.ToString());
            MessageBox.Show(RusNumber.Str(val));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            obshiySchet.Text = account.SumRub.ToString();
            obshiySchet2.Text = account.SumRub.ToString();
            fio.Text = account.Surname;
            iniziali.Text = account.Surname;

            nomerscheta.Text = Convert.ToString(account.Schet);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox2.Text.ToString());
            account.SumRub -= a;
            obshiySchet.Text = account.SumRub.ToString();
            obshiySchet2.Text = account.SumRub.ToString();
            MessageBox.Show(
            "Успешно!",
            "Снять деньги");
            textBox2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int b = int.Parse(textBox1.Text);
            account.SumRub += b;
            obshiySchet.Text = account.SumRub.ToString();
            obshiySchet2.Text = account.SumRub.ToString();
            MessageBox.Show(
            "Успешно!",
            "Положить деньги");
            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            MessageBox.Show((account.SumRub / 78).ToString() + " $", "Доллары");
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show((account.SumRub / 90).ToString() + " €", "Евро");
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox3.Text);




            MessageBox.Show(((account.SumRub / 100) * (100 + i)).ToString() + " рублей", "Начисление процентов");

            account.SumRub = ((account.SumRub / 100) * (100 + i));
            obshiySchet.Text = account.SumRub.ToString();
            obshiySchet2.Text = account.SumRub.ToString();
            textBox3.Text = "";


        }

        private void nomerscheta_Click(object sender, EventArgs e)
        {
            
        }
    }
}
public class RusNumber
    {
        //Наименования сотен
        private static string[] hunds =
        {
            "", "сто ", "двести ", "триста ", "четыреста ",
            "пятьсот ", "шестьсот ", "семьсот ", "восемьсот ", "девятьсот "
        };
        //Наименования десятков
        private static string[] tens =
        {
            "", "десять ", "двадцать ", "тридцать ", "сорок ", "пятьдесят ",
            "шестьдесят ", "семьдесят ", "восемьдесят ", "девяносто "
        };
        /// <summary>
        /// Перевод в строку числа с учётом падежного окончания относящегося к числу существительного
        /// </summary>
        /// <param name="val">Число</param>
        /// <param name="male">Род существительного, которое относится к числу</param>
        /// <param name="one">Форма существительного в единственном числе</param>
        /// <param name="two">Форма существительного от двух до четырёх</param>
        /// <param name="five">Форма существительного от пяти и больше</param>
        /// <returns></returns>
        public static string Str(int val, bool male, string one, string two, string five)
        {
            string[] frac20 =
            {
                "", "один ", "два ", "три ", "четыре ", "пять ", "шесть ",
                "семь ", "восемь ", "девять ", "десять ", "одиннадцать ",
                "двенадцать ", "тринадцать ", "четырнадцать ", "пятнадцать ",
                "шестнадцать ", "семнадцать ", "восемнадцать ", "девятнадцать "
            };

            int num = val % 1000;
            if (0 == num) return "";
            if (num < 0) throw new ArgumentOutOfRangeException("val", "Параметр не может быть отрицательным");
            if (!male)
            {
                frac20[1] = "одна ";
                frac20[2] = "две ";
            }

            StringBuilder r = new StringBuilder(hunds[num / 100]);

            if (num % 100 < 20)
            {
                r.Append(frac20[num % 100]);
            }
            else
            {
                r.Append(tens[num % 100 / 10]);
                r.Append(frac20[num % 10]);
            }

            r.Append(Case(num, one, two, five));

            if (r.Length != 0) r.Append(" ");
            return r.ToString();
        }
        /// <summary>
        /// Выбор правильного падежного окончания сущесвительного
        /// </summary>
        /// <param name="val">Число</param>
        /// <param name="one">Форма существительного в единственном числе</param>
        /// <param name="two">Форма существительного от двух до четырёх</param>
        /// <param name="five">Форма существительного от пяти и больше</param>
        /// <returns>Возвращает существительное с падежным окончанием, которое соответсвует числу</returns>
        public static string Case(int val, string one, string two, string five)
        {
            int t = (val % 100 > 20) ? val % 10 : val % 20;

            switch (t)
            {
                case 1: return one;
                case 2: case 3: case 4: return two;
                default: return five;
            }
        }
        /// <summary>
        /// Перевод целого числа в строку
        /// </summary>
        /// <param name="val">Число</param>
        /// <returns>Возвращает строковую запись числа</returns>
        public static string Str(int val)
        {
            bool minus = false;
            if (val < 0) { val = -val; minus = true; }

            int n = (int)val;

            StringBuilder r = new StringBuilder();

            if (0 == n) r.Append("0 ");
            if (n % 1000 != 0)
                r.Append(RusNumber.Str(n, true, "", "", ""));

            n /= 1000;

            r.Insert(0, RusNumber.Str(n, false, "тысяча", "тысячи", "тысяч"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "миллион", "миллиона", "миллионов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "миллиард", "миллиарда", "миллиардов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "триллион", "триллиона", "триллионов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "триллиард", "триллиарда", "триллиардов"));
            if (minus) r.Insert(0, "минус ");

            //Делаем первую букву заглавной
            r[0] = char.ToUpper(r[0]);

            return r.ToString();
        }
    
}


