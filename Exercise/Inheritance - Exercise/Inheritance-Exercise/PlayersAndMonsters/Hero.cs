using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string username, int level)
        {
			Username = username;
			Level = level;
        }
        private string username;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}
		private int level;

		public int Level
		{
			get { return level; }
			set { level = value; }
		}
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
