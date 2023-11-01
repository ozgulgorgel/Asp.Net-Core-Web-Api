using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFirst.Data.Entities;
using WebApiFirst.Data.Repositories;

namespace WebApiFirst.Service
{
    public class BookService
    {
        private readonly BookRepository _repository;
        public BookService(BookRepository repository)
        {
            _repository = repository;
        }
        public List<Book> GetBooks()
        {
            return _repository.GetAll().ToList();
        }


        public int Insert(Book book)
        {
            return _repository.Insert(book);
        }
        public Book Get(int id)
        {
            return _repository.GetById(id);
        }


        public int Update(Book book)
        {
            return _repository.Update(book);
        }

        public int Delete(int bookId)
        {
            return _repository.Delete(bookId);
        }
    }
}
