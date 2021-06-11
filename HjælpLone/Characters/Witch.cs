using HjælpLone.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace HjælpLone.Characters
{
    // This class represents a Witch
    // It implements ICharacter to get the base implementation of a character
    // All other abilities is separated so its open for extention and closed for modification
    class Witch : ICharacter, IRaiseShield, IShieldGlare, ITeleport
    {
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

        public void Teleport(int x, int y)
        {
            Console.WriteLine("I'm teleporting to " + x + " " + y);
        }

    }
}
