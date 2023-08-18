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

        private void Window_Loaded(object sender, RoutedEventArgs e) //this method means that there will be automatic generation of data
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

            lbxTeams.ItemsSource = teams;
            lbxSwimmers.ItemsSource = generatedMembers;
        }

        private List<Member> RandomMemberGenerator()
        {
            List<string> firstNames = new List<string> //All firstnames 
            {
                "James", "Jack", "Daniel", "Conor", "Sean", "Noah", "Adam", "Michael", "Charlie", "Thomas",
                "Emily", "Emma", "Sophie", "Grace", "Ava", "Amelia", "Olivia", "Ella", "Hannah", "Lucy"
            };

            List<string> lastNames = new List<string> // All lastNames
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

        private void lbxTeams_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lbxTeams.SelectedItem is Team selectedTeam)
            {
                switch (selectedTeam.Teamname)
                {
                    case "Senior":
                        lbxSwimmers.ItemsSource = selectedTeam.players;
                        break;
                    case "U18":
                        lbxSwimmers.ItemsSource = selectedTeam.players.FindAll(player => player.GetAge() <= 17);
                        break;
                    case "U16":
                        lbxSwimmers.ItemsSource = selectedTeam.players.FindAll(player => player.GetAge() <= 15);
                        break;
                    case "U14":
                        lbxSwimmers.ItemsSource = selectedTeam.players.FindAll(player => player.GetAge() <= 13);
                        break;
                    default:
                        lbxSwimmers.ItemsSource = null;
                        break;
                }
            }
        }
    }
}
