using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.InterFaces
{
    interface IMasterCard
    {
        public void OverDraft(int amount);
    }
}
