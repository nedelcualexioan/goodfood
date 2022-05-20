using System;
using System.Collections.Generic;

namespace recipes
{
    public class Guest : User
    {
        private String favoriteRecipe;

        public Guest(int id, String type, String fullName, int age, String address, String username, String password, String favoriteRecipe = "") : base(id, type, fullName, age, address, username, password)
        {
            if (String.IsNullOrWhiteSpace(favoriteRecipe) == false) 
                this.favoriteRecipe = favoriteRecipe;
        }

        public Guest(String line) : base(line)
        {
            if (line.Split().Length > 7)
                favoriteRecipe = line.Split(',')[7];
        }

        public String FavoriteRecipe
        {
            get => favoriteRecipe;
            set => favoriteRecipe = value;
        }

        public override String ToString()
        {
            return base.ToString() + "Favorite recipe: " + favoriteRecipe + "\n";
        }
    }
}