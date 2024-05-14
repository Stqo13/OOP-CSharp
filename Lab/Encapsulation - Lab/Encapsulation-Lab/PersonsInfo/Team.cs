using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        public Team(string name)
        {
			this.Name = name;
			firstTeam = new List<Person>();
			reserveTeam = new List<Person>();
        }
        private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private List<Person> firstTeam;

		public IReadOnlyCollection<Person> FirstTeam
		{
			get { return firstTeam.AsReadOnly(); }
		}

		private List<Person> reserveTeam;

		public IReadOnlyCollection<Person> ReserveTeam
        {
			get { return reserveTeam.AsReadOnly(); }
		}
		public void AddPlayer(Person person)
		{
			if (person.Age<40)
			{
				firstTeam.Add(person);
			}
			else
			{
				reserveTeam.Add(person);
			}
		}
	}
}
