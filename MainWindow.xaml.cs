using System;
using System.Collections.Generic;
using System.Windows;

namespace AutumnRepeatExam
{
    public partial class MainWindow : Window
    {
        private static readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Member> generatedMembers = RandomMemberGenerator();
            List<Team> teams = MemberCount(generatedMembers);

            lbxTeams.ItemsSource = teams;
            lbxSwimmers.ItemsSource = generatedMembers;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            List<Member> generatedMembers = RandomMemberGenerator();
            List<Team> teams = MemberCount(generatedMembers);

            lbxSwimmers.ItemsSource = generatedMembers;
        }

        private List<Member> RandomMemberGenerator()
        {
            List<string> firstNames = new List<string>
            {
                "James", "Jack", "Daniel", "Conor", "Sean", "Noah", "Adam", "Michael", "Charlie", "Thomas",
                "Emily", "Emma", "Sophie", "Grace", "Ava", "Amelia", "Olivia", "Ella", "Hannah", "Lucy"
            };

            List<string> lastNames = new List<string>
            {
                "Murphy", "Smith", "O'Kelly", "Byrne", "O'Sullivan", "O'Connor", "McCarthy", "Walsh", "O'Brien",
                "Ryan", "MacGabhann", "Ni Mhurchu", "O'Riain", "Mac Gabhann", "Ni Riain", "Mac Carthaigh",
                "Ni Carthaigh", "O'Dalaigh", "Ni Dhalaigh", "O'Dalaigh"
            };

            List<Member> generatedMembers = new List<Member>();

            foreach (string firstName in firstNames)
            {
                string lastName = lastNames[random.Next(lastNames.Count)];
                DateTime dob = new DateTime(random.Next(2005, 2012), random.Next(1, 13), random.Next(1, 29));
                generatedMembers.Add(new Member(firstName, lastName, dob));
            }

            return generatedMembers;
        }

        private List<Team> MemberCount(List<Member> members)
        {
            List<Team> teams = new List<Team>
            {
                new Team("Senior"),
                new Team("U18"),
                new Team("U16"),
                new Team("U14")
            };

            foreach (Member member in members)
            {
                if (member.GetAge() >= 18)
                {
                    teams[0].players.Add(member);
                }
                else if (member.GetAge() >= 16)
                {
                    teams[1].players.Add(member);
                }
                else if (member.GetAge() >= 14)
                {
                    teams[2].players.Add(member);
                }
                else if (member.GetAge() < 14)
                {
                    teams[3].players.Add(member);
                }
            }

            return teams;
        }
    }

    internal class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public Member(string firstName, string lastName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
        }

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

        public override string ToString()
        {
            return $"{LastName}, {FirstName} - {DOB:MM/dd/yyyy} ({GetAge()} years old)";
        }
    }


}
