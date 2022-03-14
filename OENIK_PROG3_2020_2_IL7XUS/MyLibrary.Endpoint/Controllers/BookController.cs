using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        ILibraryLogic logic;

        public BookController(ILibraryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return this.logic.GetAllBooks();
        }

        [HttpGet("{id}")]
        public Book GetOne(string id)
        {
            return this.logic.GetBookById(id);
        }

        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.logic.AddBook(value);
        }

        [HttpPut("{id}")]
        public void UpdatePublisher(string id, [FromBody] string value)
        {
            this.logic.ChangeBookPublisher(id, value);
        }

        //public void UpdatePublisher(string id, [FromBody] string value)
        //{
        //    this.logic.ChangeBookPublisher(id, value);
        //}

        //public void UpdateYear(string id, [FromBody] int value)
        //{
        //    this.logic.ChangeBookYear(id, value);
        //}

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.logic.DeleteBook(id);
        }
    }
}
