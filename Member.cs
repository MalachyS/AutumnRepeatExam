using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnRepeatExam
{
    internal class Member
    {
        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public DateTime DOB { get; set; }
        //Constructors
        public Member(string firstName, string lastName, DateTime dOB)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dOB;
        }
        public Member() { }

        
        public override string ToString()
        {
            return $"{LastName}, {FirstName} - {DOB}"; //This makes the data actually display in the LBX
        }



    }
    
}
