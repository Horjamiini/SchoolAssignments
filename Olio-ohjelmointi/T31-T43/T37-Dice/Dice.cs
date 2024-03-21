using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SHAA3209
{
    public class Dice
    {
        private Random rnd = new Random();
        private int number;
        public int Number { get { return number; } }

        public void RollDiceOnce()
        {
            number = rnd.Next(1,7);
        }
        public float RollDiceAverage(int rollcount)
        {
            int total = 0;
            for (int i = 0; i < rollcount; i++)
            {
                RollDiceOnce();
                total += number;
            }
            float average = (float)total / (float)rollcount;
            return average;
        }
        public string RollDiceWithCounts(int rollcount)
        {
            int result1 = 0;
            int result2 = 0;
            int result3 = 0;
            int result4 = 0;
            int result5 = 0;
            int result6 = 0;
            int total = 0;
            for (int i = 0; i < rollcount; i++)
            {
                RollDiceOnce();
                total += number;
                switch (number)
                {
                    case 1:
                        result1++;
                        break;
                    case 2:
                        result2++;
                        break;
                    case 3:
                        result3++;
                        break;
                    case 4:
                        result4++;
                        break;
                    case 5:
                        result5++;
                        break;
                    case 6:
                        result6++;
                        break;
                }

            }
            float average = (float)total/ (float)rollcount;
            return $"- average is {average}\n" +
                $"- 1 count is {result1}\n" +
                $"- 2 count is {result2}\n" +
                $"- 3 count is {result3}\n" +
                $"- 4 count is {result4}\n" +
                $"- 5 count is {result5}\n" +
                $"- 6 count is {result6}";
        }
    }
}
