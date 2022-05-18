using System;
using System.Collections.Generic;
using System.IO;

namespace recipes
{
    public class ControllerUsers : IController
    {
        private List<User> users;

        public int Count
        {
            get => users.Count;
        }

        public ControllerUsers()
        {
            users = new List<User>();

            Read();
        }

        public override String ToString()
        {
            String text = "";

            foreach (User user in users)
            {
                text += user.ToString();
                text += "\n";
            }

            return text;
        }

        public void Add(Object obj)
        {
            if (obj is User user)
                users.Add(user);
        }

        public Object GetItem(int index)
        {
            return users[index];
        }

        public void Read()
        {
            StreamReader read = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "users.txt");

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                switch (line.Split(",")[0])
                {
                    case "Guest":
                        users.Add(new Guest(line));
                        break;
                    case "Cook":
                        users.Add(new Cook(line));
                        break;
                    default:
                        break;
                }
            }

            read.Close();
        }

        private String Properties()
        {
            String text = "";

            foreach (User user in users)
            {
                text += user.Properties();
                text += "\n";
            }

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "users.txt");
            
            write.Write(Properties());
            
            write.Close();
        }

    }
}