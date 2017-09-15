using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubPlusAlarm
{
    public static class  Whats_Next
    {
        public static int Randomnumber( int k)
        {
            Random random= new Random();

            return random.Next(0, k);
        }

        public static int[] ListofPrimes()
        {
            int[] A = new int[200];
            A[0] = 2;
            A[1] = 3;
            A[2]=5;
            int k=3;
            int testNumber = 7;
            while (k<200)
            { 
                for (int j = 0; j < k; j++)
                {
                    if ((testNumber % A[j]) == 0)
                    {
                        testNumber++;
                        break;
                    }
                    if(j==k-1)
                    {
                        A[k]=testNumber ;
                        k++;
                    }
                }
            }
            return A;
        } 

        public static int difficulty(int x)
        {
            if (x == 0)
                return 25;
            else if (x == 1)
                return 50;
            else if (x == 2)
                return 100;
            else
                return 200;
        }
    }
    }

