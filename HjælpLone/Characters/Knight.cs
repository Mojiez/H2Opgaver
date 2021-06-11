using HjælpLone.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HjælpLone.Characters
{
    // This class represents a Knight
    // It implements ICharacter to get the base implementation of a character
    // All other abilities is separated so its open for extention and closed for modification
    class Knight : ICharacter, IBash, ICleave, IRaiseShield, IShieldGlare, ISlash
    {
        public void Bash()
        {
            Console.WriteLine("I'm bashing someone");
        }

        public void Cleave()
        {
            Console.WriteLine("I'm cleaving someone");
        }

        public void Die()
        {
            Console.WriteLine("I'm dying");
        }

        public void Fight()
        {
            Console.WriteLine("I'm fighting");
        }

        public void Heal()
        {
            Console.WriteLine("I'm healing");
        }

        public void RaiseShield()
        {
            Console.WriteLine("I'm raising my shield");
        }

        public void ShieldGlare()
        {
            Console.WriteLine("I'm throwing shield glare");
        }

        public void Slash()
        {
            Console.WriteLine("I'm slashing someone");
        }
    }
}
