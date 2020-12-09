using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// фамилия владельца, номер счета, 
//процент начисления и сумма в рублях.
namespace LR7__2
{
    public class Account
    {
        public string Surname { get; set; }
        public int Schet { get; set; }
        public int Procenti { get; set; }
        
        public int SumRub { get; set; }

        public string Password { get; set; }


        public Account (string ser, int sch, int proc, int sum, string parol)
        {
            this.Surname = ser;
            this.Schet = sch;
            this.Procenti = proc;
            this.SumRub = sum;
            this.Password = parol;
        }



    }
}
