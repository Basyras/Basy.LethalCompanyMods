using System;
using System.Collections.Generic;
using System.Text;

namespace Basy.LethalCompany.Utilities.Helpers.Randoms
{
    public class RandomHelper
    {
        Random random = new Random();
        public int Int(int max)
        {
            return random.Next(max);
        }

        public int Int(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
