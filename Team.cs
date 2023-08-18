using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnRepeatExam
{
    internal class Team
    {
        public string Teamname { get; set; }
        public List<Member> players { get; set; } = new List<Member>();

        public Team(string name)
        {
            Teamname = name;
        }
        public override string ToString()     // Override ToString method to show data
        {
            return $"{Teamname} - ({players.Count}Members)";
        }
    }
}
