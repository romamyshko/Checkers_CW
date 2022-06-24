using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class HistoryMove
    {
        public int Number { get; set; }
        public string Time { get; set; }
        public string Move { get; set; }

        public HistoryMove(int number, string time, string move)
        {
            Number = number;
            Time = time;
            Move = move;
        }
    }
}
