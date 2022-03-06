using Interview;
using Interview.RepoCore;
using Interview.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestForTechTest
{
    [TestFixture]
    public class BookRepoOperationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TrySavingBookToRepo_01()
        {
            // To test single book saving case
            Book bookInSearchofLostTime = new Book(1, "In Search of Lost Time", "Marcel Proust", 2.5m, 1913);

            Repository<Book> bookRepository = new Repository<Book>();

            bookRepository.Save(bookInSearchofLostTime);

            var bookList = bookRepository.All();

            Assert.IsTrue(((IEnumerable<Book>)bookList).Contains(bookInSearchofLostTime));
        }

        [Test]
        public void TrySavingBooksToRepo_01()
        {
            // To test multiple book saving case
            Book bookInSearchofLostTime = new Book(1, "In Search of Lost Time", "Marcel Proust", 2.5m, 1913);
            Book bookUlysses = new Book(2, "Ulysses", "James Joycet", 2.9m, 1920);

            Repository<Book> bookRepository = new Repository<Book>();

            bookRepository.Save(bookInSearchofLostTime);
            bookRepository.Save(bookUlysses);

            var bookList = bookRepository.All();

            Assert.IsTrue(bookList.Count() == 2);
        }

        [Test]
        public void TryDeletingBookFromRepo()
        {
            // To Test delete operation
            Book bookInSearchofLostTime = new Book { Id = 1, BookTittle = "In Search of Lost Time", Author = "Marcel Proust", Price = 2.5m, OriginallyPublished = 1913 };
            Book bookUlysses = new Book { Id = 2, BookTittle = "Ulysses", Author = "James Joycet", Price = 2.9m, OriginallyPublished = 1920 };
            Book bookMobyDick = new Book { Id = 3, BookTittle = "Moby Dick", Author = "Herman Melville", Price = 3.2m, OriginallyPublished = 1851 };

            Repository<Book> bookRepository = new Repository<Book>();
            bookRepository.Save(bookInSearchofLostTime);
            bookRepository.Save(bookUlysses);
            bookRepository.Save(bookMobyDick);

            bookRepository.Delete(bookUlysses.Id);

            var bookList = bookRepository.All();

            Assert.IsFalse(((IEnumerable<Book>)bookList).Contains(bookUlysses));
        }

        [Test]
        public void TryDeletingBookFromRepo_NegativeTest()
        {
            // To Test delete operation for an non exiting item in repo
            Book bookInSearchofLostTime = new Book { Id = 1, BookTittle = "In Search of Lost Time", Author = "Marcel Proust", Price = 2.5m, OriginallyPublished = 1913 };
            Book bookUlysses = new Book { Id = 2, BookTittle = "Ulysses", Author = "James Joycet", Price = 2.9m, OriginallyPublished = 1920 };
            Book bookMobyDick = new Book { Id = 3, BookTittle = "Moby Dick", Author = "Herman Melville", Price = 3.2m, OriginallyPublished = 1851 };

            Book bookInvisibleMan = new Book { Id = 4, BookTittle = "Invisible Man", Author = "Ralph Ellison", Price = 3.2m, OriginallyPublished = 1952 };

            Repository<Book> bookRepository = new Repository<Book>();
            bookRepository.Save(bookInSearchofLostTime);
            bookRepository.Save(bookUlysses);
            bookRepository.Save(bookMobyDick);

            bookRepository.Delete(bookInvisibleMan.Id);

            var bookList = bookRepository.All();

            Assert.IsFalse(((IEnumerable<Book>)bookList).Contains(bookInvisibleMan));
        }

        [Test]
        public void TryFindingBookFromRepo()
        {
            Book bookInSearchofLostTime = new Book { Id = 1, BookTittle = "In Search of Lost Time", Author = "Marcel Proust", Price = 2.5m, OriginallyPublished = 1913 };
            Book bookUlysses = new Book { Id = 2, BookTittle = "Ulysses", Author = "James Joycet", Price = 2.9m, OriginallyPublished = 1920 };
            Book bookWarAndPeace = new Book { Id = 3, BookTittle = "War and Peace", Author = "Leo Tolstoy", Price = 3.7m,OriginallyPublished = 1867 };
            Book bookMobyDick = new Book { Id = 3, BookTittle = "Moby Dick", Author = "Herman Melville", Price = 3.2m, OriginallyPublished = 1851 };

            Repository<Book> bookRepository = new Repository<Book>();
            bookRepository.Save(bookInSearchofLostTime);
            bookRepository.Save(bookUlysses);
            bookRepository.Save(bookWarAndPeace);
            bookRepository.Save(bookMobyDick);

            var findBook = bookRepository.FindById(bookWarAndPeace.Id);

            Assert.IsNotNull(findBook);
        }
        [Test]
        public void TryFindingBookFromRepo_NegativeTest()
        {
            Book bookInSearchofLostTime = new Book { Id = 1, BookTittle = "In Search of Lost Time", Author = "Marcel Proust", Price = 2.5m, OriginallyPublished = 1913 };
            Book bookUlysses = new Book { Id = 2, BookTittle = "Ulysses", Author = "James Joycet", Price = 2.9m, OriginallyPublished = 1920 };
            Book bookWarAndPeace = new Book { Id = 3, BookTittle = "War and Peace", Author = "Leo Tolstoy", Price = 3.7m, OriginallyPublished = 1867 };
            Book bookMobyDick = new Book { Id = 3, BookTittle = "Moby Dick", Author = "Herman Melville", Price = 3.2m, OriginallyPublished = 1851 };

            Book bookInvisibleMan = new Book { Id = 4, BookTittle = "Invisible Man", Author = "Ralph Ellison", Price = 3.2m, OriginallyPublished = 1952 };

            Repository<Book> bookRepository = new Repository<Book>();
            bookRepository.Save(bookInSearchofLostTime);
            bookRepository.Save(bookUlysses);
            bookRepository.Save(bookWarAndPeace);
            bookRepository.Save(bookMobyDick);

            var findBook = bookRepository.FindById(bookInvisibleMan.Id);

            Assert.IsNull(findBook);
        }
        [Test]
        public void ErrorTest()
        {
            Repository<Book> bookRepository = new Repository<Book>();
            bookRepository.Delete(1);
        }
    }
}