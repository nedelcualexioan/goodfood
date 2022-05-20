using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace recipes
{
    public class ControllerRecipes : IController
    {
        private List<Recipe> recipes;
        public ControllerRecipes()
        {
            recipes = new List<Recipe>();

            Read();
        }

        public int Count
        {
            get => this.Count;
        }

        public override String ToString()
        {
            String text = "";

            foreach (Recipe recipe in recipes)
            {
                text += recipe.ToString();
                text += "\n";
            }

            return text;
        }

        public void Add(Object obj)
        {
            if (obj is Recipe recipe)
            {
                recipes.Add(recipe);
            }
        }

        public Object GetItem(int index)
        {
            return recipes[index];
        }

        public void Read()
        {
            StreamReader read = new StreamReader(AppDomain.CurrentDomain.BaseDirectory.Replace(@"goodfood\bin\Debug", "") + @"recipes\Db\recipes.txt");

            String line = "";

            while ((line = read.ReadLine()) != null)
            {
                recipes.Add(new Recipe(line));
            }

            read.Close();
        }

        private String Properties()
        {
            String text = "";

            foreach (Recipe recipe in recipes)
            {
                text += recipe.Properties();
                text += "\n";
            }

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory.Replace(@"goodfood\bin\Debug", "") + @"recipes\Db\recipes.txt");
            write.WriteLine(Properties());

            write.Close();
        }
    }
}