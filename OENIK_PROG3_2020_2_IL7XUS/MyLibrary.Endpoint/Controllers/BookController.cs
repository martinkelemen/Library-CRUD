using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyLibrary.Data;
using MyLibrary.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;

        public BookController(ILibraryLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Book value)
        {
            this.logic.UpdateBook(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);
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
            var bookToDelete = this.logic.GetBookById(id);
            this.logic.DeleteBook(id);
            this.hub.Clients.All.SendAsync("BookDeleted", bookToDelete);
        }
    }
}
