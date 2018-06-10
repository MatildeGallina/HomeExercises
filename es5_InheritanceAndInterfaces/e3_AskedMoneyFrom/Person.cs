using System;
using System.Collections.Generic;
using System.Text;

namespace e3_AskedMoneyFrom
{
    abstract class Person
    {
        public Person(string name, double money, double moneyAsked, int count)
        {
            Name = name;
            Money = money;
            MoneyAsked = moneyAsked;
            Count = count;
        }

        public string Name { get; }
        public double Money { get; set; }
        public double MoneyAsked { get; set; }
        public int Count { get; set; }

        public void AskMoney(Person p)
        {
            Console.WriteLine($"{this.Name}: Chiede un prestito di {p.MoneyAsked} a {p.Name}.");
        }

        public abstract void AskedMoneyFrom(Person p);

        public void AcceptMoney(GivenMoney gm)
        {
            if(gm == null || gm.Money == 0)
                Console.WriteLine(Name + " received no money.");

            if (gm.Money < 0)
                throw new Exception ("Money di GivenMoney non può essere negativo.");

            Money += gm.Money;

            Console.WriteLine(gm.Message);
        }
    }
}
