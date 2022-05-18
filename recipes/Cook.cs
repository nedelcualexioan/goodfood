using System;

namespace recipes
{
    public class Cook : User
    {
        private int experience;

        public Cook(int id, String type, string fullName, int age, string address, string username, string password, int experience) : base(id, type, fullName, age, address, username, password)
        {
            this.experience = experience;
        }

        public Cook(String line) : base(line)
        {
            experience = int.Parse(line.Split(",")[7]);
        }

        public int Experience
        {
            get => experience;
            set => experience = value;
        }
    }
}