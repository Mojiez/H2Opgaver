using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    class Debet : Card
    {
        public Debet(string name, Type type, string accountNumber, string number) : base(name, type, accountNumber, number)
        {
        }
    }
}
