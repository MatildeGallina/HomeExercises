using System;
using System.Collections.Generic;
using System.Text;

namespace e3_AskedMoneyFrom
{
    class NunPerson : Person
    {
        public NunPerson(string name, double money, double moneyAsked, int count)
            : base(name, money, moneyAsked, count)
        { }

        public override void AskedMoneyFrom(Person p)
        {
            if(this.MoneyAsked > this.Money)
            {
                GivenMoney gm = new GivenMoney(0, $"{Name}: 'Non posso, non ho abbastanza soldi...'");
                p.AcceptMoney(gm);
                this.Money -= gm.Money;
            }
            else
            {
                if (p.Count > 3)
                {
                    GivenMoney gm = new GivenMoney(0, $"{Name}: 'Ti ho già prestato {this.MoneyAsked * 3}! No!'");
                }
                else
                {
                    GivenMoney gm = new GivenMoney(this.MoneyAsked, $"{Name}: 'Ma ricordati di tornarmeli!'");
                    p.AcceptMoney(gm);
                    this.Money -= gm.Money;
                }
            }
        }
    }
}
