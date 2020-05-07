using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibB.model;
using RestBookService.Controllers;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllBooksTest()
        {
            BooksController controller = new BooksController();

            var result = controller.GetAllBooks() as List<Book>;

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetSpecificBookTest()
        {
            BooksController controller = new BooksController();

            var result = controller.GetSpecificBook("1234567890987");

            Assert.AreEqual("John Flanagan", result.Author);
        }

        [TestMethod]
        public void AddBookToListTest()
        {

            BooksController controller = new BooksController();

            Book book1 = new Book("Harry Potter and The Philosopher's stone", "J.K. Rowling", 373, "1232123212321");

            controller.AddNewBook(book1);

            var resultAll = controller.GetAllBooks() as List<Book>;

            var resultOne = controller.GetSpecificBook("1232123212321");

            Assert.AreEqual(3, resultAll.Count);

            Assert.AreEqual("J.K. Rowling", resultOne.Author);

        }

        [TestMethod]
        public void UpdataBookTest()
        {
            BooksController controller = new BooksController();

            var book1 = new Book("Codex Imperialis", "Roboute Guilliman", 542, "0987654321234");

            controller.UpdateBook("9418951247361", book1);

            var result = controller.GetSpecificBook("0987654321234");


            Assert.AreEqual("Codex Imperialis", result.Title);
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            BooksController controller = new BooksController();

            controller.DeleteBook("9418951247361");

            var result = controller.GetAllBooks() as List<Book>;

            Assert.AreEqual(1, result.Count);
        }
    }
}
