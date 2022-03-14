using Microsoft.AspNetCore.Mvc;
using MyLibrary.Data;
using MyLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLibrary.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookRentalController : ControllerBase
    {
        ILibraryLogic logic;

        public BookRentalController(ILibraryLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<BookRental> GetAll()
        {
            return this.logic.GetAllBookRentals();
        }

        [HttpGet("{id}")]
        public BookRental GetOne(int id)
        {
            return this.logic.GetBookRentalById(id);
        }

        [HttpPost]
        public void Create([FromBody] BookRental value)
        {
            this.logic.AddRental(value);
        }

        [HttpPut("{id}")]
        public void UpdateDays(int id, [FromBody] int value)
        {
            this.logic.ChangeBookRentalDays(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteRental(id);
        }
    }
}
