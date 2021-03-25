using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public TimeSpan Time { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<Tag> Tags { get; set; }
        public int Servings { get; set; }
        public double Calories { get; set; }
        public Nutrition Nutrition { get; set; }
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public enum Tag
    {
        Breakfast,
        Lunch,
        Dinner,
        Dessert,
        Christmas,
        Easter,
        Thanksgiving
    }
}
