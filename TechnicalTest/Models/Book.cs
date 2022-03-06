using System;


namespace Interview.Model
{
    /// <summary>
    /// Represent Book repository type object
    /// </summary>
    public class Book : IStoreable
    {
        public IComparable Id { get; set; }
        public string BookTittle { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int OriginallyPublished { get; set; }

        public Book()
        {

        }
        public Book(IComparable Id, string BookTittle, string Author, decimal Price, int OriginallyPublished)
        {
            this.Id = Id;
            this.BookTittle = BookTittle;
            this.Author = Author;
            this.Price = Price;
            this.OriginallyPublished = OriginallyPublished;
        }
    }
}
