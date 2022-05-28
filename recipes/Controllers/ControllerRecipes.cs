using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            StreamReader read =
                new StreamReader(AppDomain.CurrentDomain.BaseDirectory.Replace(@"goodfood\bin\Debug", "") +
                                 @"recipes\Db\recipes.txt");

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
            StreamWriter write =
                new StreamWriter(AppDomain.CurrentDomain.BaseDirectory.Replace(@"goodfood\bin\Debug", "") +
                                 @"recipes\Db\recipes.txt");
            write.WriteLine(Properties());

            write.Close();
        }

        public List<Recipe> GetList()
        {
            return this.recipes;
        }

        public Recipe GetItem(String keyword)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Title.Contains(keyword))
                {
                    return recipe;
                }
            }

            return null;
        }

        public Recipe GetItemByTag(String tag)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Tags.Contains(tag))
                    return recipe;
            }

            return null;
        }

        public Recipe GetItemByIngredient(String ingredient)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Ingredients.Contains(ingredient))
                {
                    return recipe;
                }
            }

            return null;
        }

        public List<Recipe> GetResults(String keyword = null, String tag = null, String ingredient = null)
        {
            if (keyword != null && tag != null && ingredient != null)
            {
                return recipes.FindAll(s =>
                    s.Title.Contains(keyword) && s.Tags.Contains(tag) && s.Ingredients.Contains(ingredient));
            }
            else if (keyword != null && tag != null)
            {
                return recipes.FindAll(s => s.Title.Contains(keyword) && s.Tags.Contains(tag));
            }
            else if (keyword != null && ingredient != null)
            {
                return recipes.FindAll(s => s.Title.Contains(keyword) && s.Ingredients.Contains(ingredient));
            }

            return recipes.FindAll(s => s.Tags.Contains(tag) && s.Ingredients.Contains(ingredient));
        }


}
}