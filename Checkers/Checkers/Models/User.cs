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

        public User(string username, int wins, int loses, TimeSpan playedTime)
        {
            Username = username;
            Wins = wins;
            Loses = loses;
            PlayedTime = playedTime;
        }

        public string Username { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public TimeSpan PlayedTime { get; set; }
    }
}
