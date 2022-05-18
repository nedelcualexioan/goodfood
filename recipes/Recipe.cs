using System;
using System.Linq;

namespace recipes
{
    public class Recipe
    {
        private int id;
        private String title;
        private String picture;
        private String prepTime;
        private String cookTime;
        private String yield;
        private int rating;
        private String tags;
        private String ingredients;
        private String steps;

        public Recipe(int id, String title, String picture, String prepTime, String cookTime, String yield, int rating, String tags, String ingredients, String steps)
        {
            this.id = id;
            this.title = title;
            this.picture = picture;
            this.prepTime = prepTime;
            this.cookTime = cookTime;
            this.yield = yield;
            this.rating = rating;
            this.tags = tags;
            this.ingredients = ingredients;
            this.steps = steps;
        }

        public Recipe(String line)
        {
            String[] split = line.Split();

            title = split[0];
            picture = split[1];
            prepTime = split[2];
            cookTime = split[3];
            yield = split[4];
            rating = int.Parse(split[5]);
            tags = split[6];
            ingredients = split[7];
            steps = split[8];

        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        public String Title
        {
            get => title;
            set => title = value;
        }

        public String Picture
        {
            get => picture;
            set => picture = value;
        }

        public String PrepTime
        {
            get => prepTime;
            set => prepTime = value;
        }

        public String CookTime
        {
            get => cookTime;
            set => cookTime = value;
        }

        public String Yield
        {
            get => yield;
            set => yield = value;
        }

        public int Rating
        {
            get => rating;
            set => rating = value;
        }

        public String Tags
        {
            get => tags;
            set => tags = value;
        }

        public String Ingredients
        {
            get => ingredients;
            set => ingredients = value;
        }

        public String Steps
        {
            get => steps;
            set => steps = value;
        }

        public String Properties()
        {
            String[] array = new String[]
            {
                id.ToString(), title, picture, prepTime, cookTime, yield, rating.ToString(), tags, ingredients, steps
            };

            return String.Join(",", array);
        }
    }
}