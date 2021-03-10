using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Core.Models;

namespace Core.Services
{
    public class FirebaseHelper
    {
        private readonly string ChildName = "Recipes";
        private readonly FirebaseClient firebase = new FirebaseClient(@"https://recipe-app-a8b16-default-rtdb.europe-west1.firebasedatabase.app/");

        public async Task<List<Recipe>> GetAllRecipes()
        {
            //var objects = await firebase.Child(ChildName).OnceAsync<Recipe>();
            //List<Recipe> recipes = new List<Recipe>();
            //foreach(FirebaseObject<Recipe> r in objects)
            //{

            //}
            return (await firebase.Child(ChildName).OnceAsync<Recipe>()).Select(item => item.Object).ToList();
        }

        public async Task AddRecipe(Recipe r)
        {
            await firebase.Child(ChildName).PostAsync(r);
        }

        public async Task<Recipe> GetRecipe(string personId)
        {
            var allPersons = await GetAllRecipes();
            await firebase
                .Child(ChildName)
                .OnceAsync<Recipe>();
            return allPersons.FirstOrDefault(a => a.Id == personId);
        }

        public async Task DeleteRecipe(string personId)
        {
            var toDeletePerson = (await firebase
                .Child(ChildName)
                .OnceAsync<Recipe>()).FirstOrDefault(a => a.Object.Id == personId);
            await firebase.Child(ChildName).Child(toDeletePerson.Key).DeleteAsync();
        }
    }
}
