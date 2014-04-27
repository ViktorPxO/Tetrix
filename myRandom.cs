using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetrix
{
    class myRandom
    {
        Random rnd;
        LinkedList<int> randoms;
        int num;

        public myRandom() {
            rnd = new Random();
            randoms = new LinkedList<int>();

            for (int i = 0; i < 1000; i++) {
                randoms.AddFirst(rnd.Next() % 7);
            }
            num = 1000;
        }

        public int Next() {
            int retMe= randoms.First.Value;
            randoms.RemoveFirst();
            num--;
            if (num <= 10) {
                for (int i = 0; i < 1000; i++)
                {
                    randoms.AddFirst(rnd.Next() % 7);
                }
                num = 1000; 
            }
            return retMe;
        }

        public int getSecond() {
            return randoms.First.Value;
        }

        public int getThird() {
            return randoms.First.Next.Value;
        }

        public int getFourth() {
            return randoms.First.Next.Next.Value;
        }

    }
}
