using System;
using System.Collections;

internal class Member : IComparable<Member>
{
    // Properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }

    // Constructors
    public Member(string firstName, string lastName, DateTime dOB)
    {
        FirstName = firstName;
        LastName = lastName;
        DOB = dOB;
    }

    public Member() { }

    // Method to calculate age
    public int GetAge()
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - DOB.Year;

        if (currentDate.Month < DOB.Month || (currentDate.Month == DOB.Month && currentDate.Day < DOB.Day))
        {
            age--;
        }

        return age;
    }

    public int CompareTo(Member other)
    {
        if (other == null)
        {
            return 1; // Null objects are considered greater
        }

        return string.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
    }

    // Override ToString method
    public override string ToString()
    {
        int age = GetAge();
        return $"{LastName}, {FirstName} - {DOB:MM/dd/yyyy} ({age})";
    }
}
