using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHAA3209
{
    static class Randomizer
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static Random r = new Random();

        public static string CreateFirstName()
        {
            string firstname = "";
            int size = 4;
            for (int i = 0;i < size; i++)
            {
                int x = r.Next(26);
                firstname += chars[x];
            }
            Thread.Sleep(1);
            return firstname;
        }
        public static string CreateLastName()
        {
            string lastname = "";
            int size = 10;
            for (int i = 0; i < size; i++)
            {
                int x = r.Next(26);
                lastname += chars[x];
            }
            Thread.Sleep(1);
            return lastname;
        }
    }
}
