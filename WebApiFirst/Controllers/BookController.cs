using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFirst.Data.Dtos;
using WebApiFirst.Data.Entities;
using WebApiFirst.Service;

namespace WebApiFirst.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _service.GetBooks().ToList();

            return Ok(response);

        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDto request)
        {
            var book = new Book
            {
                Name = request.Name
            };
            var affectedRowCount = _service.Insert(book);
            if (affectedRowCount > 0)
            {
                return Ok("kaydetme işlemi başarılı");
            }
            return NotFound("kaydetme işlemi başarısız");
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var book = _service.Get(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookDto request)
        {
            var book = new Book
            {
                Name = request.Name
            };

            var affectedRowCount = _service.Update(book);
            if (affectedRowCount > 0)
            {
                return Ok("Güncelleme Başarılı");
            }
            return NotFound("İlgili kitap bulunamadı/güncellenemedi");
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId)
        {
            int affectedRowCount = _service.Delete(bookId);
            if (affectedRowCount > 0)
            {
                return Ok("silme işlemi başarılı");
            }
            return NotFound("ilgili kitap bulunamadı/silinemedi");
        }



    }
}
