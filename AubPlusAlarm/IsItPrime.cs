using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubPlusAlarm
{
    public static class IsItPrime
    {
        public static bool Primebility(string x)
        {
            int testNumber = Convert.ToInt32(x);
            if (testNumber == 1)
                return false;
            else if ((testNumber == 2) || testNumber == 3)
                return true;
            else
            {
                int limit = Convert.ToInt32(Math.Ceiling(Math.Sqrt(testNumber)));
                for (int i = 2; i <= limit; i++)
                {
                    if ((testNumber % i) == 0)
                        return false;
                }

            }
            return true;
        }

        public static List<int> divisibleby(string x)
        {
            int testNumber = Convert.ToInt32(x);
            List<int> A = new List<int>();
            for (int i = 1; i < testNumber; i++)
                if ((testNumber % i) == 0)
                {
                    A.Add(i);
                }
            return A;

        }
    }
}
