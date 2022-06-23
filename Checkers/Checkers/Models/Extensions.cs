using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var rand = new Random();
            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = rand.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            } 
        }
    }
}
