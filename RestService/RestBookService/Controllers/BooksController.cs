using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibB.model;

namespace RestBookService.Controllers
{
    [Route("api/localBooks")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>() 
        {
            new Book("The Kings Ranger", "John Flanagan", 465, "1234567890987"),
            new Book("Codex Astartes", "Roboute Guilliman", 10573, "9418951247361")
        };
        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("{ISBN}")]
        public Book GetSpecificBook(string ISBN)
        {
            return books.Find(i => i.ISBN == ISBN);
        }

        [HttpGet]
        [Route("{ISBN}")]
        public IEnumerable<Book> GetFromSubstring(String substring)
        {
            return books.FindAll(i => i.ISBN.Contains(substring));
        }

        //[HttpGet]
        //public IEnumerable<Book> GetWithFilter([FromQuery] FilterBook filter)
        //{

        //}
        // POST: api/Books
        [HttpPost]
        public void AddNewBook([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut]
        [Route("{ISBN}")]
        public void UpdateBook(string ISBN, [FromBody] Book value)
        {
            Book book = GetSpecificBook(ISBN);
            if(book != null)
            {
                book.Title = value.Title;
                book.Author = value.Author;
                book.PageNR = value.PageNR;
                book.ISBN = value.ISBN;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{ISBN}")]
        public void DeleteBook(string ISBN)
        {
            Book book = GetSpecificBook(ISBN);
            books.Remove(book);
        }
    }
}
