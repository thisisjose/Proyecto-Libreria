using libreria_JSVE.Data.ViewModels;
using libreria_JSVE.Data;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace libreria_JSVE.Data.Models.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;

        }
        //metodo para crear un libro
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AutorIDs)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }

        }
        //Metodo para obtener todos los libros
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Para obtener por id los libros paps
        public BookWithAuthorsVM GetBookById(int bookid)
        {
            var _booksWithAuthors = _context.Books.Where(n => n.id == bookid).Select(book => new BookWithAuthorsVM()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AutorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _booksWithAuthors;
        }
        //METODO PARA EDITAR UN LIBRO
        public Book UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n =>n.id == bookid);
            if (_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();  
            }
            return _book;
        }
        public void DeleteBookByID(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n =>n.id == bookid);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
