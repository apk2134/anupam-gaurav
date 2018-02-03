using BookEntity;
using BookRentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookRentBL
{
     public class BookManager
    {
        public void CreateBook( string bookId,string bookName,string publisher,int availability,int authorId,int categoryId)
        {
            Books books = new Books { BookId = bookId, BookName = bookName, Publisher_ = publisher, Avalability = availability };
            BooksAuthors bookAuthors = new BooksAuthors { AuthorId = authorId, BookId = bookId ,BookAuthorid="AI"+bookId};
            BookCategory bookCategory = new BookCategory { CategoryId = categoryId, BookId = bookId, BookCategory1 = "CI" + bookId };
            using (var repository = new CommonRepository<Books>())
            {
                repository.Create(books);
                
            }
            using (var repository = new CommonRepository<BookCategory>())
            {
                repository.Create(bookCategory);

            }
            using (var repository = new CommonRepository<BooksAuthors>())
            {
                repository.Create(bookAuthors);

            }
        }

        public void UpdateBook(string bookId, string bookName, string publisher, int availability, int authorId, int categoryId)
        {
            Books books = new Books { BookId = bookId, BookName = bookName, Publisher_ = publisher, Avalability = availability };
            BooksAuthors bookAuthors = new BooksAuthors { AuthorId = authorId, BookId = bookId, BookAuthorid = authorId + bookId };
            BookCategory bookCategory = new BookCategory { CategoryId = categoryId, BookId = bookId, BookCategory1 = categoryId + bookId };
            using (var repository = new CommonRepository<Books>())
            {
                repository.Update(books);

            }
            using (var repository = new CommonRepository<BookCategory>())
            {
                repository.Update(bookCategory);

            }
            using (var repository = new CommonRepository<BooksAuthors>())
            {
                repository.Update(bookAuthors);

            }
        }

        public Books GetBook(string bookId)
        {
            using (var repository = new CommonRepository<Books>())
            {
                return repository.Get(bookId);
            }
        }
        public BooksAuthors GetbookByAuthor(string bookId)
        {
            using (var repository = new CommonRepository<BooksAuthors>())
            {
                return repository.Get(bookId);
            }
        }
        public BookCategory GetbookByCategory(string bookId)
        {
            using (var repository = new CommonRepository<BookCategory>())
            {
                return repository.Get(bookId);
            }
        }
        public IEnumerable<Books> GetAllBooks()
        {
            using (var repository = new CommonRepository<Books>())
            {
                IEnumerable<Books> books= repository.GetAll();
                return books;
            }

        }
        public Books GetSingleBook(string isBn)
        {
            Entity context = new Entity();
            IRepository<Books> repository = new GenericRepository<Books>(context);
            return repository.Find(m => m.BookId == isBn, "BookCategory,BooksAuthors");


        }
    }
}
