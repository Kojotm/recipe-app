using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Auth;
using Core.Models;

namespace Core.Services
{
    public class FirebaseDatabaseService
    {
        private readonly string ChildName = "Recipes";
        private readonly FirebaseClient firebase = new FirebaseClient(
        @"https://recipe-app-a8b16-default-rtdb.europe-west1.firebasedatabase.app/",
        new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => LoginAsync()
        });

        public async Task<List<Recipe>> GetAllRecipes()
        {
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

        public static async Task<string> LoginAsync()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(@"AIzaSyDn1o6wRBid1-ayS-zaedCTsQFG53CpQHc"));
            var thing = await authProvider.CreateUserWithEmailAndPasswordAsync(@"nukaneer@gmail.com", @"password1", "Kojot");
            var auth = await authProvider.SignInWithOAuthAsync(FirebaseAuthType.EmailAndPassword, "");
            // manage oauth login to Google / Facebook etc.
            // call FirebaseAuthentication.net library to get the Firebase Token
            // return the token
            return "";
        }
    }
}
