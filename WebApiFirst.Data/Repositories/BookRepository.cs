using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFirst.Data.Context;
using WebApiFirst.Data.Entities;
using WebApiFirst.Data.Repositories.Base;

namespace WebApiFirst.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(BookContext context) : base(context)
        {
        }

    }
      
}
