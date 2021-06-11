using System;
using System.Collections.Generic;
using System.Text;

namespace HjælpLone.Interface
{
    // This interface represents a base character
    public interface ICharacter
    {
        void Die();
        void Fight();
        void Heal();
    }
}
