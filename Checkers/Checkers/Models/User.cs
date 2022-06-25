using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class User
    {
        public User()
        {
            
        }

        public User(int number, string username, int wins, int loses, string playedTime)
        {
            Number = number;
            Username = username;
            Wins = wins;
            Loses = loses;
            TotalTime = playedTime;
        }

        public int Number { get; set; }
        public string Username { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public string TotalTime { get; set; }
    }
}
