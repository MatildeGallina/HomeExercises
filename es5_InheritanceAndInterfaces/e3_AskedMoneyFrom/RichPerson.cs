using System;
using System.Collections.Generic;
using System.Text;

namespace e3_AskedMoneyFrom
{
    class RichPerson : Person
    {
        public RichPerson(string name, double money, double moneyAsked, int count)
            : base(name, money, moneyAsked, count)
        { }

        public override void AskedMoneyFrom(Person p)
        {
            if (this.MoneyAsked > this.Money)
            {
                GivenMoney gm = new GivenMoney(0, $"{Name}: 'Non posso, ho perso tutti i miei soldi...'");
                p.AcceptMoney(gm);
                this.Money -= gm.Money;
            }
            else
            {
                GivenMoney gm = new GivenMoney(this.MoneyAsked, $"{Name}: 'Tieni poraccio tanto non so che farmene'");
                p.AcceptMoney(gm);
                this.Money -= gm.Money;
            }
        }
    }
}
