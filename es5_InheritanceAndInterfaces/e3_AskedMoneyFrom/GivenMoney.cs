using System;
using System.Collections.Generic;
using System.Text;

namespace e3_AskedMoneyFrom
{
    class GivenMoney
    {
        public GivenMoney(double money, string message)
        {
            Money = money;
            Message = message;
        }

        public double Money { get; }
        public string Message { get; }
    }
}
