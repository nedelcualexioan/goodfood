using System;
using System.Linq;

namespace recipes
{
    public abstract class User
    {
        private String type;
        private int id;
        private String full_name;
        private int age;
        private String address;
        private String username;
        private String password;

        

        protected User(int id, String type, String fullName, int age, String address, String username, String password)
        {
            this.type = type;
            this.id = id;
            full_name = fullName;
            this.age = age;
            this.address = address;
            this.username = username;
            this.password = password;
        }

        protected User(String line)
        {
            id = int.Parse(line.Split(',')[0]);
            type = line.Split(',')[1];
            full_name = line.Split(',')[2];
            age = int.Parse(line.Split(',')[3]);
            address = line.Split(',')[4];
            username = line.Split(',')[5];
            password = line.Split(',')[6];
        }

        public String Type
        {
            get => type;
            set => type = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public String FullName
        {
            get => full_name;
            set => full_name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public String Address
        {
            get => address;
            set => address = value;
        }

        public String Username
        {
            get => username;
            set => username = value;
        }

        public String Password
        {
            get => password;
            set => password = value;
        }

        public override String ToString()
        {
            String text = "";

            text += "ID: " + id + "\n";
            text += "Name: " + full_name + "\n";
            text += "Age: " + age + "\n";
            text += "Address: " + address + "\n";
            text += "Username: " + username + "\n";
            text += "Password: " + password + "\n";

            return text;
        }

        public String Properties()
        {
            String[] items = new string[] { id.ToString(), full_name, age.ToString(), address, username, password };

            return String.Join(",", items);
        }
    }
}