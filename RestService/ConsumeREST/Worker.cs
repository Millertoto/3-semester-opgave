using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModelLibB.model;
using Newtonsoft.Json;

namespace ConsumeREST
{
    class Worker
    {
        private static string URI = "http://bookapiexercise.azurewebsites.net/api/Books";
        static HttpClient client = new HttpClient();
        public async void Start()
        {

        }

        public async Task<IList<Book>> GetAllBooksAsync()
        {

            using (client)
            {
                string content = await client.GetStringAsync(URI);
                IList<Book> cList =
                    JsonConvert.DeserializeObject<IList<Book>>(content);
                return cList;
            }

        }

        //public async Task<Book> GetSpecificBookAsync(string ISBN)
        //{
        //    using (client)
        //    {


        //        string content = await client.GetStringAsync(URI);
        //        if (content != null)
        //        {
        //            IList<Book> cBook =
        //                JsonConvert.DeserializeObject<IList<Book>>(content);
        //            return cBook;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //}

        static async Task<Uri> PostBookAsync(Book book)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Books", book);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        static async Task<Book> UpdateBookAsync(Book book)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Books/{book.ISBN}", book);
            response.EnsureSuccessStatusCode();

            book = await response.Content.ReadAsAsync<Book>();
            return book;
        }

        static async Task<HttpStatusCode> DeleteBookAsync(string ISBN)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Books/{ISBN}");
            return response.StatusCode();
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://bookapiexercise.azurewebsites.net/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));

            try
            {
                Book book = new Book
                {
                    Title = "The Kings Ranger",
                    Author = "John Flanagan",
                    PageNR = 465,
                    ISBN = "1234567890987"
                };

                var url = await PostBookAsync(book);
                Console.WriteLine($"Created at {url}");
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
